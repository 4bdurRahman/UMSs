using EducationalInstituteManagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class SAssignment : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int studentID;

        public SAssignment(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
            LoadStudentAssignments();

            // idempotent event wiring for row/cell clicks
            dgvAssignments.CellClick -= dgvAssignments_CellClick;
            dgvAssignments.CellClick += dgvAssignments_CellClick;

            dgvAssignments.RowHeaderMouseClick -= dgvAssignments_RowHeaderMouseClick;
            dgvAssignments.RowHeaderMouseClick += dgvAssignments_RowHeaderMouseClick;
        }

        private void LoadStudentAssignments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get student's class
                    string classQuery = "SELECT Class FROM Students WHERE StudentID = @StudentID";
                    using (SqlCommand classCmd = new SqlCommand(classQuery, conn))
                    {
                        classCmd.Parameters.AddWithValue("@StudentID", studentID);
                        var classObj = classCmd.ExecuteScalar();
                        if (classObj == null || classObj == DBNull.Value)
                        {
                            MessageBox.Show("Student class not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        string studentClass = classObj.ToString();

                        // Get assignments for student's class
                        string query = @"SELECT a.AssignmentID, a.AssignmentTitle, a.Description, 
                                       a.DueDate, a.TotalMarks, s.SubjectName, t.FullName as TeacherName,
                                       CASE 
                                           WHEN a.DueDate < GETDATE() THEN 'Overdue'
                                           WHEN DATEDIFF(day, GETDATE(), a.DueDate) <= 3 THEN 'Due Soon'
                                           ELSE 'Upcoming'
                                       END as Status
                                       FROM Assignments a 
                                       INNER JOIN Subjects s ON a.SubjectID = s.SubjectID
                                       INNER JOIN Teachers t ON a.TeacherID = t.TeacherID
                                       WHERE a.Class = @Class
                                       ORDER BY a.DueDate";

                        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@Class", studentClass);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvAssignments.DataSource = dt;

                            // Configure visible columns and headers for clarity
                            if (dgvAssignments.Columns.Contains("AssignmentID"))
                                dgvAssignments.Columns["AssignmentID"].Visible = false;
                            if (dgvAssignments.Columns.Contains("AssignmentTitle"))
                                dgvAssignments.Columns["AssignmentTitle"].HeaderText = "Title";
                            if (dgvAssignments.Columns.Contains("SubjectName"))
                                dgvAssignments.Columns["SubjectName"].HeaderText = "Subject";
                            if (dgvAssignments.Columns.Contains("TeacherName"))
                                dgvAssignments.Columns["TeacherName"].HeaderText = "Teacher";
                            if (dgvAssignments.Columns.Contains("DueDate"))
                                dgvAssignments.Columns["DueDate"].HeaderText = "Due Date";
                            if (dgvAssignments.Columns.Contains("TotalMarks"))
                                dgvAssignments.Columns["TotalMarks"].HeaderText = "Marks";
                            if (dgvAssignments.Columns.Contains("Status"))
                                dgvAssignments.Columns["Status"].HeaderText = "Status";

                            dgvAssignments.AutoResizeColumns();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading assignments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Row header click also shows details (convenience)
        private void dgvAssignments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                ShowAssignmentDetailsFromRowIndex(e.RowIndex);
        }

        // Cell click: show details for the clicked row (single-click view)
        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ShowAssignmentDetailsFromRowIndex(e.RowIndex);
        }

        private void ShowAssignmentDetailsFromRowIndex(int rowIndex)
        {
            try
            {
                if (rowIndex < 0 || rowIndex >= dgvAssignments.Rows.Count) return;

                DataGridViewRow row = dgvAssignments.Rows[rowIndex];

                string title = GetCellString(row, "AssignmentTitle");
                string description = GetCellString(row, "Description");
                string subject = GetCellString(row, "SubjectName");
                string teacher = GetCellString(row, "TeacherName");
                string due = GetCellString(row, "DueDate");
                string marks = GetCellString(row, "TotalMarks");
                string status = GetCellString(row, "Status");

                using (var details = new AssignmentDetailsForm(title, description, subject, teacher, due, marks, status))
                {
                    details.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing assignment details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row == null || !dgvAssignments.Columns.Contains(columnName)) return string.Empty;
            var cell = row.Cells[columnName].Value;
            if (cell == null || cell == DBNull.Value) return string.Empty;
            return cell.ToString();
        }
    }
}
