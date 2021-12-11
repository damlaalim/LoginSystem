using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace cbu
{
    public partial class updateUserForm : Form
    {
        public updateUserForm()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;

        DbOperations db = new DbOperations();
        string depId, titId, rolId;
         
        private void UserInfoList()
        {
            db.DbConnect();
            connection = db.connection;

            connection.Open();
            
            command = new SqlCommand("SELECT * FROM users " +
                "LEFT OUTER JOIN rols ON users.rolId = rols.id " +
                "LEFT OUTER JOIN departments ON users.depId = departments.id " +
                "LEFT OUTER JOIN titles ON users.titId = titles.id " +
                "WHERE mail='" + LogInForm.mail + "'", connection);

            dr = command.ExecuteReader();

            if (dr.Read())
            {
                nameTxt.Text = dr["name"].ToString();
                surNameTxt.Text = dr["surName"].ToString();
                mailTxt.Text = dr["mail"].ToString();
                intNumTxt.Text = dr["intNum"].ToString();
                telTxt.Text = dr["tel"].ToString();
                rolCombo.Text = dr["rolName"].ToString();
                depCombo.Text = dr["depName"].ToString();
                titleCombo.Text = dr["title"].ToString();
                
                titId = dr["titId"].ToString();
                rolId = dr["rolId"].ToString();
                depId = dr["depId"].ToString();

                switch (dr["rolId"].ToString())
                {
                    case "1":
                        comboEnabled();
                        labelvisible();
                        break;
                }
            }

            dr.Close();
            connection.Close();
        }

        private void comboEnabled()
        {
            rolCombo.Enabled = true;
            depCombo.Enabled = true;
            titleCombo.Enabled = true;
            intNumTxt.Enabled = true;
        }

        private void labelvisible()
        {
            infoLbl1.Visible = false;
            infoLbl2.Visible = false;
        }

        private void RolList()
        {
            connection.Open();
            command = new SqlCommand("SELECT * FROM rols WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                rolCombo.Items.Add(dr["rolName"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void DepList()
        {
            connection.Open();
            command = new SqlCommand("SELECT * FROM departments WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                depCombo.Items.Add(dr["depName"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void updateUserForm_Load(object sender, EventArgs e)
        {
            UserInfoList();
            RolList();
            DepList();
            TitleList();
        }

        private void TitleList()
        {
            connection.Open();
            command = new SqlCommand("SELECT * FROM titles WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                titleCombo.Items.Add(dr["title"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
                comboIsSelected();
                if(userUpdate())
                {
                    UserInfoList();
                }
            }
        }

        private bool isEmpty()
        {
            if (nameTxt.Text == "" || surNameTxt.Text == "" || intNumTxt.Text == "" || telTxt.Text == "")
            {
                MessageBox.Show("Boş Geçmeyin");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void passUpdateBtn_Click(object sender, EventArgs e)
        {
            if (passIsEmpty())
            {
                UserOperations user = new UserOperations();

                string pass = user.passCrypto(passTxt.Text.Trim()), newPass = user.passCrypto(newPassTxt.Text.Trim());

                if (passIsSame() && passDbControl(pass))
                {
                    connection.Open();
                    command = new SqlCommand("UPDATE users SET password='"+ newPass + "' WHERE mail='"+LogInForm.mail+"'", connection);

                    if (command.ExecuteNonQuery() > -1)
                    {
                        MessageBox.Show("Şifre Güncelleme İşleminiz Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Şifre Güncelleme İşleminiz başarısız");
                    }
                }
            }
        }

        private bool passIsEmpty()
        {
            if (passTxt.Text == "" || newPassTxt.Text == "" || rePassTxt.Text == "")
            {
                MessageBox.Show("Boş Bırakmayın");
                return false;
            }
            return true;
        }
        
        private bool passDbControl(string pass) 
        {
            connection.Open();
            command = new SqlCommand("SELECT password FROM users WHERE mail='"+ LogInForm.mail +"'", connection);

            dr = command.ExecuteReader();
            if (dr.Read() && pass == dr["password"].ToString())
            {
                connection.Close();
                dr.Close();
                return true;
            }
            connection.Close();
            dr.Close();
            MessageBox.Show("Şifreler uyuşmuyor");
            return false;
        }

        private bool passIsSame()
        {
            if (newPassTxt.Text.Trim() != rePassTxt.Text.Trim())
            {
                MessageBox.Show("Şifreleriniz Eşleşmiyor");
                return false;
            }
            return true;
        }

        private bool userUpdate()
        {
            connection.Open();
            string query = "UPDATE users " +
                "SET name='" + nameTxt.Text.Trim() + "', surName='" + surNameTxt.Text.Trim() + "', tel='" + telTxt.Text.Trim() + "', " +
                "intNum='" + intNumTxt.Text.Trim() + "', " +
                "rolId=" + rolId + ", depId=" + depId + ", titId=" + titId + " " +
                "WHERE mail='" + mailTxt.Text.Trim() + "'";
            command = new SqlCommand(query, connection);

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Güncelleme başarılı");
                connection.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız");
                connection.Close();
                return false;
            }
        }

        private void comboIsSelected()
        {
            if (depCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT id FROM departments WHERE depName='" + depCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    depId = dr["id"].ToString();
                }

                connection.Close();
            }
            if (rolCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT id FROM rols WHERE rolName='" + rolCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    rolId = dr["id"].ToString();
                }

                connection.Close();
            }
            if (titleCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT id FROM titles WHERE title='" + titleCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    titId = dr["id"].ToString();
                }

                connection.Close();
            }
        }


    }
} 