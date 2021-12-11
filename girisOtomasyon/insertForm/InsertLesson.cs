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
    public partial class InsertLesson : Form
    {
        public InsertLesson()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;
        
        DbOperations db = new DbOperations();
        InsertOperations insert = new InsertOperations();

        string depId, periodId, aktsId;
        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
                if (notRegistered() && isEqualLectMail())
                {
                    idAssignment();
                    string query = "INSERT INTO lessons (depId, periodId, code, name, aktsId, lecturerMail, actId) " +
                        "VALUES ("+ depId +", "+ periodId +", '"+ codeBox.Text.Trim() + "', '"+ lesNameTxt.Text.Trim().ToLower() + "', "+ aktsId +", '"+ lectrurerMailCombo.SelectedItem.ToString() +"', 1)";
                    if (insert.InsertRow(query))
                    {
                        MessageBox.Show("Ders Kaydı Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Ders Kaydı Başarısız");
                    }
                }
            }
        }

        private void InsertLesson_Load(object sender, EventArgs e)
        {
            db.DbConnect();
            connection = db.connection;
            
            PeriodList();
            AktsList();
            DepList();
            LectList(); 
        }
 
        private void PeriodList()
        {
            connection.Open();
            command = new SqlCommand("SELECT period FROM periods", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                periodCombo.Items.Add(dr["period"]);
            }

            dr.Close();
            connection.Close();
        }

        private void AktsList()
        {
            connection.Open();
            command = new SqlCommand("SELECT akts FROM akts", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                aktsCombo.Items.Add(dr["akts"]);
            }

            dr.Close();
            connection.Close();
        }

        private void DepList()
        {
            connection.Open();
            command = new SqlCommand("SELECT depName FROM departments WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                depCombo.Items.Add(dr["depName"]);
            }

            dr.Close();
            connection.Close();
        }

        private void LectList()
        {
            connection.Open();
            command = new SqlCommand("SELECT name, surName FROM users WHERE titId!=6 AND actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                lecturerCombo.Items.Add(dr["name"].ToString() + " " + dr["surName"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private bool isEmpty()
        {
            if (lesNameTxt.Text.Trim() == "" || codeBox.Text.Trim() == "")
            {
                MessageBox.Show("Boş Bırakmayın");
                return true;
            }

            if (periodCombo.SelectedIndex == -1 || aktsCombo.SelectedIndex == -1 || depCombo.SelectedIndex == -1 || lecturerCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Boş Bırakmayın");
                return true;
            }
            return false;
        }

        private bool notRegistered()
        {
            string query = "SELECT * FROM lessons", nameTxt = lesNameTxt.Text.Trim(), colName = "name";
            if (insert.NotRegistered(query, nameTxt, colName))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Kayıtlı Ders");
                return false;
            }
        }

        private bool isEqualLectMail()
        {
            connection.Open(); 
            command = new SqlCommand("SELECT * FROM users WHERE name+' '+surname='"+ lecturerCombo.SelectedItem +"' AND mail='"+ lectrurerMailCombo.SelectedItem +"'", connection);
            dr = command.ExecuteReader();
            if (!dr.Read())
            {
                dr.Close();
                connection.Close();

                MessageBox.Show("Öğretim Görevlisine Ait Mail Adresini Seçiniz.");
                
                return false;
            }

            dr.Close();
            connection.Close();

            return true;
        }

        private void lecturerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lectrurerMailCombo.Items.Clear();
            connection.Open();
            command = new SqlCommand("SELECT mail FROM users WHERE name+' '+surname='"+ lecturerCombo.SelectedItem.ToString() + "'", connection);
            dr = command.ExecuteReader();
            
            while (dr.Read())
            {
                lectrurerMailCombo.Items.Add(dr["mail"]);
            }

            dr.Close();
            connection.Close();
        }

        private void idAssignment()
        {
            string query = "SELECT id FROM departments WHERE depName='" + depCombo.SelectedItem + "'";
            depId = insert.idAssignment(query);
            query = "SELECT id FROM periods WHERE period='" + periodCombo.SelectedItem + "'";
            periodId = insert.idAssignment(query);
            query = "SELECT id FROM akts WHERE akts='" + aktsCombo.SelectedItem + "'";
            aktsId = insert.idAssignment(query);
        }

        private void depCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT shortName FROM departments WHERE depName='" + depCombo.SelectedItem + "'", connection);
            dr = command.ExecuteReader();
            switch (dr.Read())
            {
                case true:
                    shortNameBox.Text = dr["shortName"].ToString();
                    break;
            }
            dr.Close();
            connection.Close();
        } 
    }
}
