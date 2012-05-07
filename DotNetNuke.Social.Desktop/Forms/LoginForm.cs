using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetNuke.Social.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            Models.Credential c = Program.CredentialRepository.Default;

            this.urlTextbox.Text = c.Site;
            this.usernameTextbox.Text = c.Username;
            this.passwordTextbox.Text = c.Password;


        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Models.Credential c = new Models.Credential();
            c.Site = this.urlTextbox.Text;
            c.Username = this.usernameTextbox.Text;
            c.Password = this.passwordTextbox.Text;

            try
            {

                bool goodUser = Controllers.DNNProxy.Authenticate(c);

                Program.CredentialRepository.AddCredential(c);
                Program.UserContext.Credentials = c;

                return;

            }
            catch (Exception exc)
            {
                MessageBox.Show("There was an error processing your login, please try again.");
            }



        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
