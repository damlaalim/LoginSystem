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
    public partial class UbsForm : Form
    {
        public UbsForm()
        {
            InitializeComponent();
        }

        string query, colName, idCol = "id", command, tableName;
        int id;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            query = "SELECT u.mail as 'Mail', u.name as 'Ad', u.surName as 'Soyad', u.tel as 'Telefon', u.intNum as 'Dahiliye No', " +
                "rols.rolName as 'Rol', dep.depName as 'Departman', titles.title as 'Ünvan', actives.active as 'Aktiflik'" +
                "FROM users AS u " +
                "LEFT OUTER JOIN rols ON u.rolId = rols.id " +
                "LEFT OUTER JOIN departments AS dep ON u.depId = dep.id " +
                "LEFT OUTER JOIN titles ON u.titId = titles.id " +
                "LEFT OUTER JOIN actives ON u.actId = actives.id " +
                "WHERE u.actId=1 ";

            colName = "u.mail";
            idCol = "mail";
            tableName = "users";
            id = 0;
            label1.Text = "Kullanıcı Maili ile Arama Yapın:";
            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
            visibleTrueSearch();
        } 

        private void departmanListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "SELECT id as '#', depName as 'Departman', shortName as 'Kısa Ad' FROM departments " +
                "WHERE actId = 1 ";
            colName = "depName";
            tableName = "departments";
            id = 0;
            idCol = "id";
            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
            label1.Text = "Departman Adıyla Arama Yapın:"; 
            visibleTrueSearch();
        }

        private void rolleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "SELECT id as '#', rolName as 'Rol' FROM rols " +
                "WHERE actId = 1 ";
            colName = "rolName";
            tableName = "rols";
            id = 0;
            idCol = "id";

            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
            label1.Text = "Rol Adıyla Arama Yapın:";
            visibleTrueSearch();
        }

        private void titleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "SELECT id as '#', title as 'Ünvan' FROM titles " +
                "WHERE actId = 1 ";
            colName = "title";
            tableName = "titles";
            id = 0;
            idCol = "id";

            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
            label1.Text = "Ünvanla Arama Yapın:";
            visibleTrueSearch();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            visibleTrueAction();

        }

        private void UbsForm_Load(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            InsertUser insertUser = new InsertUser();
            insertUser.Show();
        }
         
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateUserForm update = new updateUserForm();
            update.Show();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string data = dataGridView1.CurrentRow.Cells[id].Value.ToString();
            command = " WHERE " + idCol + "='" + data + "'";

            if (colName == "u.mail")
            {
                UpdateUser update = new UpdateUser();
                update.mail = data;
                update.Show();
            }
            else if (colName == "name")
            {
                UpdateLessonsForm update = new UpdateLessonsForm();
                update.id = data;
                update.Show();
            }
            else if (colName == "depName")
            {
                UpdateDepartmentForm update = new UpdateDepartmentForm();
                update.data = data;
                update.Show();
            }
            else
            {
                UpdateForm update = new UpdateForm();
                update.query = query;
                update.data = data;
                update.command = command;
                update.colName = colName;
                update.tableName = tableName;
                update.Show();
            }
        }

        private void depAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertDepartmentForm insert = new InsertDepartmentForm(); 
            insert.Show();
        }

        private void rolAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertForm insert = new InsertForm();
            insert.query = "SELECT * FROM rols";
            insert.colName = "rolName";
            insert.tableName = "rols";
            insert.Show();
        }

        private void titleAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertForm insert = new InsertForm();
            insert.query = "SELECT * FROM titles";
            insert.colName = "title";
            insert.tableName = "titles";
            insert.Show();
        }

        private void lessonAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLesson insert = new InsertLesson();
            insert.Show();
        }

        private void lessonListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "SELECT lessons.id as '#', lessons.name as 'Ders Adı', lessons.code as 'Ders Kodu', dep.depName as 'Departman Adı', " +
                "dep.shortName as 'Departman Kısa Adı', " +
                "per.period as 'Dönem', akts.akts as 'AKTS', users.mail as 'Öğretim Görevlisi' " +
                "FROM lessons " +
                "LEFT OUTER JOIN departments AS dep ON lessons.depId=dep.id " +
                "LEFT OUTER JOIN periods AS per ON lessons.periodId=per.id " +
                "LEFT OUTER JOIN akts ON lessons.aktsId=akts.id " +
                "LEFT OUTER JOIN users ON lessons.lecturerMail=users.mail " +
                "WHERE lessons.actId=1 ";
            colName = "name";
            tableName = "lessons";
            id = 0;
            idCol = "id";
            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
            label1.Text = "Ders Adıyla Arama Yapın:";
            visibleTrueSearch();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            UpdateOperations del = new UpdateOperations();
            del.deleteRow("UPDATE "+ tableName +" set actId=0 WHERE "+ idCol +"='"+ dataGridView1.CurrentRow.Cells[id].Value.ToString() +"'");
            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, query);
        }

        private void visibleTrueSearch()
        {
            searchTxt.Visible = true;
            label1.Visible = true;
            searchButton.Visible = true;
        }

        private void visibleTrueAction()
        {
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchQuery;
             
            if (colName == "name")
            {
                searchQuery = query + " AND lessons.name LIKE '%" + searchTxt.Text.Trim() + "%'";
            }
            else
            {
                searchQuery = query + " AND " + colName + " LIKE '%" + searchTxt.Text.Trim() + "%'";
            }
            UserOperations user = new UserOperations();
            user.ListDg(dataGridView1, searchQuery);
        }
    }
}
