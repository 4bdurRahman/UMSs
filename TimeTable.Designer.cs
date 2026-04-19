namespace EducationalInstituteManagementSystem
{
    partial class TimeTable
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtTimetableId = new System.Windows.Forms.TextBox();
            this.lblTimetableId = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvTimetable = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbFilterDay = new System.Windows.Forms.ComboBox();
            this.lblFilterDay = new System.Windows.Forms.Label();
            this.cmbFilterClass = new System.Windows.Forms.ComboBox();
            this.lblFilterClass = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(367, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 43);
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
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(247, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(7, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 43);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Location = new System.Drawing.Point(13, 443);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(480, 62);
            this.panelButtons.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(127, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 43);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "hh:mm tt";
            this.dtpEndTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(133, 283);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(319, 30);
            this.dtpEndTime.TabIndex = 15;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndTime.Location = new System.Drawing.Point(20, 289);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(74, 20);
            this.lblEndTime.TabIndex = 14;
            this.lblEndTime.Text = "End Time:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "hh:mm tt";
            this.dtpStartTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(133, 240);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(319, 30);
            this.dtpStartTime.TabIndex = 13;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartTime.Location = new System.Drawing.Point(20, 246);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(80, 20);
            this.lblStartTime.TabIndex = 12;
            this.lblStartTime.Text = "Start Time:";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.dtpEndTime);
            this.groupBoxDetails.Controls.Add(this.lblEndTime);
            this.groupBoxDetails.Controls.Add(this.dtpStartTime);
            this.groupBoxDetails.Controls.Add(this.lblStartTime);
            this.groupBoxDetails.Controls.Add(this.cmbTeacher);
            this.groupBoxDetails.Controls.Add(this.lblTeacher);
            this.groupBoxDetails.Controls.Add(this.cmbSubject);
            this.groupBoxDetails.Controls.Add(this.lblSubject);
            this.groupBoxDetails.Controls.Add(this.cmbDay);
            this.groupBoxDetails.Controls.Add(this.lblDay);
            this.groupBoxDetails.Controls.Add(this.cmbSection);
            this.groupBoxDetails.Controls.Add(this.lblSection);
            this.groupBoxDetails.Controls.Add(this.cmbClass);
            this.groupBoxDetails.Controls.Add(this.lblClass);
            this.groupBoxDetails.Controls.Add(this.txtTimetableId);
            this.groupBoxDetails.Controls.Add(this.lblTimetableId);
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxDetails.Location = new System.Drawing.Point(13, 12);
            this.groupBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDetails.Size = new System.Drawing.Size(480, 418);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Timetable Details";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(133, 197);
            this.cmbTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(319, 31);
            this.cmbTeacher.TabIndex = 11;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTeacher.Location = new System.Drawing.Point(20, 203);
            this.lblTeacher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(63, 20);
            this.lblTeacher.TabIndex = 10;
            this.lblTeacher.Text = "Teacher:";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(133, 154);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(319, 31);
            this.cmbSubject.TabIndex = 9;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubject.Location = new System.Drawing.Point(20, 160);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(67, 20);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "Subject:*";
            // 
            // cmbDay
            // 
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(133, 111);
            this.cmbDay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(319, 31);
            this.cmbDay.TabIndex = 7;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDay.Location = new System.Drawing.Point(20, 117);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(44, 20);
            this.lblDay.TabIndex = 6;
            this.lblDay.Text = "Day:*";
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(360, 68);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(92, 31);
            this.cmbSection.TabIndex = 5;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSection.Location = new System.Drawing.Point(280, 74);
            this.lblSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(67, 20);
            this.lblSection.TabIndex = 4;
            this.lblSection.Text = "Section:*";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(133, 68);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(132, 31);
            this.cmbClass.TabIndex = 3;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClass.Location = new System.Drawing.Point(20, 74);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(51, 20);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Class:*";
            // 
            // txtTimetableId
            // 
            this.txtTimetableId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtTimetableId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimetableId.Location = new System.Drawing.Point(133, 31);
            this.txtTimetableId.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimetableId.Name = "txtTimetableId";
            this.txtTimetableId.ReadOnly = true;
            this.txtTimetableId.Size = new System.Drawing.Size(319, 30);
            this.txtTimetableId.TabIndex = 1;
            // 
            // lblTimetableId
            // 
            this.lblTimetableId.AutoSize = true;
            this.lblTimetableId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimetableId.Location = new System.Drawing.Point(20, 37);
            this.lblTimetableId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimetableId.Name = "lblTimetableId";
            this.lblTimetableId.Size = new System.Drawing.Size(27, 20);
            this.lblTimetableId.TabIndex = 0;
            this.lblTimetableId.Text = "ID:";
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.Controls.Add(this.dgvTimetable);
            this.panelGrid.Controls.Add(this.panelFilter);
            this.panelGrid.Location = new System.Drawing.Point(566, 48);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(920, 640);
            this.panelGrid.TabIndex = 7;
            // 
            // dgvTimetable
            // 
            this.dgvTimetable.AllowUserToAddRows = false;
            this.dgvTimetable.AllowUserToDeleteRows = false;
            this.dgvTimetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimetable.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimetable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetable.Location = new System.Drawing.Point(13, 74);
            this.dgvTimetable.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimetable.MultiSelect = false;
            this.dgvTimetable.Name = "dgvTimetable";
            this.dgvTimetable.ReadOnly = true;
            this.dgvTimetable.RowHeadersVisible = false;
            this.dgvTimetable.RowHeadersWidth = 51;
            this.dgvTimetable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimetable.Size = new System.Drawing.Size(893, 554);
            this.dgvTimetable.TabIndex = 1;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.cmbFilterDay);
            this.panelFilter.Controls.Add(this.lblFilterDay);
            this.panelFilter.Controls.Add(this.cmbFilterClass);
            this.panelFilter.Controls.Add(this.lblFilterClass);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Location = new System.Drawing.Point(13, 12);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(893, 55);
            this.panelFilter.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(533, 9);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(133, 37);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // cmbFilterDay
            // 
            this.cmbFilterDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterDay.FormattingEnabled = true;
            this.cmbFilterDay.Location = new System.Drawing.Point(347, 12);
            this.cmbFilterDay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterDay.Name = "cmbFilterDay";
            this.cmbFilterDay.Size = new System.Drawing.Size(159, 28);
            this.cmbFilterDay.TabIndex = 4;
            // 
            // lblFilterDay
            // 
            this.lblFilterDay.AutoSize = true;
            this.lblFilterDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterDay.Location = new System.Drawing.Point(293, 17);
            this.lblFilterDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterDay.Name = "lblFilterDay";
            this.lblFilterDay.Size = new System.Drawing.Size(38, 20);
            this.lblFilterDay.TabIndex = 3;
            this.lblFilterDay.Text = "Day:";
            // 
            // cmbFilterClass
            // 
            this.cmbFilterClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterClass.FormattingEnabled = true;
            this.cmbFilterClass.Location = new System.Drawing.Point(173, 12);
            this.cmbFilterClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterClass.Name = "cmbFilterClass";
            this.cmbFilterClass.Size = new System.Drawing.Size(105, 28);
            this.cmbFilterClass.TabIndex = 2;
            // 
            // lblFilterClass
            // 
            this.lblFilterClass.AutoSize = true;
            this.lblFilterClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterClass.Location = new System.Drawing.Point(113, 17);
            this.lblFilterClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterClass.Name = "lblFilterClass";
            this.lblFilterClass.Size = new System.Drawing.Size(45, 20);
            this.lblFilterClass.TabIndex = 1;
            this.lblFilterClass.Text = "Class:";
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
            this.panelForm.Location = new System.Drawing.Point(51, 48);
            this.panelForm.Margin = new System.Windows.Forms.Padding(4);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(507, 517);
            this.panelForm.TabIndex = 6;
            // 
            // TimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 737);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelForm);
            this.Name = "TimeTable";
            this.Text = "TimeTable";
            this.Load += new System.EventHandler(this.TimeTable_Load);
            this.panelButtons.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetable)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtTimetableId;
        private System.Windows.Forms.Label lblTimetableId;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvTimetable;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbFilterDay;
        private System.Windows.Forms.Label lblFilterDay;
        private System.Windows.Forms.ComboBox cmbFilterClass;
        private System.Windows.Forms.Label lblFilterClass;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelForm;
    }
}