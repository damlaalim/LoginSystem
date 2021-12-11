using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace cbu
{
    class UpdateOperations
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter da;
        SqlDataReader dr;

        DbOperations db = new DbOperations();

        public void VisibleTrue(Label label, TextBox textBox, Button upBtn, Button delBtn)
        {
            label.Visible = true;
            textBox.Visible = true;
            upBtn.Visible = true;
            delBtn.Visible = true;
        }

        public void DataGet(string query, DataGridView dg)
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand(query, connection);

            da = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dg.DataSource = dt;

            connection.Close();
        }

        public bool IsDifferent(string text, string dg)
        {
            if (text == dg)
            {
                return false;
            }

            return true;
        }
          
        public bool updateRow(string query)
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand(query, connection);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                connection.Close();

                return true;
            }
            else
            {
                connection.Close();

                return false;
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

        public void deleteRow(string query)
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand(query, connection);
            int result = command.ExecuteNonQuery();
            if (result > -1)
            {
                MessageBox.Show("Silme İşlemi Başarılı");
            }
            else
            {
                MessageBox.Show("Silme İşlemi Başarılı");
            }
        }
    }
}
