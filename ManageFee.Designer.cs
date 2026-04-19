namespace EducationalInstituteManagementSystem
{
    partial class ManageFee
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnPrintFeeSlip = new System.Windows.Forms.Button();
            this.btnGenerateFee = new System.Windows.Forms.Button();
            this.dtpFeeDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtFeeAmount = new System.Windows.Forms.TextBox();
            this.cmbFeeType = new System.Windows.Forms.ComboBox();
            this.cmbFeeStudent = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.dgvFees);
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(92, 44);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(955, 832);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Fee Records";
            // 
            // dgvFees
            // 
            this.dgvFees.AllowUserToAddRows = false;
            this.dgvFees.AllowUserToDeleteRows = false;
            this.dgvFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFees.BackgroundColor = System.Drawing.Color.White;
            this.dgvFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFees.ColumnHeadersHeight = 40;
            this.dgvFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFees.EnableHeadersVisualStyles = false;
            this.dgvFees.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvFees.Location = new System.Drawing.Point(7, 34);
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.ReadOnly = true;
            this.dgvFees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvFees.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFees.RowHeadersWidth = 30;
            this.dgvFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFees.Size = new System.Drawing.Size(933, 754);
            this.dgvFees.TabIndex = 11;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnPrintFeeSlip);
            this.groupBox12.Controls.Add(this.btnGenerateFee);
            this.groupBox12.Controls.Add(this.dtpFeeDueDate);
            this.groupBox12.Controls.Add(this.txtFeeAmount);
            this.groupBox12.Controls.Add(this.cmbFeeType);
            this.groupBox12.Controls.Add(this.cmbFeeStudent);
            this.groupBox12.Controls.Add(this.label46);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.label44);
            this.groupBox12.Controls.Add(this.label43);
            this.groupBox12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(1071, 55);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox12.Size = new System.Drawing.Size(468, 832);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Generate Fee Challan";
            // 
            // btnPrintFeeSlip
            // 
            this.btnPrintFeeSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintFeeSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintFeeSlip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintFeeSlip.ForeColor = System.Drawing.Color.White;
            this.btnPrintFeeSlip.Location = new System.Drawing.Point(40, 615);
            this.btnPrintFeeSlip.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintFeeSlip.Name = "btnPrintFeeSlip";
            this.btnPrintFeeSlip.Size = new System.Drawing.Size(400, 50);
            this.btnPrintFeeSlip.TabIndex = 10;
            this.btnPrintFeeSlip.Text = "Print Fee Challan";
            this.btnPrintFeeSlip.UseVisualStyleBackColor = false;
            this.btnPrintFeeSlip.Click += new System.EventHandler(this.btnPrintFeeSlip_Click_1);
            // 
            // btnGenerateFee
            // 
            this.btnGenerateFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGenerateFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateFee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateFee.ForeColor = System.Drawing.Color.White;
            this.btnGenerateFee.Location = new System.Drawing.Point(40, 542);
            this.btnGenerateFee.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateFee.Name = "btnGenerateFee";
            this.btnGenerateFee.Size = new System.Drawing.Size(400, 50);
            this.btnGenerateFee.TabIndex = 9;
            this.btnGenerateFee.Text = "Generate Fee Challan";
            this.btnGenerateFee.UseVisualStyleBackColor = false;
            this.btnGenerateFee.Click += new System.EventHandler(this.btnGenerateFee_Click_1);
            // 
            // dtpFeeDueDate
            // 
            this.dtpFeeDueDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFeeDueDate.Location = new System.Drawing.Point(40, 443);
            this.dtpFeeDueDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFeeDueDate.Name = "dtpFeeDueDate";
            this.dtpFeeDueDate.Size = new System.Drawing.Size(399, 32);
            this.dtpFeeDueDate.TabIndex = 8;
            // 
            // txtFeeAmount
            // 
            this.txtFeeAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeeAmount.Location = new System.Drawing.Point(40, 345);
            this.txtFeeAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeeAmount.Name = "txtFeeAmount";
            this.txtFeeAmount.Size = new System.Drawing.Size(399, 32);
            this.txtFeeAmount.TabIndex = 7;
            // 
            // cmbFeeType
            // 
            this.cmbFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeeType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFeeType.FormattingEnabled = true;
            this.cmbFeeType.Items.AddRange(new object[] {
            "Monthly Tuition Fee",
            "Examination Fee",
            "Library Fee",
            "Sports Fee",
            "Transport Fee",
            "Admission Fee"});
            this.cmbFeeType.Location = new System.Drawing.Point(40, 246);
            this.cmbFeeType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFeeType.Name = "cmbFeeType";
            this.cmbFeeType.Size = new System.Drawing.Size(399, 33);
            this.cmbFeeType.TabIndex = 6;
            // 
            // cmbFeeStudent
            // 
            this.cmbFeeStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeeStudent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFeeStudent.FormattingEnabled = true;
            this.cmbFeeStudent.Location = new System.Drawing.Point(40, 148);
            this.cmbFeeStudent.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFeeStudent.Name = "cmbFeeStudent";
            this.cmbFeeStudent.Size = new System.Drawing.Size(399, 33);
            this.cmbFeeStudent.TabIndex = 5;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(35, 414);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(94, 25);
            this.label46.TabIndex = 4;
            this.label46.Text = "Due Date:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(35, 316);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(117, 25);
            this.label45.TabIndex = 3;
            this.label45.Text = "Fee Amount:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(35, 218);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(89, 25);
            this.label44.TabIndex = 2;
            this.label44.Text = "Fee Type:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(35, 119);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(135, 25);
            this.label43.TabIndex = 1;
            this.label43.Text = "Select Student:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ManageFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 1005);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Name = "ManageFee";
            this.Text = "ManageFee";
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnPrintFeeSlip;
        private System.Windows.Forms.Button btnGenerateFee;
        private System.Windows.Forms.DateTimePicker dtpFeeDueDate;
        private System.Windows.Forms.TextBox txtFeeAmount;
        private System.Windows.Forms.ComboBox cmbFeeType;
        private System.Windows.Forms.ComboBox cmbFeeStudent;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DataGridView dgvFees;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}