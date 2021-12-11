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
    public partial class InsertUser : Form
    {
        public InsertUser()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader sqlReader;

        DbOperations db = new DbOperations();
        InsertOperations insert = new InsertOperations();

        string rolId, depId, titId;

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (!insert.UserBoxsIsNull(mailTxt.Text, nameTxt.Text, surnameTxt.Text, telTxt.Text, intNumTxt.Text, rolBox.SelectedIndex, depBox.SelectedIndex, titleBox.SelectedIndex))
            {
                MessageBox.Show("Boş Bırakmayın!");
            }
            else
            {
                string comQuery = "SELECT * FROM users";
                string colName = "mail";

                if (insert.NotRegistered(comQuery, mailTxt.Text.Trim(), colName))
                {
                    comboItemSelect();
                    string mail = mailTxt.Text.Trim(), name = nameTxt.Text.Trim().ToLower(), surname = surnameTxt.Text.Trim().ToLower(), tel = telTxt.Text.Trim(), intNum = intNumTxt.Text.Trim();

                    comQuery = "INSERT INTO users (mail, name, surname, tel, intNum, rolId, depId, titId, actId) " +
                        "VALUES ('" + mail + "', '" + name + "', '" + surname + "', '" + tel + "', '" + intNum + "', " + rolId + ", " + depId + ", " + titId + ", 0)";

                    if (insert.InsertRow(comQuery))
                    {
                        MessageBox.Show("Kayıt Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Başarısız");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıtlı Kullanıcı.");
                }
            }
        }

        private void InsertUser_Load(object sender, EventArgs e)
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            RolList();
            DepList();
            TitleList();

            connection.Close();
        }

        private void RolList()
        {
            command = new SqlCommand("SELECT * FROM rols where actId=1", connection);
            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                rolBox.Items.Add(sqlReader["rolName"].ToString());
            }

            sqlReader.Close();
        }

        private void DepList()
        {
            command = new SqlCommand("SELECT * FROM departments where actId=1", connection);
            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                depBox.Items.Add(sqlReader["depName"].ToString());
            }

            sqlReader.Close();
        }

        private void TitleList()
        {
            command = new SqlCommand("SELECT * FROM titles where actId=1", connection);
            sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                titleBox.Items.Add(sqlReader["title"].ToString());
            }

            sqlReader.Close();
        }

        private void comboItemSelect()
        {
            connection.Open();

            command = new SqlCommand("SELECT id FROM rols WHERE rolName='"+rolBox.SelectedItem+"'", connection);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                rolId = sqlReader["id"].ToString();
            }

            sqlReader.Close();

            command = new SqlCommand("SELECT id FROM departments WHERE depName='" + depBox.SelectedItem + "'", connection);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                depId = sqlReader["id"].ToString();
            }

            sqlReader.Close();

            command = new SqlCommand("SELECT id FROM titles WHERE title='" + titleBox.SelectedItem + "'", connection);
            sqlReader = command.ExecuteReader();

            if (sqlReader.Read())
            {
                titId = sqlReader["id"].ToString();
            }

            sqlReader.Close();
            connection.Close();
        }
    }
}
