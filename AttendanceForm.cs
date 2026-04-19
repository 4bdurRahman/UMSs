using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using EducationalManagementSystem.Utilities;

namespace EducationalManagementSystem
{
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadAttendance();

            // Set default date
            dtpAttendanceDate.Value = DateTime.Today;

            // Populate combo boxes
            cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Leave" });
            cmbClass.Items.AddRange(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbSection.Items.AddRange(new string[] { "All", "A", "B", "C", "D" });
            cmbClass.SelectedIndex = 0;
            cmbSection.SelectedIndex = 0;
        }

        private void LoadStudents()
        {
            try
            {
                string query = "SELECT StudentId, StudentName + ' (Class ' + Class + '-' + Section + ')' AS DisplayName FROM Students ORDER BY StudentName";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbStudent.DataSource = dt;
                cmbStudent.DisplayMember = "DisplayName";
                cmbStudent.ValueMember = "StudentId";
                cmbStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendance()
        {
            try
            {
                string query = @"SELECT a.AttendanceId, a.StudentId, s.StudentName, s.Class, s.Section, 
                                a.AttendanceDate, a.Status 
                                FROM Attendance a 
                                INNER JOIN Students s ON a.StudentId = s.StudentId 
                                ORDER BY a.AttendanceDate DESC, s.StudentName";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvAttendance.DataSource = dt;

                // Format columns
                if (dgvAttendance.Columns.Count > 0)
                {
                    dgvAttendance.Columns["AttendanceId"].HeaderText = "ID";
                    dgvAttendance.Columns["StudentId"].Visible = false;
                    dgvAttendance.Columns["StudentName"].HeaderText = "Student Name";
                    dgvAttendance.Columns["AttendanceDate"].HeaderText = "Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtAttendanceId.Clear();
            cmbStudent.SelectedIndex = -1;
            dtpAttendanceDate.Value = DateTime.Today;
            cmbStatus.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            if (cmbStudent.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStudent.Focus();
                return false;
            }
            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select attendance status!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }
            return true;
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                int studentId = Convert.ToInt32(cmbStudent.SelectedValue);
                DateTime attendanceDate = dtpAttendanceDate.Value.Date;

                // Check if attendance already exists for this student on this date
                string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentId = @StudentId AND AttendanceDate = @AttendanceDate";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@StudentId", studentId),
                    new SqlParameter("@AttendanceDate", attendanceDate)
                };
                int existingCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                if (existingCount > 0)
                {
                    MessageBox.Show("Attendance already marked for this student on this date!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"INSERT INTO Attendance (StudentId, AttendanceDate, Status) 
                                VALUES (@StudentId, @AttendanceDate, @Status)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentId", studentId),
                    new SqlParameter("@AttendanceDate", attendanceDate),
                    new SqlParameter("@Status", cmbStatus.SelectedItem.ToString())
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Attendance marked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAttendance();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAttendanceId.Text))
            {
                MessageBox.Show("Please select an attendance record to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                string query = @"UPDATE Attendance SET 
                                StudentId = @StudentId, 
                                AttendanceDate = @AttendanceDate, 
                                Status = @Status 
                                WHERE AttendanceId = @AttendanceId";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text)),
                    new SqlParameter("@StudentId", Convert.ToInt32(cmbStudent.SelectedValue)),
                    new SqlParameter("@AttendanceDate", dtpAttendanceDate.Value.Date),
                    new SqlParameter("@Status", cmbStatus.SelectedItem.ToString())
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Attendance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAttendance();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAttendanceId.Text))
            {
                MessageBox.Show("Please select an attendance record to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Attendance WHERE AttendanceId = @AttendanceId";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text))
                    };

                    int deleteResult = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Attendance record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendance();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string classFilter = cmbClass.SelectedItem?.ToString() ?? "All";
                string sectionFilter = cmbSection.SelectedItem?.ToString() ?? "All";

                string query = @"SELECT a.AttendanceId, a.StudentId, s.StudentName, s.Class, s.Section, 
                                a.AttendanceDate, a.Status 
                                FROM Attendance a 
                                INNER JOIN Students s ON a.StudentId = s.StudentId 
                                WHERE 1=1";

                if (classFilter != "All")
                    query += " AND s.Class = @Class";
                if (sectionFilter != "All")
                    query += " AND s.Section = @Section";

                query += " ORDER BY a.AttendanceDate DESC, s.StudentName";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Class", classFilter),
                    new SqlParameter("@Section", sectionFilter)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvAttendance.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];
                txtAttendanceId.Text = row.Cells["AttendanceId"].Value.ToString();

                int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                cmbStudent.SelectedValue = studentId;

                if (row.Cells["AttendanceDate"].Value != DBNull.Value)
                    dtpAttendanceDate.Value = Convert.ToDateTime(row.Cells["AttendanceDate"].Value);

                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
