using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetNuke.Social.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            if (!Program.CredentialRepository.Default.IsValid)
            {
                Forms.LoginForm login = new Forms.LoginForm();
                login.ShowDialog();
            }
            else
            {
                bool goodUser = Controllers.DNNProxy.Authenticate(Program.UserContext.Credentials);
                if (!goodUser)
                {
                    Forms.LoginForm login = new Forms.LoginForm();
                    login.ShowDialog();
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNProxy.CountNotifications(Program.UserContext.Credentials);
        }

        private void InboxButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNProxy.Inbox(Program.UserContext.Credentials, null, null);
        }
    }
}
