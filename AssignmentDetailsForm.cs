   using System;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    // Simple modal form that shows assignment details in a readable layout.
    public partial class AssignmentDetailsForm : Form
    {
        public AssignmentDetailsForm(string title, string description, string subject, string teacher, string dueDate, string marks, string status)
        {
            this.Text = "Assignment Details";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(700, 420);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = false,
                Location = new Point(16, 12),
                Size = new Size(this.ClientSize.Width - 32, 30)
            };
            this.Controls.Add(lblTitle);

            var meta = new Label
            {
                Text = $"Subject: {subject}    |    Teacher: {teacher}    |    Due: {dueDate}    |    Marks: {marks}    |    Status: {status}",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                AutoSize = false,
                Location = new Point(16, 48),
                Size = new Size(this.ClientSize.Width - 32, 22)
            };
            this.Controls.Add(meta);

            var separator = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(16, 74),
                Size = new Size(this.ClientSize.Width - 32, 2)
            };
            this.Controls.Add(separator);

            var lblDesc = new Label
            {
                Text = "Description:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(16, 88),
                AutoSize = true
            };
            this.Controls.Add(lblDesc);

            var txtDesc = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(16, 116),
                Size = new Size(this.ClientSize.Width - 32, 240),
                Text = description ?? string.Empty,
                BackColor = Color.White
            };
            this.Controls.Add(txtDesc);

            var btnClose = new Button
            {
                Text = "Close",
                DialogResult = DialogResult.OK,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Size = new Size(90, 30),
                Location = new Point(this.ClientSize.Width - 106, this.ClientSize.Height - 42)
            };
            this.Controls.Add(btnClose);

            this.AcceptButton = btnClose;
        }
    }
}
