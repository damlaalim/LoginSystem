using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cbu
{
    class DbOperations
    {
        public SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;

        public void DbConnect()
        {
            connection = new SqlConnection("server=DESKTOP-6FGP8TL\\SQLEXPRESS; Initial Catalog=cbuDb;Integrated Security=SSPI");
            command = new SqlCommand();
        }

        public bool LogInControl(string mail, string pass)
        { 
            connection.Open();
            
            command.Connection = connection;
            command.CommandText = "SELECT * FROM users WHERE mail='" + mail + "' AND password='" + pass + "' AND actId=1";
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                dataReader.Close();
                connection.Close();

                return true;
            }

            dataReader.Close();
            connection.Close();
            
            return false;
        }

        public bool RegisterControl(string mail)
        {
            try
            {
                connection.Open(); 
                command.Connection = connection;
                command.CommandText = "SELECT * FROM users WHERE mail='" + mail + "' AND actId=0";
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), " mail gönderme hatası");
                throw;
            }
             
            connection.Close();
            return false;
        }

        public void UserSelect(string mail)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM users WHERE mail='"+mail+"'";

            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                if (dataReader["rolId"].ToString() == "1")
                {
                    UbsForm ubs = new UbsForm();
                    ubs.Show();
                }
                else if (dataReader["rolId"].ToString() == "0")
                {
                    StudentForm student = new StudentForm();
                    student.Show();
                }
            }
        }
    }
}
