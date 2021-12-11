using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace cbu
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        DbOperations db = new DbOperations();
        UserOperations user = new UserOperations();

        public static string mail { get; set; }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string pass = user.passCrypto(txtPassword.Text.Trim());
            mail = txtMail.Text.Trim();
            bool logInControl = db.LogInControl(mail, pass);

            if (logInControl)
            {
                db.UserSelect(mail);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "LogIn Form", MessageBoxButtons.OK);
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            db.DbConnect();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

    }
}
