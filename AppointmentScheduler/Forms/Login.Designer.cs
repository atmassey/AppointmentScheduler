﻿namespace AppointmentScheduler.Forms
{
    partial class Login
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
            this.LocationLabel = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.Label();
            this.LoginUsername = new System.Windows.Forms.TextBox();
            this.LoginPassword = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.EnglishBtn = new System.Windows.Forms.RadioButton();
            this.TurkishBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(12, 9);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(51, 13);
            this.LocationLabel.TabIndex = 0;
            this.LocationLabel.Text = "Location:";
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(69, 9);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(10, 13);
            this.Location.TabIndex = 1;
            this.Location.Text = " ";
            // 
            // LoginUsername
            // 
            this.LoginUsername.Location = new System.Drawing.Point(182, 139);
            this.LoginUsername.Name = "LoginUsername";
            this.LoginUsername.Size = new System.Drawing.Size(215, 20);
            this.LoginUsername.TabIndex = 2;
            // 
            // LoginPassword
            // 
            this.LoginPassword.Location = new System.Drawing.Point(182, 202);
            this.LoginPassword.Name = "LoginPassword";
            this.LoginPassword.PasswordChar = '*';
            this.LoginPassword.Size = new System.Drawing.Size(215, 20);
            this.LoginPassword.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(182, 262);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(215, 23);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(182, 107);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(182, 183);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(159, 44);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(261, 24);
            this.TitleLabel.TabIndex = 7;
            this.TitleLabel.Text = "Appointment Scheduler Login";
            // 
            // EnglishBtn
            // 
            this.EnglishBtn.AutoSize = true;
            this.EnglishBtn.Location = new System.Drawing.Point(15, 318);
            this.EnglishBtn.Name = "EnglishBtn";
            this.EnglishBtn.Size = new System.Drawing.Size(59, 17);
            this.EnglishBtn.TabIndex = 8;
            this.EnglishBtn.TabStop = true;
            this.EnglishBtn.Text = "English";
            this.EnglishBtn.UseVisualStyleBackColor = true;
            this.EnglishBtn.Click += new System.EventHandler(this.EnglishBtn_Click);
            // 
            // TurkishBtn
            // 
            this.TurkishBtn.AutoSize = true;
            this.TurkishBtn.Location = new System.Drawing.Point(81, 318);
            this.TurkishBtn.Name = "TurkishBtn";
            this.TurkishBtn.Size = new System.Drawing.Size(60, 17);
            this.TurkishBtn.TabIndex = 9;
            this.TurkishBtn.TabStop = true;
            this.TurkishBtn.Text = "Turkish";
            this.TurkishBtn.UseVisualStyleBackColor = true;
            this.TurkishBtn.Click += new System.EventHandler(this.TurkishBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 347);
            this.Controls.Add(this.TurkishBtn);
            this.Controls.Add(this.EnglishBtn);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.LoginPassword);
            this.Controls.Add(this.LoginUsername);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.LocationLabel);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.TextBox LoginUsername;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.RadioButton EnglishBtn;
        private System.Windows.Forms.RadioButton TurkishBtn;
    }
}