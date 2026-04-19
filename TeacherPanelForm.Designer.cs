namespace EducationalInstituteManagementSystem
{
    partial class TeacherPanelForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnAssignments = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnAddResults = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTeacherCode = new System.Windows.Forms.Label();
            this.lblTeacherName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnSalary);
            this.panelSidebar.Controls.Add(this.btnAssignments);
            this.panelSidebar.Controls.Add(this.btnAttendance);
            this.panelSidebar.Controls.Add(this.btnAddResults);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.label2);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 74);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(293, 849);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 763);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(293, 86);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "   Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.BackColor = System.Drawing.Color.Transparent;
            this.btnSalary.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalary.FlatAppearance.BorderSize = 0;
            this.btnSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalary.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalary.ForeColor = System.Drawing.Color.White;
            this.btnSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalary.Location = new System.Drawing.Point(0, 456);
            this.btnSalary.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnSalary.Size = new System.Drawing.Size(293, 74);
            this.btnSalary.TabIndex = 7;
            this.btnSalary.Text = "   Salary";
            this.btnSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalary.UseVisualStyleBackColor = false;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnAssignments
            // 
            this.btnAssignments.BackColor = System.Drawing.Color.Transparent;
            this.btnAssignments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAssignments.FlatAppearance.BorderSize = 0;
            this.btnAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignments.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignments.ForeColor = System.Drawing.Color.White;
            this.btnAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignments.Location = new System.Drawing.Point(0, 382);
            this.btnAssignments.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssignments.Name = "btnAssignments";
            this.btnAssignments.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAssignments.Size = new System.Drawing.Size(293, 74);
            this.btnAssignments.TabIndex = 6;
            this.btnAssignments.Text = "   Assignments";
            this.btnAssignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignments.UseVisualStyleBackColor = false;
            this.btnAssignments.Click += new System.EventHandler(this.btnAssignments_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.Transparent;
            this.btnAttendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.Location = new System.Drawing.Point(0, 308);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAttendance.Size = new System.Drawing.Size(293, 74);
            this.btnAttendance.TabIndex = 5;
            this.btnAttendance.Text = "   Attendance";
            this.btnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnAddResults
            // 
            this.btnAddResults.BackColor = System.Drawing.Color.Transparent;
            this.btnAddResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddResults.FlatAppearance.BorderSize = 0;
            this.btnAddResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddResults.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddResults.ForeColor = System.Drawing.Color.White;
            this.btnAddResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddResults.Location = new System.Drawing.Point(0, 234);
            this.btnAddResults.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddResults.Name = "btnAddResults";
            this.btnAddResults.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAddResults.Size = new System.Drawing.Size(293, 74);
            this.btnAddResults.TabIndex = 4;
            this.btnAddResults.Text = "   Add Results";
            this.btnAddResults.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddResults.UseVisualStyleBackColor = false;
            this.btnAddResults.Click += new System.EventHandler(this.btnAddResults_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 160);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(293, 74);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(293, 160);
            this.label2.TabIndex = 2;
            this.label2.Text = "Teacher Panel\r\n\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTeacherCode);
            this.panelHeader.Controls.Add(this.lblTeacherName);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1600, 74);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTeacherCode
            // 
            this.lblTeacherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTeacherCode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherCode.ForeColor = System.Drawing.Color.White;
            this.lblTeacherCode.Location = new System.Drawing.Point(1200, 0);
            this.lblTeacherCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeacherCode.Name = "lblTeacherCode";
            this.lblTeacherCode.Size = new System.Drawing.Size(400, 74);
            this.lblTeacherCode.TabIndex = 2;
            this.lblTeacherCode.Text = "Code: T001";
            this.lblTeacherCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTeacherName
            // 
            this.lblTeacherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTeacherName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherName.ForeColor = System.Drawing.Color.White;
            this.lblTeacherName.Location = new System.Drawing.Point(800, 0);
            this.lblTeacherName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeacherName.Name = "lblTeacherName";
            this.lblTeacherName.Size = new System.Drawing.Size(400, 74);
            this.lblTeacherName.TabIndex = 1;
            this.lblTeacherName.Text = "Name: Dr. Sara Khan";
            this.lblTeacherName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Educational Institute Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(293, 74);
            this.panelDesktopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(1307, 849);
            this.panelDesktopPanel.TabIndex = 2;
            // 
            // TeacherPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 923);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeacherPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher Panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TeacherPanelForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnAssignments;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnAddResults;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTeacherCode;
        private System.Windows.Forms.Label lblTeacherName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPanel;
    }
}