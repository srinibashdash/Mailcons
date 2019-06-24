namespace CredentialManager
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtGmailUser = new System.Windows.Forms.TextBox();
            this.txtGmailPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGmailName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutlookUser = new System.Windows.Forms.TextBox();
            this.txtOutlookName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApplicationPath = new System.Windows.Forms.TextBox();
            this.txtReportIssueEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(202, 275);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(67, 36);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGmailUser
            // 
            this.txtGmailUser.Location = new System.Drawing.Point(83, 35);
            this.txtGmailUser.Name = "txtGmailUser";
            this.txtGmailUser.Size = new System.Drawing.Size(186, 20);
            this.txtGmailUser.TabIndex = 1;
            // 
            // txtGmailPwd
            // 
            this.txtGmailPwd.Location = new System.Drawing.Point(83, 61);
            this.txtGmailPwd.Name = "txtGmailPwd";
            this.txtGmailPwd.PasswordChar = '*';
            this.txtGmailPwd.Size = new System.Drawing.Size(186, 20);
            this.txtGmailPwd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "UserId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // txtGmailName
            // 
            this.txtGmailName.Location = new System.Drawing.Point(144, 9);
            this.txtGmailName.Name = "txtGmailName";
            this.txtGmailName.ReadOnly = true;
            this.txtGmailName.Size = new System.Drawing.Size(68, 20);
            this.txtGmailName.TabIndex = 1;
            this.txtGmailName.Text = "mc_gmail.com";
            this.txtGmailName.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "UserId";
            // 
            // txtOutlookUser
            // 
            this.txtOutlookUser.Location = new System.Drawing.Point(83, 138);
            this.txtOutlookUser.Name = "txtOutlookUser";
            this.txtOutlookUser.Size = new System.Drawing.Size(186, 20);
            this.txtOutlookUser.TabIndex = 3;
            // 
            // txtOutlookName
            // 
            this.txtOutlookName.Location = new System.Drawing.Point(140, 99);
            this.txtOutlookName.Name = "txtOutlookName";
            this.txtOutlookName.ReadOnly = true;
            this.txtOutlookName.Size = new System.Drawing.Size(68, 20);
            this.txtOutlookName.TabIndex = 9;
            this.txtOutlookName.Text = "mc_outlook";
            this.txtOutlookName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Source : Gmail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Source : Outlook";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "You outlook must be configured with this user";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Invoke Application path";
            // 
            // txtApplicationPath
            // 
            this.txtApplicationPath.Location = new System.Drawing.Point(12, 195);
            this.txtApplicationPath.Name = "txtApplicationPath";
            this.txtApplicationPath.ReadOnly = true;
            this.txtApplicationPath.Size = new System.Drawing.Size(256, 20);
            this.txtApplicationPath.TabIndex = 4;
            this.txtApplicationPath.DoubleClick += new System.EventHandler(this.txtApplicationPath_DoubleClick);
            // 
            // txtReportIssueEmail
            // 
            this.txtReportIssueEmail.Location = new System.Drawing.Point(12, 234);
            this.txtReportIssueEmail.Name = "txtReportIssueEmail";
            this.txtReportIssueEmail.Size = new System.Drawing.Size(256, 20);
            this.txtReportIssueEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Report Issue email";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 323);
            this.Controls.Add(this.txtReportIssueEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtApplicationPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOutlookUser);
            this.Controls.Add(this.txtOutlookName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGmailPwd);
            this.Controls.Add(this.txtGmailUser);
            this.Controls.Add(this.txtGmailName);
            this.Controls.Add(this.btnUpdate);
            this.Name = "Form1";
            this.Text = "Set MailConsolidator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtGmailUser;
        private System.Windows.Forms.TextBox txtGmailPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGmailName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutlookUser;
        private System.Windows.Forms.TextBox txtOutlookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApplicationPath;
        private System.Windows.Forms.TextBox txtReportIssueEmail;
        private System.Windows.Forms.Label label6;
    }
}

