namespace EducationalInstituteManagementSystem
{
    partial class ManageSubjects
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.btnUpdateSubject = new System.Windows.Forms.Button();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.cmbSubjectTeacher = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.dgvSubjects);
            this.groupBox9.Controls.Add(this.btnUpdateSubject);
            this.groupBox9.Controls.Add(this.btnDeleteSubject);
            this.groupBox9.Controls.Add(this.btnAddSubject);
            this.groupBox9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(32, 31);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(753, 766);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Subjects List";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubjects.ColumnHeadersHeight = 40;
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubjects.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubjects.EnableHeadersVisualStyles = false;
            this.dgvSubjects.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvSubjects.Location = new System.Drawing.Point(17, 34);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvSubjects.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubjects.RowHeadersWidth = 30;
            this.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.Size = new System.Drawing.Size(720, 607);
            this.dgvSubjects.TabIndex = 12;
            // 
            // btnUpdateSubject
            // 
            this.btnUpdateSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUpdateSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSubject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSubject.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSubject.Location = new System.Drawing.Point(267, 677);
            this.btnUpdateSubject.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSubject.Name = "btnUpdateSubject";
            this.btnUpdateSubject.Size = new System.Drawing.Size(200, 50);
            this.btnUpdateSubject.TabIndex = 3;
            this.btnUpdateSubject.Text = "Update Subject";
            this.btnUpdateSubject.UseVisualStyleBackColor = false;
            this.btnUpdateSubject.Click += new System.EventHandler(this.btnUpdateSubject_Click);
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSubject.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSubject.Location = new System.Drawing.Point(507, 677);
            this.btnDeleteSubject.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteSubject.TabIndex = 2;
            this.btnDeleteSubject.Text = "Delete Subject";
            this.btnDeleteSubject.UseVisualStyleBackColor = false;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Location = new System.Drawing.Point(27, 677);
            this.btnAddSubject.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(200, 50);
            this.btnAddSubject.TabIndex = 1;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(35, 46);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(127, 25);
            this.label38.TabIndex = 0;
            this.label38.Text = "Subject Code:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(35, 144);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(133, 25);
            this.label39.TabIndex = 1;
            this.label39.Text = "Subject Name:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(35, 242);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 25);
            this.label40.TabIndex = 2;
            this.label40.Text = "Class:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(35, 341);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(162, 25);
            this.label41.TabIndex = 3;
            this.label41.Text = "Assigned Teacher:";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.Location = new System.Drawing.Point(40, 74);
            this.txtSubjectCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(399, 32);
            this.txtSubjectCode.TabIndex = 4;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.Location = new System.Drawing.Point(40, 172);
            this.txtSubjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(399, 32);
            this.txtSubjectName.TabIndex = 5;
            // 
            // txtClassName
            // 
            this.txtClassName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassName.Location = new System.Drawing.Point(40, 270);
            this.txtClassName.Margin = new System.Windows.Forms.Padding(4);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(399, 32);
            this.txtClassName.TabIndex = 6;
            // 
            // cmbSubjectTeacher
            // 
            this.cmbSubjectTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubjectTeacher.FormattingEnabled = true;
            this.cmbSubjectTeacher.Location = new System.Drawing.Point(40, 370);
            this.cmbSubjectTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSubjectTeacher.Name = "cmbSubjectTeacher";
            this.cmbSubjectTeacher.Size = new System.Drawing.Size(399, 33);
            this.cmbSubjectTeacher.TabIndex = 7;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.cmbSubjectTeacher);
            this.groupBox10.Controls.Add(this.txtClassName);
            this.groupBox10.Controls.Add(this.txtSubjectName);
            this.groupBox10.Controls.Add(this.txtSubjectCode);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(793, 31);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(480, 766);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Subject Details";
            // 
            // ManageSubjects
            // 
            this.ClientSize = new System.Drawing.Size(1305, 836);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Name = "ManageSubjects";
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnUpdateSubject;
        private System.Windows.Forms.Button btnDeleteSubject;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.ComboBox cmbSubjectTeacher;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dgvSubjects;
    }
}