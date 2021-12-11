using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;

namespace cbu
{
    class UserOperations
    {

        string mail = LogInForm.mail;

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dr;
        SqlDataAdapter da;

        DbOperations db = new DbOperations();
        
        private void dbConnection()
        {
            db.DbConnect();
            connection = db.connection;
            connection.Open();
        }

        public void ListUserInfo( Label mailLbl, Label nameLbl, Label depLbl, Label rolLbl, Label telLbl, Label titleLbl)
        {
            dbConnection();

            command = new SqlCommand("SELECT * FROM users " + 
                "LEFT OUTER JOIN rols ON users.rolId = rols.id " +
                "LEFT OUTER JOIN departments AS dep ON users.depId = dep.id " +
                "LEFT OUTER JOIN titles ON users.titId = titles.id " +
                "LEFT OUTER JOIN actives ON users.actId = actives.id " +
                "WHERE mail='"+ mail +"'", connection);

            dr = command.ExecuteReader();
            
            if (dr.Read())
            {
                mailLbl.Text = dr["mail"].ToString();
                rolLbl.Text = dr["rolName"].ToString();
                depLbl.Text = dr["depName"].ToString();
                nameLbl.Text = dr["name"].ToString() + " " + dr["surName"].ToString();
                telLbl.Text = dr["tel"].ToString();
                titleLbl.Text = dr["title"].ToString();
            }
        }
        
        public void ListDg(DataGridView dg, string query)
        {
            dg.Visible = true;

            dbConnection();

            command = new SqlCommand(query , connection);

            da = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dg.DataSource = dt;

            connection.Close();
        }

        public string passCrypto(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] password = Encoding.UTF8.GetBytes(pass);
            password = md5.ComputeHash(password);

            StringBuilder sb = new StringBuilder();

            foreach (var item in password)
            {
                sb.Append(item.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
