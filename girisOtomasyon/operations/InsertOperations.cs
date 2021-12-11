using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace cbu
{
    class InsertOperations
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader queryReader;

        DbOperations db = new DbOperations();
        
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

        public bool UserBoxsIsNull(string mail, string name, string surname, string tel, string intNum, int rol, int dep, int title)
        {
            if (mail == "" || name == "" || surname == "" || tel == "" || intNum == "")
            {
                return false;
            }
            else if (rol == -1 || dep == -1 || title == -1)
            {
                return false;
            }

            return true;
        }
        
        public string idAssignment(string query)
        {
            string id = "";

            db.DbConnect();
            connection = db.connection;
            connection.Open();

            command = new SqlCommand(query, connection);
            queryReader = command.ExecuteReader();

            if (queryReader.Read())
            {
                id = queryReader["id"].ToString();
            }

            queryReader.Close();
            connection.Close();
            return id;
        }
    }
}