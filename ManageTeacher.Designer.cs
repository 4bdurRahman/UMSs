namespace EducationalInstituteManagementSystem
{
    partial class ManageTeacher
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.btnUpdateTeacher = new System.Windows.Forms.Button();
            this.btnDeleteTeacher = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtTeacherEmail = new System.Windows.Forms.TextBox();
            this.txtTeacherContact = new System.Windows.Forms.TextBox();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.txtTeacherCode = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.dgvTeachers);
            this.groupBox7.Controls.Add(this.btnUpdateTeacher);
            this.groupBox7.Controls.Add(this.btnDeleteTeacher);
            this.groupBox7.Controls.Add(this.btnAddTeacher);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(24, 25);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(747, 742);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Teachers List";
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.AllowUserToAddRows = false;
            this.dgvTeachers.AllowUserToDeleteRows = false;
            this.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeachers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeachers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTeachers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeachers.ColumnHeadersHeight = 40;
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeachers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeachers.EnableHeadersVisualStyles = false;
            this.dgvTeachers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvTeachers.Location = new System.Drawing.Point(21, 34);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.ReadOnly = true;
            this.dgvTeachers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvTeachers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeachers.RowHeadersWidth = 30;
            this.dgvTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeachers.Size = new System.Drawing.Size(700, 601);
            this.dgvTeachers.TabIndex = 12;
            // 
            // btnUpdateTeacher
            // 
            this.btnUpdateTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUpdateTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTeacher.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTeacher.Location = new System.Drawing.Point(267, 677);
            this.btnUpdateTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateTeacher.Name = "btnUpdateTeacher";
            this.btnUpdateTeacher.Size = new System.Drawing.Size(200, 50);
            this.btnUpdateTeacher.TabIndex = 3;
            this.btnUpdateTeacher.Text = "Update Teacher";
            this.btnUpdateTeacher.UseVisualStyleBackColor = false;
            this.btnUpdateTeacher.Click += new System.EventHandler(this.btnUpdateTeacher_Click_1);
            // 
            // btnDeleteTeacher
            // 
            this.btnDeleteTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTeacher.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTeacher.Location = new System.Drawing.Point(507, 677);
            this.btnDeleteTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTeacher.Name = "btnDeleteTeacher";
            this.btnDeleteTeacher.Size = new System.Drawing.Size(200, 50);
            this.btnDeleteTeacher.TabIndex = 2;
            this.btnDeleteTeacher.Text = "Delete Teacher";
            this.btnDeleteTeacher.UseVisualStyleBackColor = false;
            this.btnDeleteTeacher.Click += new System.EventHandler(this.btnDeleteTeacher_Click_1);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTeacher.ForeColor = System.Drawing.Color.White;
            this.btnAddTeacher.Location = new System.Drawing.Point(27, 677);
            this.btnAddTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(200, 50);
            this.btnAddTeacher.TabIndex = 1;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = false;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click_1);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.txtSalary);
            this.groupBox8.Controls.Add(this.label36);
            this.groupBox8.Controls.Add(this.txtTeacherEmail);
            this.groupBox8.Controls.Add(this.txtTeacherContact);
            this.groupBox8.Controls.Add(this.txtQualification);
            this.groupBox8.Controls.Add(this.txtTeacherName);
            this.groupBox8.Controls.Add(this.txtTeacherCode);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(795, 25);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(480, 742);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Teacher Details";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(33, 547);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(399, 32);
            this.txtSalary.TabIndex = 11;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(28, 518);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(142, 25);
            this.label36.TabIndex = 10;
            this.label36.Text = "Monthly Salary:";
            // 
            // txtTeacherEmail
            // 
            this.txtTeacherEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacherEmail.Location = new System.Drawing.Point(33, 449);
            this.txtTeacherEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeacherEmail.Name = "txtTeacherEmail";
            this.txtTeacherEmail.Size = new System.Drawing.Size(399, 32);
            this.txtTeacherEmail.TabIndex = 9;
            // 
            // txtTeacherContact
            // 
            this.txtTeacherContact.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacherContact.Location = new System.Drawing.Point(33, 349);
            this.txtTeacherContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeacherContact.Name = "txtTeacherContact";
            this.txtTeacherContact.Size = new System.Drawing.Size(399, 32);
            this.txtTeacherContact.TabIndex = 8;
            // 
            // txtQualification
            // 
            this.txtQualification.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQualification.Location = new System.Drawing.Point(33, 251);
            this.txtQualification.Margin = new System.Windows.Forms.Padding(4);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(399, 32);
            this.txtQualification.TabIndex = 7;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacherName.Location = new System.Drawing.Point(33, 164);
            this.txtTeacherName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(399, 32);
            this.txtTeacherName.TabIndex = 6;
            // 
            // txtTeacherCode
            // 
            this.txtTeacherCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeacherCode.Location = new System.Drawing.Point(33, 75);
            this.txtTeacherCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeacherCode.Name = "txtTeacherCode";
            this.txtTeacherCode.Size = new System.Drawing.Size(399, 32);
            this.txtTeacherCode.TabIndex = 5;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(28, 420);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(134, 25);
            this.label35.TabIndex = 4;
            this.label35.Text = "Email Address:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(28, 321);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(155, 25);
            this.label34.TabIndex = 3;
            this.label34.Text = "Contact Number:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(28, 223);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(124, 25);
            this.label33.TabIndex = 2;
            this.label33.Text = "Qualification:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(28, 135);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(136, 25);
            this.label32.TabIndex = 1;
            this.label32.Text = "Teacher Name:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(28, 46);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(130, 25);
            this.label31.TabIndex = 0;
            this.label31.Text = "Teacher Code:";
            // 
            // ManageTeacher
            // 
            this.ClientSize = new System.Drawing.Size(1305, 836);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "ManageTeacher";
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnUpdateTeacher;
        private System.Windows.Forms.Button btnDeleteTeacher;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtTeacherEmail;
        private System.Windows.Forms.TextBox txtTeacherContact;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.TextBox txtTeacherName;
        private System.Windows.Forms.TextBox txtTeacherCode;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DataGridView dgvTeachers;
    }
}