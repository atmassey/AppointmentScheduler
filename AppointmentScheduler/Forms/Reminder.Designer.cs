namespace AppointmentScheduler.Forms
{
    partial class Reminder
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
            this.ReminderGrid = new System.Windows.Forms.DataGridView();
            this.ReminderTitle = new System.Windows.Forms.Label();
            this.DismissBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReminderGrid
            // 
            this.ReminderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReminderGrid.Location = new System.Drawing.Point(12, 90);
            this.ReminderGrid.Name = "ReminderGrid";
            this.ReminderGrid.Size = new System.Drawing.Size(776, 275);
            this.ReminderGrid.TabIndex = 0;
            // 
            // ReminderTitle
            // 
            this.ReminderTitle.AutoSize = true;
            this.ReminderTitle.ForeColor = System.Drawing.Color.Red;
            this.ReminderTitle.Location = new System.Drawing.Point(351, 62);
            this.ReminderTitle.Name = "ReminderTitle";
            this.ReminderTitle.Size = new System.Drawing.Size(117, 13);
            this.ReminderTitle.TabIndex = 1;
            this.ReminderTitle.Text = "Appointment Reminder!";
            // 
            // DismissBtn
            // 
            this.DismissBtn.Location = new System.Drawing.Point(647, 371);
            this.DismissBtn.Name = "DismissBtn";
            this.DismissBtn.Size = new System.Drawing.Size(141, 23);
            this.DismissBtn.TabIndex = 2;
            this.DismissBtn.Text = "Dismiss";
            this.DismissBtn.UseVisualStyleBackColor = true;
            this.DismissBtn.Click += new System.EventHandler(this.DismissBtn_Click);
            // 
            // Reminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DismissBtn);
            this.Controls.Add(this.ReminderTitle);
            this.Controls.Add(this.ReminderGrid);
            this.Name = "Reminder";
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Reminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReminderGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReminderGrid;
        private System.Windows.Forms.Label ReminderTitle;
        private System.Windows.Forms.Button DismissBtn;
    }
}