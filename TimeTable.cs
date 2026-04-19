using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EducationalInstituteManagementSystem
{
    public partial class TimeTable : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public TimeTable()
        {
            InitializeComponent();

            // Idempotent Load wiring — avoids double subscription if designer already wired the event
            this.Load -= TimeTable_Load;
            this.Load += TimeTable_Load;

            if (btnAdd != null) btnAdd.Click += btnAdd_Click;
            if (btnUpdate != null) btnUpdate.Click += btnUpdate_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
            if (btnClear != null) btnClear.Click += btnClear_Click;
            if (btnFilter != null) btnFilter.Click += btnFilter_Click;
            if (dgvTimetable != null) dgvTimetable.CellClick += dgvTimetable_CellClick;
            if (dtpStartTime != null) dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
        }

        // NOTE: Designer registers this.Load => TimeTable_Load.
        private void TimeTable_Load(object sender, EventArgs e)
        {
            // previously named TimetableForm_Load — renamed to match designer
            LoadTimetable();
            LoadTeachers();
            ClearFields();

            // Populate combo boxes
            cmbClass.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbSection.Items.AddRange(new string[] { "A", "B", "C", "D" });
            cmbDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            cmbSubject.Items.AddRange(new string[] { "Mathematics", "English", "Science", "Physics", "Chemistry", "Biology", "Computer Science", "History", "Geography", "Economics", "Urdu", "Islamiat", "Arts", "Physical Education" });

            cmbFilterClass.Items.AddRange(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbFilterDay.Items.AddRange(new string[] { "All", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            cmbFilterClass.SelectedIndex = 0;
            cmbFilterDay.SelectedIndex = 0;
        }

        private void LoadTeachers()
        {
            try
            {
                // Teachers table has FullName column — alias to TeacherName for UI binding
                const string query = "SELECT TeacherId, FullName AS TeacherName FROM Teachers ORDER BY FullName";
                DataTable dt = ExecuteQuery(query);

                cmbTeacher.DataSource = dt;
                cmbTeacher.DisplayMember = "TeacherName";
                cmbTeacher.ValueMember = "TeacherId";
                cmbTeacher.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTimetable()
        {
            try
            {
                const string query = @"SELECT t.TimetableId, t.Class, t.Section, t.Day, t.Subject, 
                                tc.FullName AS TeacherName, t.StartTime, t.EndTime 
                                FROM Timetable t 
                                LEFT JOIN Teachers tc ON t.TeacherId = tc.TeacherId 
                                ORDER BY t.Class, t.Section, 
                                CASE t.Day 
                                    WHEN 'Monday' THEN 1 
                                    WHEN 'Tuesday' THEN 2 
                                    WHEN 'Wednesday' THEN 3 
                                    WHEN 'Thursday' THEN 4 
                                    WHEN 'Friday' THEN 5 
                                    WHEN 'Saturday' THEN 6 
                                END, t.StartTime";
                DataTable dt = ExecuteQuery(query);
                dgvTimetable.DataSource = dt ?? new DataTable();

                // Format columns (check existence)
                if (dgvTimetable.Columns.Contains("TimetableId"))
                    dgvTimetable.Columns["TimetableId"].HeaderText = "ID";
                if (dgvTimetable.Columns.Contains("TeacherName"))
                    dgvTimetable.Columns["TeacherName"].HeaderText = "Teacher";
                if (dgvTimetable.Columns.Contains("StartTime"))
                    dgvTimetable.Columns["StartTime"].HeaderText = "Start Time";
                if (dgvTimetable.Columns.Contains("EndTime"))
                    dgvTimetable.Columns["EndTime"].HeaderText = "End Time";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading timetable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtTimetableId.Clear();
            cmbClass.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbTeacher.SelectedIndex = -1;
            dtpStartTime.Value = DateTime.Today.AddHours(8);
            dtpEndTime.Value = DateTime.Today.AddHours(9);
        }

        private bool ValidateInput()
        {
            if (cmbClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a class!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClass.Focus();
                return false;
            }
            if (cmbSection.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a section!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSection.Focus();
                return false;
            }
            if (cmbDay.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a day!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDay.Focus();
                return false;
            }
            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a subject!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSubject.Focus();
                return false;
            }
            if (dtpEndTime.Value <= dtpStartTime.Value)
            {
                MessageBox.Show("End time must be after start time!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                int? teacherId = (cmbTeacher.SelectedValue != null && int.TryParse(cmbTeacher.SelectedValue.ToString(), out int tId)) ? (int?)tId : null;

                const string query = @"INSERT INTO Timetable (Class, Section, Day, Subject, TeacherId, StartTime, EndTime) 
                                VALUES (@Class, @Section, @Day, @Subject, @TeacherId, @StartTime, @EndTime)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Class", cmbClass.SelectedItem.ToString()),
                    new SqlParameter("@Section", cmbSection.SelectedItem.ToString()),
                    new SqlParameter("@Day", cmbDay.SelectedItem.ToString()),
                    new SqlParameter("@Subject", cmbSubject.SelectedItem.ToString()),
                    new SqlParameter("@TeacherId", teacherId.HasValue ? (object)teacherId.Value : DBNull.Value),
                    new SqlParameter("@StartTime", dtpStartTime.Value.TimeOfDay),
                    new SqlParameter("@EndTime", dtpEndTime.Value.TimeOfDay)
                };

                int result = ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Timetable entry added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTimetable();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding timetable entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimetableId.Text))
            {
                MessageBox.Show("Please select a timetable entry to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                int? teacherId = (cmbTeacher.SelectedValue != null && int.TryParse(cmbTeacher.SelectedValue.ToString(), out int tId)) ? (int?)tId : null;

                const string query = @"UPDATE Timetable SET 
                                Class = @Class, 
                                Section = @Section, 
                                Day = @Day, 
                                Subject = @Subject, 
                                TeacherId = @TeacherId, 
                                StartTime = @StartTime, 
                                EndTime = @EndTime 
                                WHERE TimetableId = @TimetableId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TimetableId", int.Parse(txtTimetableId.Text)),
                    new SqlParameter("@Class", cmbClass.SelectedItem.ToString()),
                    new SqlParameter("@Section", cmbSection.SelectedItem.ToString()),
                    new SqlParameter("@Day", cmbDay.SelectedItem.ToString()),
                    new SqlParameter("@Subject", cmbSubject.SelectedItem.ToString()),
                    new SqlParameter("@TeacherId", teacherId.HasValue ? (object)teacherId.Value : DBNull.Value),
                    new SqlParameter("@StartTime", dtpStartTime.Value.TimeOfDay),
                    new SqlParameter("@EndTime", dtpEndTime.Value.TimeOfDay)
                };

                int result = ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Timetable entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTimetable();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating timetable entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimetableId.Text))
            {
                MessageBox.Show("Please select a timetable entry to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this timetable entry?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    const string query = "DELETE FROM Timetable WHERE TimetableId = @TimetableId";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TimetableId", int.Parse(txtTimetableId.Text))
                    };

                    int deleteResult = ExecuteNonQuery(query, parameters);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Timetable entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTimetable();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting timetable entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string classFilter = cmbFilterClass.SelectedItem?.ToString() ?? "All";
                string dayFilter = cmbFilterDay.SelectedItem?.ToString() ?? "All";

                string query = @"SELECT t.TimetableId, t.Class, t.Section, t.Day, t.Subject, 
                                tc.FullName AS TeacherName, t.StartTime, t.EndTime 
                                FROM Timetable t 
                                LEFT JOIN Teachers tc ON t.TeacherId = tc.TeacherId 
                                WHERE 1=1";

                var parametersList = new List<SqlParameter>();

                if (classFilter != "All")
                {
                    query += " AND t.Class = @Class";
                    parametersList.Add(new SqlParameter("@Class", classFilter));
                }
                if (dayFilter != "All")
                {
                    query += " AND t.Day = @Day";
                    parametersList.Add(new SqlParameter("@Day", dayFilter));
                }

                query += @" ORDER BY t.Class, t.Section, 
                            CASE t.Day 
                                WHEN 'Monday' THEN 1 
                                WHEN 'Tuesday' THEN 2 
                                WHEN 'Wednesday' THEN 3 
                                WHEN 'Thursday' THEN 4 
                                WHEN 'Friday' THEN 5 
                                WHEN 'Saturday' THEN 6 
                            END, t.StartTime";

                DataTable dt = parametersList.Count > 0     
                    ? ExecuteQuery(query, parametersList.ToArray())
                    : ExecuteQuery(query);

                dgvTimetable.DataSource = dt ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTimetable.Rows.Count > e.RowIndex)
            {
                DataGridViewRow row = dgvTimetable.Rows[e.RowIndex];
                txtTimetableId.Text = row.Cells["TimetableId"].Value?.ToString() ?? string.Empty;

                cmbClass.SelectedItem = row.Cells["Class"].Value?.ToString();
                cmbSection.SelectedItem = row.Cells["Section"].Value?.ToString();
                cmbDay.SelectedItem = row.Cells["Day"].Value?.ToString();
                cmbSubject.SelectedItem = row.Cells["Subject"].Value?.ToString();

                // Find teacher by name
                string teacherName = row.Cells["TeacherName"].Value?.ToString();
                if (!string.IsNullOrEmpty(teacherName))
                {
                    for (int i = 0; i < cmbTeacher.Items.Count; i++)
                    {
                        var drv = cmbTeacher.Items[i] as DataRowView;
                        if (drv != null && drv["TeacherName"].ToString() == teacherName)
                        {
                            cmbTeacher.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbTeacher.SelectedIndex = -1;
                }

                if (row.Cells["StartTime"].Value != DBNull.Value && row.Cells["StartTime"].Value != null)
                {
                    TimeSpan startTime = (TimeSpan)row.Cells["StartTime"].Value;
                    dtpStartTime.Value = DateTime.Today.Add(startTime);
                }
                if (row.Cells["EndTime"].Value != DBNull.Value && row.Cells["EndTime"].Value != null)
                {
                    TimeSpan endTime = (TimeSpan)row.Cells["EndTime"].Value;
                    dtpEndTime.Value = DateTime.Today.Add(endTime);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            // no-op
        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
