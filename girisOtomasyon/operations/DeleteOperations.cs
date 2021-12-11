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
    class DeleteOperations
    {
        SqlConnection connection;
        SqlCommand command; 

        DbOperations db = new DbOperations();

        public bool deleteRow(string query)
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
    }
}
