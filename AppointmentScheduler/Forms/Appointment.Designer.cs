namespace AppointmentScheduler.Forms
{
    partial class Appointment
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppointmentGrid = new System.Windows.Forms.DataGridView();
            this.CustomerDropdown = new System.Windows.Forms.ComboBox();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.TableTitle = new System.Windows.Forms.Label();
            this.TimeSelector = new System.Windows.Forms.DateTimePicker();
            this.DateSelector = new System.Windows.Forms.DateTimePicker();
            this.DurationDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeDropdown = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TitleField = new System.Windows.Forms.TextBox();
            this.URLField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DescriptionField = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripMenuItem,
            this.mainToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CurrentUser
            // 
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(0, 17);
            // 
            // AppointmentGrid
            // 
            this.AppointmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentGrid.Location = new System.Drawing.Point(391, 57);
            this.AppointmentGrid.Name = "AppointmentGrid";
            this.AppointmentGrid.Size = new System.Drawing.Size(652, 555);
            this.AppointmentGrid.TabIndex = 2;
            // 
            // CustomerDropdown
            // 
            this.CustomerDropdown.FormattingEnabled = true;
            this.CustomerDropdown.Location = new System.Drawing.Point(18, 72);
            this.CustomerDropdown.Name = "CustomerDropdown";
            this.CustomerDropdown.Size = new System.Drawing.Size(349, 21);
            this.CustomerDropdown.TabIndex = 3;
            this.CustomerDropdown.DropDown += new System.EventHandler(this.CustomerDropdown_DropDown);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(18, 56);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(51, 13);
            this.CustomerLabel.TabIndex = 4;
            this.CustomerLabel.Text = "Customer";
            // 
            // TableTitle
            // 
            this.TableTitle.AutoSize = true;
            this.TableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableTitle.Location = new System.Drawing.Point(663, 34);
            this.TableTitle.Name = "TableTitle";
            this.TableTitle.Size = new System.Drawing.Size(120, 20);
            this.TableTitle.TabIndex = 5;
            this.TableTitle.Text = "Appointments";
            // 
            // TimeSelector
            // 
            this.TimeSelector.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeSelector.Location = new System.Drawing.Point(268, 127);
            this.TimeSelector.Name = "TimeSelector";
            this.TimeSelector.ShowUpDown = true;
            this.TimeSelector.Size = new System.Drawing.Size(98, 20);
            this.TimeSelector.TabIndex = 6;
            // 
            // DateSelector
            // 
            this.DateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateSelector.Location = new System.Drawing.Point(143, 127);
            this.DateSelector.Name = "DateSelector";
            this.DateSelector.Size = new System.Drawing.Size(98, 20);
            this.DateSelector.TabIndex = 7;
            // 
            // DurationDropdown
            // 
            this.DurationDropdown.FormattingEnabled = true;
            this.DurationDropdown.Location = new System.Drawing.Point(18, 126);
            this.DurationDropdown.Name = "DurationDropdown";
            this.DurationDropdown.Size = new System.Drawing.Size(98, 21);
            this.DurationDropdown.TabIndex = 8;
            this.DurationDropdown.DropDown += new System.EventHandler(this.DurationDropdown_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Duration";
            // 
            // TypeDropdown
            // 
            this.TypeDropdown.FormattingEnabled = true;
            this.TypeDropdown.Location = new System.Drawing.Point(18, 170);
            this.TypeDropdown.Name = "TypeDropdown";
            this.TypeDropdown.Size = new System.Drawing.Size(349, 21);
            this.TypeDropdown.TabIndex = 12;
            this.TypeDropdown.DropDown += new System.EventHandler(this.TypeDropdown_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Title";
            // 
            // TitleField
            // 
            this.TitleField.Location = new System.Drawing.Point(18, 224);
            this.TitleField.Name = "TitleField";
            this.TitleField.Size = new System.Drawing.Size(349, 20);
            this.TitleField.TabIndex = 15;
            // 
            // URLField
            // 
            this.URLField.Location = new System.Drawing.Point(18, 268);
            this.URLField.Name = "URLField";
            this.URLField.Size = new System.Drawing.Size(349, 20);
            this.URLField.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "URL";
            // 
            // DescriptionField
            // 
            this.DescriptionField.Location = new System.Drawing.Point(21, 323);
            this.DescriptionField.Name = "DescriptionField";
            this.DescriptionField.Size = new System.Drawing.Size(345, 96);
            this.DescriptionField.TabIndex = 18;
            this.DescriptionField.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Description";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(21, 434);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 20;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(156, 434);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 21;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(291, 434);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 22;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(21, 479);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(277, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Business Hours: 9:00AM - 5:00 PM E.S.T, Monday-Friday";
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 652);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DescriptionField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.URLField);
            this.Controls.Add(this.TitleField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TypeDropdown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DurationDropdown);
            this.Controls.Add(this.DateSelector);
            this.Controls.Add(this.TimeSelector);
            this.Controls.Add(this.TableTitle);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.CustomerDropdown);
            this.Controls.Add(this.AppointmentGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Appointment_FormClosed);
            this.Load += new System.EventHandler(this.Appointment_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CurrentUser;
        private System.Windows.Forms.DataGridView AppointmentGrid;
        private System.Windows.Forms.ComboBox CustomerDropdown;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label TableTitle;
        private System.Windows.Forms.DateTimePicker TimeSelector;
        private System.Windows.Forms.DateTimePicker DateSelector;
        private System.Windows.Forms.ComboBox DurationDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TypeDropdown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TitleField;
        private System.Windows.Forms.TextBox URLField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox DescriptionField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label10;
    }
}