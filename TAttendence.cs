using EducationalInstituteManagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class TAttendence : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int teacherID;
        public bool isLoading = false;

        public TAttendence(int teacherID)
        {
            this.teacherID = teacherID;
            InitializeComponent();

            this.Load += TAttendence_Load;
            this.btnMarkAttendance.Click += btnMarkAttendance_Click;
            this.cmbAttClass.SelectedIndexChanged += cmbAttClass_SelectedIndexChanged;
            this.cmbAttSubject.SelectedIndexChanged += cmbAttSubject_SelectedIndexChanged;
            this.dgvAttendance.CellClick += dgvAttendance_CellClick;
        }

        private void TAttendence_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadClassesForAttendance();

            if (cmbAttClass.Items.Count > 0)
                cmbAttClass.SelectedIndex = 0;

            isLoading = false;
        }

        private void LoadClassesForAttendance()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT DISTINCT Class FROM Subjects 
                                   WHERE TeacherID = @TeacherID ORDER BY Class";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbAttClass.Items.Clear();
                            while (reader.Read())
                            {
                                cmbAttClass.Items.Add(reader["Class"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading classes for attendance: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSubjectsForAttendance(string className)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
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
                            cmbAttSubject.Items.Clear();
                            while (reader.Read())
                            {
                                int subjectID = Convert.ToInt32(reader["SubjectID"]);
                                string subjectName = reader["SubjectName"].ToString();
                                cmbAttSubject.Items.Add(new SubjectItem(subjectID, subjectName));
                            }
                        }
                    }

                    if (cmbAttSubject.Items.Count > 0)
                        cmbAttSubject.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects for attendance: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadStudentsForAttendance(string className)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    var selectedSubject = cmbAttSubject.SelectedItem as SubjectItem;
                    int? subjectID = selectedSubject?.ID;

                    // Build query: include TodayStatus (defaults to 'Absent'), and include SubjectID/TeacherID columns
                    string query = @"
                        SELECT s.StudentID,
                               s.FullName,
                               s.RegistrationNo,
                               ISNULL((
                                    SELECT TOP 1 a.Status
                                    FROM Attendance a
                                    WHERE a.StudentID = s.StudentID
                                      AND a.TeacherID = @TeacherID
                                      AND a.AttendanceDate = @Today" +
                                      (subjectID.HasValue ? " AND a.SubjectID = @SubjectID" : "") +
                                    @"
                               ), 'Absent') AS TodayStatus,
                               " + (subjectID.HasValue ? "@SubjectID" : "NULL") + @" AS SubjectID,
                               @TeacherID AS TeacherIDConst
                        FROM Students s
                        WHERE s.Class = @Class
                        ORDER BY s.FullName;";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Class", className);
                        da.SelectCommand.Parameters.AddWithValue("@TeacherID", teacherID);
                        da.SelectCommand.Parameters.AddWithValue("@Today", DateTime.Today);
                        if (subjectID.HasValue)
                            da.SelectCommand.Parameters.AddWithValue("@SubjectID", subjectID.Value);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Ensure expected columns and defaults
                        if (!dt.Columns.Contains("TodayStatus"))
                            dt.Columns.Add("TodayStatus", typeof(string));
                        if (!dt.Columns.Contains("SubjectID"))
                            dt.Columns.Add("SubjectID", typeof(int));
                        if (!dt.Columns.Contains("TeacherIDConst"))
                            dt.Columns.Add("TeacherIDConst", typeof(int));

                        foreach (DataRow row in dt.Rows)
                        {
                            if (row.IsNull("TodayStatus") || string.IsNullOrWhiteSpace(row["TodayStatus"].ToString()))
                                row["TodayStatus"] = "Absent";

                            if (row.IsNull("SubjectID") || row["SubjectID"] == DBNull.Value)
                                row["SubjectID"] = -1;

                            if (row.IsNull("TeacherIDConst") || row["TeacherIDConst"] == DBNull.Value)
                                row["TeacherIDConst"] = teacherID;
                        }

                        // Bind and configure grid for full, editable view
                        dgvAttendance.AutoGenerateColumns = true;
                        dgvAttendance.DataSource = dt;
                        dgvAttendance.AllowUserToAddRows = false;
                        dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvAttendance.MultiSelect = false;

                        // Hide internal ids but keep them available for saving
                        if (dgvAttendance.Columns["StudentID"] != null)
                            dgvAttendance.Columns["StudentID"].Visible = false;
                        if (dgvAttendance.Columns["SubjectID"] != null)
                        {
                            dgvAttendance.Columns["SubjectID"].HeaderText = "Subject ID";
                            dgvAttendance.Columns["SubjectID"].Visible = false;
                        }
                        if (dgvAttendance.Columns["TeacherIDConst"] != null)
                        {
                            dgvAttendance.Columns["TeacherIDConst"].HeaderText = "TeacherID";
                            dgvAttendance.Columns["TeacherIDConst"].Visible = false;
                        }

                        if (dgvAttendance.Columns["FullName"] != null)
                            dgvAttendance.Columns["FullName"].HeaderText = "Student Name";
                        if (dgvAttendance.Columns["RegistrationNo"] != null)
                            dgvAttendance.Columns["RegistrationNo"].HeaderText = "Registration No";

                        // Ensure TodayStatus column present and editable
                        if (dgvAttendance.Columns["TodayStatus"] != null)
                        {
                            dgvAttendance.Columns["TodayStatus"].HeaderText = "Status";
                            dgvAttendance.Columns["TodayStatus"].ReadOnly = false;
                            dgvAttendance.Columns["TodayStatus"].Width = 120;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance data: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("No students loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAttClass.SelectedItem == null || cmbAttSubject.SelectedItem == null)
            {
                MessageBox.Show("Please select class and subject!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedSubject = cmbAttSubject.SelectedItem as SubjectItem;
            if (selectedSubject == null)
            {
                MessageBox.Show("Invalid subject selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int subjectID = selectedSubject.ID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvAttendance.Rows)
                    {
                        if (row.Cells["StudentID"].Value != null && row.Cells["TodayStatus"].Value != null)
                        {
                            int studentID = Convert.ToInt32(row.Cells["StudentID"].Value);
                            string status = row.Cells["TodayStatus"].Value.ToString();

                            string checkQuery = @"SELECT COUNT(*) FROM Attendance 
                                                WHERE StudentID = @StudentID 
                                                  AND TeacherID = @TeacherID 
                                                  AND AttendanceDate = @Today
                                                  AND SubjectID = @SubjectID";

                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@StudentID", studentID);
                                checkCmd.Parameters.AddWithValue("@TeacherID", teacherID);
                                checkCmd.Parameters.AddWithValue("@Today", DateTime.Today);
                                checkCmd.Parameters.AddWithValue("@SubjectID", subjectID);

                                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (exists > 0)
                                {
                                    string updateQuery = @"UPDATE Attendance SET Status = @Status 
                                                         WHERE StudentID = @StudentID 
                                                           AND TeacherID = @TeacherID 
                                                           AND AttendanceDate = @Today
                                                           AND SubjectID = @SubjectID";

                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Status", status);
                                        updateCmd.Parameters.AddWithValue("@StudentID", studentID);
                                        updateCmd.Parameters.AddWithValue("@TeacherID", teacherID);
                                        updateCmd.Parameters.AddWithValue("@Today", DateTime.Today);
                                        updateCmd.Parameters.AddWithValue("@SubjectID", subjectID);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    string insertQuery = @"INSERT INTO Attendance (StudentID, TeacherID, SubjectID, Status, AttendanceDate, CreatedDate) 
                                                         VALUES (@StudentID, @TeacherID, @SubjectID, @Status, @Today, @Created)";

                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@StudentID", studentID);
                                        insertCmd.Parameters.AddWithValue("@TeacherID", teacherID);
                                        insertCmd.Parameters.AddWithValue("@SubjectID", subjectID);
                                        insertCmd.Parameters.AddWithValue("@Status", status);
                                        insertCmd.Parameters.AddWithValue("@Today", DateTime.Today);
                                        insertCmd.Parameters.AddWithValue("@Created", DateTime.Now);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Attendance marked successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh to show the persisted state
                    if (cmbAttClass.SelectedItem != null)
                        LoadStudentsForAttendance(cmbAttClass.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn col = dgvAttendance.Columns[e.ColumnIndex];
                if (col.Name == "TodayStatus" || col.HeaderText == "Status")
                {
                    DataGridViewCell cell = dgvAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string currentStatus = cell.Value?.ToString() ?? "";
                    cell.Value = (currentStatus == "Present") ? "Absent" : "Present";
                }
            }
        }

        private void cmbAttClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || cmbAttClass.SelectedItem == null) return;

            string selectedClass = cmbAttClass.SelectedItem.ToString();
            LoadSubjectsForAttendance(selectedClass);

            if (cmbAttSubject.Items.Count > 0)
            {
                cmbAttSubject.SelectedIndex = 0;
            }
            else
            {
                LoadStudentsForAttendance(selectedClass);
            }
        }

        private void cmbAttSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cmbAttClass.SelectedItem == null || cmbAttSubject.SelectedItem == null) return;

            string selectedClass = cmbAttClass.SelectedItem.ToString();
            LoadStudentsForAttendance(selectedClass);
        }
    }
}