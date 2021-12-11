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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        } 

        public string query, data, command, colName, tableName;

        UpdateOperations update = new UpdateOperations();

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string updateText = updateTxt.Text.Trim().ToLower();
            if (update.IsNull(updateText))
            {
                if (update.IsDifferent(updateText, data))
                { 
                    query = "UPDATE "+ tableName +" SET "+ colName +"='"+ updateText + "' WHERE id = "+ data;

                    if (update.updateRow(query))
                    {
                        MessageBox.Show("Güncelleme Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme Başarısız");
                    }
                     
                }
                else
                {
                    MessageBox.Show("Farklı Bilgi Girişi Yapın");
                }
            }
            else
            {
                MessageBox.Show("Boş Bırakmayın");
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            DbOperations db = new DbOperations();
            db.DbConnect();
            SqlConnection con = db.connection;
            con.Open();
            SqlCommand com = new SqlCommand("SELECT " + colName + " FROM " + tableName + " WHERE id=" + data, con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                updateTxt.Text = dr[colName].ToString();
            }
            con.Close();
        }
    }
}
