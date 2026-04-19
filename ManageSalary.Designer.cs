namespace EducationalInstituteManagementSystem
{
    partial class ManageSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageSalary));
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnPrintSalarySlip = new System.Windows.Forms.Button();
            this.btnGenerateSalary = new System.Windows.Forms.Button();
            this.txtDeductions = new System.Windows.Forms.TextBox();
            this.txtAllowances = new System.Windows.Forms.TextBox();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.txtSalaryYear = new System.Windows.Forms.TextBox();
            this.cmbSalaryMonth = new System.Windows.Forms.ComboBox();
            this.cmbSalaryTeacher = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.dgvSalary);
            this.groupBox13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(39, 26);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox13.Size = new System.Drawing.Size(747, 756);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Salary Records";
            // 
            // dgvSalary
            // 
            this.dgvSalary.AllowUserToAddRows = false;
            this.dgvSalary.AllowUserToDeleteRows = false;
            this.dgvSalary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalary.ColumnHeadersHeight = 40;
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalary.EnableHeadersVisualStyles = false;
            this.dgvSalary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvSalary.Location = new System.Drawing.Point(7, 34);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.ReadOnly = true;
            this.dgvSalary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvSalary.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalary.RowHeadersWidth = 30;
            this.dgvSalary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalary.Size = new System.Drawing.Size(723, 701);
            this.dgvSalary.TabIndex = 12;
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.btnPrintSalarySlip);
            this.groupBox14.Controls.Add(this.btnGenerateSalary);
            this.groupBox14.Controls.Add(this.txtDeductions);
            this.groupBox14.Controls.Add(this.txtAllowances);
            this.groupBox14.Controls.Add(this.txtBasicSalary);
            this.groupBox14.Controls.Add(this.txtSalaryYear);
            this.groupBox14.Controls.Add(this.cmbSalaryMonth);
            this.groupBox14.Controls.Add(this.cmbSalaryTeacher);
            this.groupBox14.Controls.Add(this.label53);
            this.groupBox14.Controls.Add(this.label52);
            this.groupBox14.Controls.Add(this.label51);
            this.groupBox14.Controls.Add(this.label50);
            this.groupBox14.Controls.Add(this.label49);
            this.groupBox14.Controls.Add(this.label48);
            this.groupBox14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(803, 26);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox14.Size = new System.Drawing.Size(480, 756);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Generate Salary Slip";
            // 
            // btnPrintSalarySlip
            // 
            this.btnPrintSalarySlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintSalarySlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSalarySlip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSalarySlip.ForeColor = System.Drawing.Color.White;
            this.btnPrintSalarySlip.Location = new System.Drawing.Point(40, 640);
            this.btnPrintSalarySlip.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSalarySlip.Name = "btnPrintSalarySlip";
            this.btnPrintSalarySlip.Size = new System.Drawing.Size(400, 50);
            this.btnPrintSalarySlip.TabIndex = 13;
            this.btnPrintSalarySlip.Text = "Print Salary Slip";
            this.btnPrintSalarySlip.UseVisualStyleBackColor = false;
            this.btnPrintSalarySlip.Click += new System.EventHandler(this.btnPrintSalarySlip_Click_1);
            // 
            // btnGenerateSalary
            // 
            this.btnGenerateSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerateSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateSalary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSalary.ForeColor = System.Drawing.Color.White;
            this.btnGenerateSalary.Location = new System.Drawing.Point(40, 566);
            this.btnGenerateSalary.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateSalary.Name = "btnGenerateSalary";
            this.btnGenerateSalary.Size = new System.Drawing.Size(400, 50);
            this.btnGenerateSalary.TabIndex = 12;
            this.btnGenerateSalary.Text = "Generate Salary Slip";
            this.btnGenerateSalary.UseVisualStyleBackColor = false;
            this.btnGenerateSalary.Click += new System.EventHandler(this.btnGenerateSalary_Click_1);
            // 
            // txtDeductions
            // 
            this.txtDeductions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeductions.Location = new System.Drawing.Point(40, 492);
            this.txtDeductions.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeductions.Name = "txtDeductions";
            this.txtDeductions.Size = new System.Drawing.Size(399, 32);
            this.txtDeductions.TabIndex = 11;
            this.txtDeductions.Text = "0";
            // 
            // txtAllowances
            // 
            this.txtAllowances.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllowances.Location = new System.Drawing.Point(40, 418);
            this.txtAllowances.Margin = new System.Windows.Forms.Padding(4);
            this.txtAllowances.Name = "txtAllowances";
            this.txtAllowances.Size = new System.Drawing.Size(399, 32);
            this.txtAllowances.TabIndex = 10;
            this.txtAllowances.Text = "0";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicSalary.Location = new System.Drawing.Point(40, 345);
            this.txtBasicSalary.Margin = new System.Windows.Forms.Padding(4);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(399, 32);
            this.txtBasicSalary.TabIndex = 9;
            // 
            // txtSalaryYear
            // 
            this.txtSalaryYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalaryYear.Location = new System.Drawing.Point(40, 270);
            this.txtSalaryYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalaryYear.Name = "txtSalaryYear";
            this.txtSalaryYear.Size = new System.Drawing.Size(399, 32);
            this.txtSalaryYear.TabIndex = 8;
            this.txtSalaryYear.Text = "2024";
            // 
            // cmbSalaryMonth
            // 
            this.cmbSalaryMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalaryMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalaryMonth.FormattingEnabled = true;
            this.cmbSalaryMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbSalaryMonth.Location = new System.Drawing.Point(40, 197);
            this.cmbSalaryMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalaryMonth.Name = "cmbSalaryMonth";
            this.cmbSalaryMonth.Size = new System.Drawing.Size(399, 33);
            this.cmbSalaryMonth.TabIndex = 7;
            // 
            // cmbSalaryTeacher
            // 
            this.cmbSalaryTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalaryTeacher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalaryTeacher.FormattingEnabled = true;
            this.cmbSalaryTeacher.Location = new System.Drawing.Point(40, 123);
            this.cmbSalaryTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalaryTeacher.Name = "cmbSalaryTeacher";
            this.cmbSalaryTeacher.Size = new System.Drawing.Size(399, 33);
            this.cmbSalaryTeacher.TabIndex = 6;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(35, 464);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(111, 25);
            this.label53.TabIndex = 5;
            this.label53.Text = "Deductions:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(35, 390);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(111, 25);
            this.label52.TabIndex = 4;
            this.label52.Text = "Allowances:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(35, 316);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(115, 25);
            this.label51.TabIndex = 3;
            this.label51.Text = "Basic Salary:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(35, 242);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(108, 25);
            this.label50.TabIndex = 2;
            this.label50.Text = "Salary Year:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(35, 169);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(128, 25);
            this.label49.TabIndex = 1;
            this.label49.Text = "Salary Month:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(35, 94);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(136, 25);
            this.label48.TabIndex = 0;
            this.label48.Text = "Select Teacher:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // ManageSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 823);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox13);
            this.Name = "ManageSalary";
            this.Text = "ManageSalary";
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnPrintSalarySlip;
        private System.Windows.Forms.Button btnGenerateSalary;
        private System.Windows.Forms.TextBox txtDeductions;
        private System.Windows.Forms.TextBox txtAllowances;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.TextBox txtSalaryYear;
        private System.Windows.Forms.ComboBox cmbSalaryMonth;
        private System.Windows.Forms.ComboBox cmbSalaryTeacher;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}