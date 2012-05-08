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
                bool goodUser = Controllers.DNNController.Authenticate(Program.UserContext.Credentials);
                if (!goodUser)
                {
                    Forms.LoginForm login = new Forms.LoginForm();
                    login.ShowDialog();
                }
            }

            this.propertyGrid1.SelectedObject = Program.UserContext;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNController.CountNotifications(Program.UserContext.Credentials);
            this.propertyGrid1.Update();
        }

        private void InboxButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNController.Inbox(Program.UserContext.Credentials, null, null);
            this.propertyGrid1.Update();
        }

        private void notificationsButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNController.Notifications(Program.UserContext.Credentials, null, null);
            this.propertyGrid1.Update();
        }

        private void journalItemsButton_Click(object sender, EventArgs e)
        {
            Controllers.DNNController.JournalList(Program.UserContext.Credentials, null, null);
            this.propertyGrid1.Update();
        }
    }
}
