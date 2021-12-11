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
    public partial class UpdateLessonsForm : Form
    {
        public UpdateLessonsForm()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;

        DbOperations db = new DbOperations();

        public string id, depId, lecMail, aktsId, periodId;
        private void UpdateLessonsForm_Load(object sender, EventArgs e)
        {
            lessonList();
            lecturerList();
            aktsList();
            depList();
            periodList();
        }

        private void lessonList()
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            string query = "SELECT les.id, les.name, les.code, les.depId, les.periodId, les.aktsId, les.lecturerMail, dep.depName, " +
                "dep.shortName, per.period, akts.akts, users.name as userName, users.surname " +
                "FROM lessons AS les " +
                "LEFT OUTER JOIN departments AS dep ON les.depId=dep.id " +
                "LEFT OUTER JOIN periods AS per ON les.periodId=per.id " +
                "LEFT OUTER JOIN akts ON les.aktsId=akts.id " +
                "LEFT OUTER JOIN users ON les.lecturerMail=users.mail " +
                "WHERE les.id="+ id;

            command = new SqlCommand(query, connection);
            dr = command.ExecuteReader();

            if (dr.Read())
            {
                nameTxt.Text = dr["name"].ToString();
                lecturerCombo.Text = dr["userName"].ToString() + " " + dr["surname"].ToString();
                aktsCombo.Text = dr["akts"].ToString();
                depCombo.Text = dr["depName"].ToString();
                codeCombo.Text = dr["shortName"].ToString();
                codeTxt.Text = dr["code"].ToString();
                periodCombo.Text = dr["period"].ToString();
                depId = dr["depId"].ToString();
                lecMail = dr["lecturerMail"].ToString();
                aktsId = dr["aktsId"].ToString();
                periodId = dr["periodId"].ToString();
            }

            dr.Close();
            connection.Close();
        }

        private void lecturerList()
        {   
            connection.Open();

            command = new SqlCommand("SELECT name, surname FROM users WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                lecturerCombo.Items.Add(dr["name"].ToString() + " " + dr["surname"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void aktsList()
        {
            connection.Open();

            command = new SqlCommand("SELECT akts FROM akts", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                aktsCombo.Items.Add(dr["akts"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void depList()
        { 
            connection.Open();

            command = new SqlCommand("SELECT depName FROM departments WHERE actId=1", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                depCombo.Items.Add(dr["depName"].ToString());
            }

            dr.Close();
            connection.Close();
        }
        
        private void periodList()
        {
            connection.Open();

            command = new SqlCommand("SELECT period FROM periods", connection);
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                periodCombo.Items.Add(dr["period"].ToString());
            }

            dr.Close();
            connection.Close();
        }

        private void depCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT shortName FROM departments WHERE depName='" + depCombo.SelectedItem + "'", connection);
            dr = command.ExecuteReader();
            switch (dr.Read())
            {
                case true:
                    codeCombo.Text = dr["shortName"].ToString();
                    break;
            }
            dr.Close();
            connection.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
                comboIsSelected();
                lessonUpdate();
            }
        }

        private bool isEmpty()
        {
            if (nameTxt.Text.Trim() == "" || codeTxt.Text.Trim() == "")
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
            if (lecturerCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT mail FROM users WHERE name+' '+surname='" + lecturerCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    lecMail = dr["mail"].ToString();
                }

                connection.Close();
            }
            if (aktsCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT id FROM akts WHERE akts='" + aktsCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    aktsId = dr["id"].ToString();
                }

                connection.Close();
            }
            if (periodCombo.SelectedIndex > -1)
            {
                connection.Open();

                command = new SqlCommand("SELECT id FROM periods WHERE period='" + periodCombo.SelectedItem + "'", connection);
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    periodId = dr["id"].ToString();
                }

                connection.Close();
            }
           
        }

        private bool lessonUpdate()
        {
            connection.Open();
            string query = "UPDATE lessons " +
                "SET depId='" + depId + "', periodId='" + periodId + "', code='" + codeTxt.Text.Trim() + "', name='" + nameTxt.Text.Trim().ToLower() + "', " +
                "aktsId=" + aktsId + ", lecturerMail='" + lecMail + "' "+
                "WHERE id=" + id ;
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
