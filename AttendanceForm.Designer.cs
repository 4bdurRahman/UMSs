namespace EducationalManagementSystem
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Attendance Management";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(900, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.groupBoxDetails);
            this.panelForm.Controls.Add(this.panelButtons);
            this.panelForm.Location = new System.Drawing.Point(10, 70);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(350, 280);
            this.panelForm.TabIndex = 1;
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
            this.groupBoxDetails.Location = new System.Drawing.Point(10, 10);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(330, 200);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Attendance Details";
            // 
            // lblAttendanceId
            // 
            this.lblAttendanceId.AutoSize = true;
            this.lblAttendanceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttendanceId.Location = new System.Drawing.Point(15, 30);
            this.lblAttendanceId.Name = "lblAttendanceId";
            this.lblAttendanceId.Size = new System.Drawing.Size(22, 15);
            this.lblAttendanceId.TabIndex = 0;
            this.lblAttendanceId.Text = "ID:";
            // 
            // txtAttendanceId
            // 
            this.txtAttendanceId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtAttendanceId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAttendanceId.Location = new System.Drawing.Point(100, 25);
            this.txtAttendanceId.Name = "txtAttendanceId";
            this.txtAttendanceId.ReadOnly = true;
            this.txtAttendanceId.Size = new System.Drawing.Size(210, 25);
            this.txtAttendanceId.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudent.Location = new System.Drawing.Point(15, 60);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(57, 15);
            this.lblStudent.TabIndex = 2;
            this.lblStudent.Text = "Student:*";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(100, 55);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(210, 25);
            this.cmbStudent.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.Location = new System.Drawing.Point(15, 95);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 15);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(100, 90);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(210, 25);
            this.dtpAttendanceDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(15, 130);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 15);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:*";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(100, 125);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(210, 25);
            this.cmbStatus.TabIndex = 7;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnMarkAttendance);
            this.panelButtons.Location = new System.Drawing.Point(10, 220);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(330, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnMarkAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkAttendance.FlatAppearance.BorderSize = 0;
            this.btnMarkAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAttendance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.White;
            this.btnMarkAttendance.Location = new System.Drawing.Point(5, 5);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(75, 35);
            this.btnMarkAttendance.TabIndex = 0;
            this.btnMarkAttendance.Text = "✓ Mark";
            this.btnMarkAttendance.UseVisualStyleBackColor = false;
            this.btnMarkAttendance.Click += new System.EventHandler(this.btnMarkAttendance_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(85, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(165, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(245, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.Controls.Add(this.dgvAttendance);
            this.panelGrid.Controls.Add(this.panelFilter);
            this.panelGrid.Location = new System.Drawing.Point(370, 70);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(620, 520);
            this.panelGrid.TabIndex = 2;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.cmbSection);
            this.panelFilter.Controls.Add(this.lblSection);
            this.panelFilter.Controls.Add(this.cmbClass);
            this.panelFilter.Controls.Add(this.lblClass);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Location = new System.Drawing.Point(10, 10);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(600, 45);
            this.panelFilter.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFilter.Location = new System.Drawing.Point(5, 12);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(67, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter By:";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClass.Location = new System.Drawing.Point(85, 14);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(37, 15);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "Class:";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(130, 10);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(80, 23);
            this.cmbClass.TabIndex = 2;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSection.Location = new System.Drawing.Point(220, 14);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(49, 15);
            this.lblSection.TabIndex = 3;
            this.lblSection.Text = "Section:";
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(275, 10);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(80, 23);
            this.cmbSection.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(370, 7);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 30);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(10, 60);
            this.dgvAttendance.MultiSelect = false;
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(600, 450);
            this.dgvAttendance.TabIndex = 1;
            this.dgvAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellClick);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Management";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblAttendanceId;
        private System.Windows.Forms.TextBox txtAttendanceId;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvAttendance;
    }
}
