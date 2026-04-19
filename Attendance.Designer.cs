namespace EducationalInstituteManagementSystem
{
    partial class Attendance
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
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.txtAttendanceId = new System.Windows.Forms.TextBox();
            this.lblAttendanceId = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnMarkAttendance = new System.Windows.Forms.Button();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.Controls.Add(this.dgvAttendance);
            this.panelGrid.Controls.Add(this.panelFilter);
            this.panelGrid.Location = new System.Drawing.Point(490, 32);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(827, 640);
            this.panelGrid.TabIndex = 4;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(13, 74);
            this.dgvAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAttendance.MultiSelect = false;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(800, 554);
            this.dgvAttendance.TabIndex = 1;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.cmbSection);
            this.panelFilter.Controls.Add(this.lblSection);
            this.panelFilter.Controls.Add(this.cmbClass);
            this.panelFilter.Controls.Add(this.lblClass);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Location = new System.Drawing.Point(13, 12);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(800, 55);
            this.panelFilter.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(493, 9);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(133, 37);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(367, 12);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(105, 28);
            this.cmbSection.TabIndex = 4;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSection.Location = new System.Drawing.Point(293, 17);
            this.lblSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(61, 20);
            this.lblSection.TabIndex = 3;
            this.lblSection.Text = "Section:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(173, 12);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(105, 28);
            this.cmbClass.TabIndex = 2;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClass.Location = new System.Drawing.Point(113, 17);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(45, 20);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "Class:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFilter.Location = new System.Drawing.Point(7, 15);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(82, 23);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter By:";
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.groupBoxDetails);
            this.panelForm.Controls.Add(this.panelButtons);
            this.panelForm.Location = new System.Drawing.Point(6, 32);
            this.panelForm.Margin = new System.Windows.Forms.Padding(4);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(467, 345);
            this.panelForm.TabIndex = 3;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.cmbStatus);
            this.groupBoxDetails.Controls.Add(this.lblStatus);
            this.groupBoxDetails.Controls.Add(this.dtpAttendanceDate);
            this.groupBoxDetails.Controls.Add(this.lblDate);
            this.groupBoxDetails.Controls.Add(this.cmbStudent);
            this.groupBoxDetails.Controls.Add(this.lblStudent);
            this.groupBoxDetails.Controls.Add(this.txtAttendanceId);
            this.groupBoxDetails.Controls.Add(this.lblAttendanceId);
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxDetails.Location = new System.Drawing.Point(27, 12);
            this.groupBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Size = new System.Drawing.Size(440, 246);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Attendance Details";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(133, 154);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(279, 31);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(20, 160);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:*";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(133, 111);
            this.dtpAttendanceDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(279, 30);
            this.dtpAttendanceDate.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.Location = new System.Drawing.Point(20, 117);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(133, 68);
            this.cmbStudent.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(279, 31);
            this.cmbStudent.TabIndex = 3;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudent.Location = new System.Drawing.Point(20, 74);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(69, 20);
            this.lblStudent.TabIndex = 2;
            this.lblStudent.Text = "Student:*";
            // 
            // txtAttendanceId
            // 
            this.txtAttendanceId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtAttendanceId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAttendanceId.Location = new System.Drawing.Point(133, 31);
            this.txtAttendanceId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttendanceId.Name = "txtAttendanceId";
            this.txtAttendanceId.ReadOnly = true;
            this.txtAttendanceId.Size = new System.Drawing.Size(279, 30);
            this.txtAttendanceId.TabIndex = 1;
            // 
            // lblAttendanceId
            // 
            this.lblAttendanceId.AutoSize = true;
            this.lblAttendanceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttendanceId.Location = new System.Drawing.Point(20, 37);
            this.lblAttendanceId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttendanceId.Name = "lblAttendanceId";
            this.lblAttendanceId.Size = new System.Drawing.Size(27, 20);
            this.lblAttendanceId.TabIndex = 0;
            this.lblAttendanceId.Text = "ID:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnMarkAttendance);
            this.panelButtons.Location = new System.Drawing.Point(23, 266);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(440, 62);
            this.panelButtons.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(327, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 43);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(220, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(113, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 43);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnMarkAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkAttendance.FlatAppearance.BorderSize = 0;
            this.btnMarkAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAttendance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.White;
            this.btnMarkAttendance.Location = new System.Drawing.Point(7, 6);
            this.btnMarkAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(100, 43);
            this.btnMarkAttendance.TabIndex = 0;
            this.btnMarkAttendance.Text = "✓ Mark";
            this.btnMarkAttendance.UseVisualStyleBackColor = false;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 704);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelForm);
            this.Name = "Attendance";
            this.Text = "Attendance";
//            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtAttendanceId;
        private System.Windows.Forms.Label lblAttendanceId;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnMarkAttendance;
    }
}