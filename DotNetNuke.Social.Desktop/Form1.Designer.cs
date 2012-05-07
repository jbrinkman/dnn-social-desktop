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
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(184, 147);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(121, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh Counts";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // InboxButton
            // 
            this.InboxButton.Location = new System.Drawing.Point(184, 77);
            this.InboxButton.Name = "InboxButton";
            this.InboxButton.Size = new System.Drawing.Size(121, 23);
            this.InboxButton.TabIndex = 1;
            this.InboxButton.Text = "Refresh Inbox";
            this.InboxButton.UseVisualStyleBackColor = true;
            this.InboxButton.Click += new System.EventHandler(this.InboxButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 316);
            this.Controls.Add(this.InboxButton);
            this.Controls.Add(this.refreshButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button InboxButton;
    }
}

