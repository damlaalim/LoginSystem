using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace cbu
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        DbOperations db = new DbOperations();
        LogInForm logInForm = new LogInForm();

        private void registerBtn_Click(object sender, EventArgs e)
        {
            switch (db.RegisterControl(mailTxt.Text.Trim()))
            {
                case true:
                    string password = generatePassword();

                    switch (mailGonder(password))
                    {
                        case true:
                            switch (insertPass(password))
                            {
                                case true:
                                    logInForm.Show();
                                    this.Hide();
                                    break; 
                            }
                            break;
                    } 
                    break;
                default:
                    MessageBox.Show("hatalı giriş");
                    break;
            } 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logInForm.Show();
            this.Hide();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            db.DbConnect();
        }

        private bool mailGonder(string password)
        { 
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("gönderen@gmail.com");
                message.To.Add(new MailAddress(mailTxt.Text.Trim()));
                message.Subject = "Giriş Sistemi Şifreniz: ";
                message.IsBodyHtml = true; 
                message.Body = "Şifrenizi güncellemeyi unutmayın ve kimseyle paylaşmayın!.. Giriş şifreniz: " + password;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("gönderen@gmail.com", "gönderen şifresi");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                MessageBox.Show("Şifreniz mailinize gönderilmiştir.");
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Şifre Gönderilirken bir sorunla karşılaştık.. " + ex);
                return false; 
            }
        }

        private string generatePassword()
        {
            string password = Membership.GeneratePassword(12, 0);
            password = Regex.Replace(password, @"[^a-zA-Z0-9]", m => "9");
            return password;
        }

        private bool insertPass(string pass)
        {
            UserOperations user = new UserOperations();
            string cryptoPass = user.passCrypto(pass);
            string query = "UPDATE users SET password='" + cryptoPass + "', actId=1 WHERE mail='" + mailTxt.Text.Trim() + "'";

            UpdateOperations update = new UpdateOperations();
            return update.updateRow(query);
        }
    }
}
