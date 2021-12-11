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
    public partial class InsertDepartmentForm : Form
    {
        public InsertDepartmentForm()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader queryReader;

        DbOperations db = new DbOperations();         

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (IsNull())
            {
                if (NotRegistered())
                {

                    if (InsertRow("INSERT INTO departments (depName, actId, shortName) VALUES ('" + nameTxt.Text.Trim().ToLower() + "', 1, '"+ shortNameTxt.Text.Trim().ToUpper() +"')"))
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
                    MessageBox.Show("Kayıtlı Departman.");
                }
            }
            else
            {
                MessageBox.Show("Boş Bırakmayın!");
            }
        }

        public bool IsNull()
        {
            if (nameTxt.Text == "" || shortNameTxt.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool NotRegistered()
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand("SELECT * FROM departments", connection);
            queryReader = command.ExecuteReader();

            while (queryReader.Read())
            { 
                if (nameTxt.Text.Trim().ToLower() == queryReader["depName"].ToString() || shortNameTxt.Text.Trim().ToUpper() == queryReader["shortName"].ToString())
                {
                    connection.Close();
                    queryReader.Close();

                    return false;
                }
            }

            queryReader.Close();
            connection.Close();

            return true;
        }

        public bool InsertRow(string query)
        {
            connection.Open();
            command.CommandText = query;

            int result = command.ExecuteNonQuery();
            if (result < 0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }

        private void InsertDepartmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
