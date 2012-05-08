namespace DotNetNuke.Social.Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.refreshButton = new System.Windows.Forms.Button();
            this.InboxButton = new System.Windows.Forms.Button();
            this.notificationsButton = new System.Windows.Forms.Button();
            this.journalItemsButton = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 32);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(121, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh Counts";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // InboxButton
            // 
            this.InboxButton.Location = new System.Drawing.Point(12, 3);
            this.InboxButton.Name = "InboxButton";
            this.InboxButton.Size = new System.Drawing.Size(121, 23);
            this.InboxButton.TabIndex = 1;
            this.InboxButton.Text = "Refresh Inbox";
            this.InboxButton.UseVisualStyleBackColor = true;
            this.InboxButton.Click += new System.EventHandler(this.InboxButton_Click);
            // 
            // notificationsButton
            // 
            this.notificationsButton.Location = new System.Drawing.Point(12, 61);
            this.notificationsButton.Name = "notificationsButton";
            this.notificationsButton.Size = new System.Drawing.Size(121, 23);
            this.notificationsButton.TabIndex = 2;
            this.notificationsButton.Text = "Notifications";
            this.notificationsButton.UseVisualStyleBackColor = true;
            this.notificationsButton.Click += new System.EventHandler(this.notificationsButton_Click);
            // 
            // journalItemsButton
            // 
            this.journalItemsButton.Location = new System.Drawing.Point(12, 90);
            this.journalItemsButton.Name = "journalItemsButton";
            this.journalItemsButton.Size = new System.Drawing.Size(121, 23);
            this.journalItemsButton.TabIndex = 3;
            this.journalItemsButton.Text = "Journal Items";
            this.journalItemsButton.UseVisualStyleBackColor = true;
            this.journalItemsButton.Click += new System.EventHandler(this.journalItemsButton_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(143, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(795, 480);
            this.propertyGrid1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.journalItemsButton);
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.InboxButton);
            this.panel1.Controls.Add(this.notificationsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 480);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 480);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button InboxButton;
        private System.Windows.Forms.Button notificationsButton;
        private System.Windows.Forms.Button journalItemsButton;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
    }
}

