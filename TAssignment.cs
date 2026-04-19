using EducationalInstituteManagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class TAssignment : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int teacherID;
        public bool isLoading = false;

        public TAssignment(int teacherID)
        {
            InitializeComponent();
            this.teacherID = teacherID;
            dtpAssignDueDate.Value = DateTime.Now.AddDays(7);

            // ensure load and events are wired (defensive/idempotent)
            this.Load -= TAssignment_Load;
            this.Load += TAssignment_Load;

            this.cmbAssignClass.SelectedIndexChanged -= cmbAssignClass_SelectedIndexChanged;
            this.cmbAssignClass.SelectedIndexChanged += cmbAssignClass_SelectedIndexChanged;

            this.cmbAssignSubject.SelectedIndexChanged -= cmbAssignSubject_SelectedIndexChanged;
            this.cmbAssignSubject.SelectedIndexChanged += cmbAssignSubject_SelectedIndexChanged;

            // wire button click (designer may or may not have wired it)
            this.btnPostAssignment.Click -= this.btnPostAssignment_Click;
            this.btnPostAssignment.Click += this.btnPostAssignment_Click;
        }

        private void TAssignment_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadClassesForAssignments();

            // select first class if available
            if (cmbAssignClass.Items.Count > 0)
                cmbAssignClass.SelectedIndex = 0;

            isLoading = false;
        }

        private void LoadClassesForAssignments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT DISTINCT Class FROM Subjects 
                                   WHERE TeacherID = @TeacherID ORDER BY Class";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbAssignClass.Items.Clear();
                            while (reader.Read())
                            {
                                cmbAssignClass.Items.Add(reader["Class"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes for assignments: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjectsForAssignments(string className)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT SubjectID, SubjectName FROM Subjects 
                                   WHERE Class = @Class AND TeacherID = @TeacherID 
                                   ORDER BY SubjectName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Class", className);
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbAssignSubject.Items.Clear();
                            while (reader.Read())
                            {
                                int subjectID = Convert.ToInt32(reader["SubjectID"]);
                                string subjectName = reader["SubjectName"].ToString();
                                cmbAssignSubject.Items.Add(new SubjectItem(subjectID, subjectName));
                            }
                        }
                    }
                }

                if (cmbAssignSubject.Items.Count > 0)
                    cmbAssignSubject.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects for assignments: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAssignmentsForTeacher(string className = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // include subject name and compute Status
                    string query = @"
                        SELECT a.AssignmentID,
                               a.AssignmentTitle,
                               a.Description,
                               a.DueDate,
                               a.TotalMarks,
                               s.SubjectName,
                               a.Class,
                               CASE 
                                   WHEN a.DueDate < CAST(GETDATE() AS DATE) THEN 'Overdue'
                                   WHEN DATEDIFF(day, CAST(GETDATE() AS DATE), a.DueDate) <= 3 THEN 'Due Soon'
                                   ELSE 'Upcoming'
                               END as Status
                        FROM Assignments a
                        INNER JOIN Subjects s ON a.SubjectID = s.SubjectID
                        WHERE a.TeacherID = @TeacherID";

                    if (!string.IsNullOrEmpty(className))
                        query += " AND a.Class = @Class";

                    query += " ORDER BY a.DueDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        if (!string.IsNullOrEmpty(className))
                            cmd.Parameters.AddWithValue("@Class", className);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // If a designer DataGridView named dgvAssignments exists bind to it.
                            // Otherwise keep data available (no runtime grid).
                            if (this.Controls.ContainsKey("dgvAssignments"))
                            {
                                var grid = this.Controls["dgvAssignments"] as DataGridView;
                                if (grid != null)
                                {
                                    grid.DataSource = dt;

                                    if (grid.Columns["AssignmentID"] != null)
                                        grid.Columns["AssignmentID"].Visible = false;

                                    if (grid.Columns["AssignmentTitle"] != null)
                                        grid.Columns["AssignmentTitle"].HeaderText = "Title";
                                    if (grid.Columns["Description"] != null)
                                        grid.Columns["Description"].HeaderText = "Description";
                                    if (grid.Columns["DueDate"] != null)
                                        grid.Columns["DueDate"].HeaderText = "Due Date";
                                    if (grid.Columns["TotalMarks"] != null)
                                        grid.Columns["TotalMarks"].HeaderText = "Marks";
                                    if (grid.Columns["SubjectName"] != null)
                                        grid.Columns["SubjectName"].HeaderText = "Subject";
                                    if (grid.Columns["Class"] != null)
                                        grid.Columns["Class"].HeaderText = "Class";
                                    if (grid.Columns["Status"] != null)
                                        grid.Columns["Status"].HeaderText = "Status";
                                }
                            }
                            else
                            {
                                // no runtime/designer grid present — nothing to bind to.
                                // Keep silent (or optionally log) so load continues without exception.
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assignments: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPostAssignment_Click(object sender, EventArgs e)
        {
            if (cmbAssignClass.SelectedItem == null || cmbAssignSubject.SelectedItem == null)
            {
                MessageBox.Show("Please select class and subject!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string title = txtAssignTitle.Text.Trim();
            string description = txtAssignDescription.Text.Trim();
            DateTime dueDate = dtpAssignDueDate.Value.Date;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter assignment title!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAssignTotalMarks.Text))
            {
                MessageBox.Show("Please enter total marks!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int totalMarks = Convert.ToInt32(txtAssignTotalMarks.Text);
                SubjectItem selectedSubject = (SubjectItem)cmbAssignSubject.SelectedItem;
                int subjectID = selectedSubject.ID;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Assignments (SubjectID, TeacherID, Class, 
                                   AssignmentTitle, Description, DueDate, TotalMarks) 
                                   VALUES (@SubjectID, @TeacherID, @Class, @Title, 
                                   @Description, @DueDate, @TotalMarks)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        cmd.Parameters.AddWithValue("@Class", cmbAssignClass.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);
                        cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Assignment posted successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAssignmentFields();

                            // refresh assignments list for the selected class
                            string cls = cmbAssignClass.SelectedItem != null ? cmbAssignClass.SelectedItem.ToString() : null;
                            LoadAssignmentsForTeacher(cls);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for total marks!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAssignmentFields()
        {
            txtAssignTitle.Clear();
            txtAssignDescription.Clear();
            txtAssignTotalMarks.Clear();
            dtpAssignDueDate.Value = DateTime.Now.AddDays(7);
        }

        private void cmbAssignClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cmbAssignClass.SelectedIndex < 0) return;

            string cls = cmbAssignClass.SelectedItem.ToString();
            LoadSubjectsForAssignments(cls);
            LoadAssignmentsForTeacher(cls);
        }

        // Designer currently wires to this handler
        private void cmbAssignClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cmbAssignClass.SelectedIndex < 0) return;

            string cls = cmbAssignClass.SelectedItem.ToString();
            LoadSubjectsForAssignments(cls);
            LoadAssignmentsForTeacher(cls);
        }

        private void cmbAssignSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // optionally refresh assignments when subject changes (not required)
        }

        private void btnPostAssignment_Click_1(object sender, EventArgs e)
        {
            // legacy empty handler - kept for designer compatibility, logic uses btnPostAssignment_Click
        }

        private void txtAssignTotalMarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void dtpAssignDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtAssignDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtAssignTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void cmbAssignClass_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
