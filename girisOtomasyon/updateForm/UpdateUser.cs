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
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        public string mail;
        string depId, rolId, titId;

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;

        DbOperations db = new DbOperations();
        
        private void UpdateUser_Load(object sender, EventArgs e)
        {
            userList();
            RolList();
            DepList();
            TitleList();
        }

        private void userList()
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand("SELECT * FROM users " +
                "LEFT OUTER JOIN departments ON users.depId = departments.id "+
                "LEFT OUTER JOIN rols ON users.rolId = rols.id "+
                "LEFT OUTER JOIN titles ON users.titId = titles.id "+ 
                "WHERE mail='"+ mail +"'", connection);
            dr = command.ExecuteReader();

            if (dr.Read())
            {
                nameTxt.Text = dr["name"].ToString();
                mailTxt.Text = mail;
                surNameTxt.Text = dr["surName"].ToString();
                intNumTxt.Text = dr["intNum"].ToString();
                telTxt.Text = dr["tel"].ToString();
                depCombo.Text = dr["depName"].ToString();
                rolCombo.Text = dr["rolName"].ToString();
                titleCombo.Text = dr["title"].ToString();
                depId = dr["depId"].ToString();
                rolId = dr["rolId"].ToString();
                titId = dr["titId"].ToString();
            }

            dr.Close();
            connection.Close();
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
                if (userUpdate())
                {
                    userList();
                }
            }
        }

        private bool isEmpty()
        {
            if (nameTxt.Text.Trim() == "" || surNameTxt.Text.Trim() == "" || intNumTxt.Text.Trim() == "" || telTxt.Text.Trim() == "")
            {
                MessageBox.Show("Boş Geçmeyin");
                return true;
            }
            else
            {
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

        private bool userUpdate()
        {
            connection.Open();
            string query = "UPDATE users " +
                "SET name='" + nameTxt.Text.Trim().ToLower() + "', surName='" + surNameTxt.Text.Trim().ToLower() + "', " +
                "tel='" + telTxt.Text.Trim() + "', intNum='" + intNumTxt.Text.Trim() + "', " +
                "rolId=" + rolId + ", depId=" + depId + ", titId=" + titId + " " +
                "WHERE mail='" + mailTxt.Text.Trim()+ "'";
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
    }
}
