namespace EducationalInstituteManagementSystem
{
    partial class SDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// Designer controls used by SDashboard.cs:
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pbStudentPhoto;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStudentDetails;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pbStudentPhoto = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStudentDetails = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 140;
            this.panelHeader.Padding = new System.Windows.Forms.Padding(12);
            this.panelHeader.Controls.Add(this.pbStudentPhoto);
            this.panelHeader.Controls.Add(this.lblStudentName);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.TabIndex = 0;
            // 
            // pbStudentPhoto
            // 
            this.pbStudentPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStudentPhoto.BackColor = System.Drawing.Color.LightGray;
            this.pbStudentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStudentPhoto.Location = new System.Drawing.Point(1140, 18);
            this.pbStudentPhoto.Name = "pbStudentPhoto";
            this.pbStudentPhoto.Size = new System.Drawing.Size(100, 100);
            this.pbStudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStudentPhoto.TabIndex = 2;
            this.pbStudentPhoto.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(12, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(900, 36);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = false;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblStudentName.Location = new System.Drawing.Point(14, 56);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(900, 24);
            this.lblStudentName.TabIndex = 1;
            this.lblStudentName.Text = "";
            this.lblStudentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblStudentDetails);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.groupBox1.Location = new System.Drawing.Point(24, 156);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
            this.groupBox1.Size = new System.Drawing.Size(1256, 620);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Details";
            // 
            // lblStudentDetails
            // 
            this.lblStudentDetails.AutoSize = false;
            this.lblStudentDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStudentDetails.Location = new System.Drawing.Point(18, 32);
            this.lblStudentDetails.Name = "lblStudentDetails";
            this.lblStudentDetails.Size = new System.Drawing.Size(1216, 560);
            this.lblStudentDetails.TabIndex = 0;
            this.lblStudentDetails.Text = "Details";
            this.lblStudentDetails.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // SDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeader);
            this.Name = "SDashboard";
            this.Text = "Student Dashboard";
            this.Load += new System.EventHandler(this.SDashboard_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}