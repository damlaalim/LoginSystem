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
    public partial class UpdateDepartmentForm : Form
    {
        public UpdateDepartmentForm()
        {
            InitializeComponent();
        }

        public string data;

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;

        DbOperations db = new DbOperations();

        private void UpdateDepartmentForm_Load(object sender, EventArgs e)
        {
            depList();
        }

        private void depList()
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand("SELECT * FROM departments WHERE id="+ data, connection);
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                depNameTxt.Text = dr["depName"].ToString();
                shortNameTxt.Text = dr["shortName"].ToString();
            }

            dr.Close();
            connection.Close();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
               depUpdate();
            }
        }

        private bool isEmpty()
        {
            if (depNameTxt.Text.Trim() == "" || shortNameTxt.Text.Trim() == "")
            {
                MessageBox.Show("Boş Geçmeyin");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool depUpdate()
        {
            connection.Open();
            string query = "UPDATE departments " +
                "SET depName='" + depNameTxt.Text.Trim().ToLower() + "', shortName='" + shortNameTxt.Text.Trim().ToUpper() + "' " + 
                "WHERE id=" + data;

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
