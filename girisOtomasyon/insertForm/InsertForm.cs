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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader queryReader;

        DbOperations db = new DbOperations();
        UbsForm u = new UbsForm();

        public string query, colName, tableName;

        private void insertBtn_Click(object sender, EventArgs e)
        {
            string insert = insertTxt.Text.Trim().ToLower();
            if (IsNull(insert))
            {

                if (NotRegistered(query, insert, colName))
                {

                    if (InsertRow("INSERT INTO " + tableName + " (" + colName + ", actId) VALUES ('" + insert + "', 1)"))
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
                    MessageBox.Show("Kayıtlı Aktiflik Durumu.");
                }
            }
            else
            {
                MessageBox.Show("Boş Bırakmayın!");
            }
        }

        public bool IsNull(string nameText)
        {
            if (nameText == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool NotRegistered(string query, string nameTxt, string colName)
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand(query, connection);
            queryReader = command.ExecuteReader();

            while (queryReader.Read())
            {
                if (nameTxt == queryReader[colName].ToString())
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

        private void InsertForm_Load(object sender, EventArgs e)
        {

        }
    }
}
