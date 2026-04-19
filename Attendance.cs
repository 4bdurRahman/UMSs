//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace EducationalInstituteManagementSystem
//{
//    public partial class Attendance : Form
//    {
//        // Use DatabaseHelper.ConnectionString if needed elsewhere in this file.
//        public Attendance()
//        {
//            InitializeComponent();

//            // wire events safely (only if controls exist)
//            this.Load += AttendanceForm_Load;
//            if (btnMarkAttendance != null) btnMarkAttendance.Click += btnMarkAttendance_Click;
//            if (btnUpdate != null) btnUpdate.Click += btnUpdate_Click;
//            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
//            if (btnClear != null) btnClear.Click += btnClear_Click;
//            if (btnFilter != null) btnFilter.Click += btnFilter_Click;
//            if (btnClose != null) btnClose.Click += btnClose_Click;
//            if (dgvAttendance != null) dgvAttendance.CellClick += dgvAttendance_CellClick;
//            // removed btnClose wiring because control doesn't exist in designer
//        }

//        private void AttendanceForm_Load(object sender, EventArgs e)
//        {
//            LoadStudents();
//            LoadAttendance();

//            // Set default date
//            dtpAttendanceDate.Value = DateTime.Today;

//            // Populate combo boxes
//            cmbStatus.Items.Clear();
//            cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Leave" });

//            cmbClass.Items.Clear();
//            cmbClass.Items.AddRange(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });

//            cmbSection.Items.Clear();
//            cmbSection.Items.AddRange(new string[] { "All", "A", "B", "C", "D" });

//            cmbClass.SelectedIndex = 0;
//            cmbSection.SelectedIndex = 0;
//        }

//        private void LoadStudents()
//        {
//            try
//            {
//                const string query = "SELECT StudentID, FullName + ' (Class ' + Class + '-' + Section + ')' AS DisplayName FROM Students ORDER BY FullName";
//                DataTable dt = DatabaseHelper.ExecuteQuery(query);

//                if (dt == null || dt.Rows.Count == 0)
//                {
//                    cmbStudent.DataSource = null;
//                    cmbStudent.Items.Clear();
//                    return;
//                }

//                                                                cmbStudent.DataSource = dt;
//                cmbStudent.DisplayMember = "DisplayName";
//                cmbStudent.ValueMember = "StudentID";
//                cmbStudent.SelectedIndex = -1;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void LoadAttendance()
//        {
//            try
//            {
//                string query = @"SELECT a.AttendanceId, a.StudentID, s.FullName AS StudentName, s.Class, s.Section, 
//                                a.AttendanceDate, a.Status 
//                                FROM Attendance a 
//                                INNER JOIN Students s ON a.StudentID = s.StudentID 
//                                ORDER BY a.AttendanceDate DESC, s.FullName";
//                DataTable dt = DatabaseHelper.ExecuteQuery(query);
//                dgvAttendance.DataSource = dt;

//                // Format columns if they exist
//                if (dgvAttendance.Columns.Count > 0)
//                {
//                    if (dgvAttendance.Columns.Contains("AttendanceId"))
//                        dgvAttendance.Columns["AttendanceId"].HeaderText = "ID";

//                    if (dgvAttendance.Columns.Contains("StudentID"))
//                        dgvAttendance.Columns["StudentID"].Visible = false;

//                    if (dgvAttendance.Columns.Contains("StudentName"))
//                        dgvAttendance.Columns["StudentName"].HeaderText = "Student Name";

//                    if (dgvAttendance.Columns.Contains("AttendanceDate"))
//                        dgvAttendance.Columns["AttendanceDate"].HeaderText = "Date";
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ClearFields()
//        {
//            txtAttendanceId.Clear();
//            cmbStudent.SelectedIndex = -1;
//            dtpAttendanceDate.Value = DateTime.Today;
//            cmbStatus.SelectedIndex = -1;
//        }

//        private bool ValidateInput()
//        {
//            if (cmbStudent.SelectedIndex == -1)
//            {
//                MessageBox.Show("Please select a student!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                cmbStudent.Focus();
//                return false;
//            }
//            if (cmbStatus.SelectedIndex == -1)
//            {
//                MessageBox.Show("Please select attendance status!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                cmbStatus.Focus();
//                return false;
//            }
//            return true;
//        }

//        private void btnMarkAttendance_Click(object sender, EventArgs e)
//        {
//            if (!ValidateInput()) return;

//            try
//            {
//                int studentId = Convert.ToInt32(cmbStudent.SelectedValue);
//                DateTime attendanceDate = dtpAttendanceDate.Value.Date;
//                string status = cmbStatus.SelectedItem.ToString();

//                // Check if attendance already exists for this student on this date
//                string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentID = @StudentID AND AttendanceDate = @AttendanceDate";
//                SqlParameter[] checkParams = new SqlParameter[]
//                {
//                    new SqlParameter("@StudentID", studentId),
//                    new SqlParameter("@AttendanceDate", attendanceDate)
//                };
//                int existingCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

//                if (existingCount > 0)
//                {
//                    MessageBox.Show("Attendance already marked for this student on this date!", "Warning",
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // If AttendanceId is not IDENTITY in your DB, generate explicit id
//                long nextAttendanceId = 0;
//                try
//                {
//                    object o = DatabaseHelper.ExecuteScalar("SELECT ISNULL(MAX(AttendanceId), 0) + 1 FROM Attendance");
//                    nextAttendanceId = Convert.ToInt64(o);
//                }
//                catch
//                {
//                    // if something goes wrong, let the INSERT without AttendanceId proceed (if DB has IDENTITY)
//                    nextAttendanceId = 0;
//                }

//                string insertQuery;
//                SqlParameter[] parameters;

//                if (nextAttendanceId > 0)
//                {
//                    // Insert specifying AttendanceId and CreatedDate (for schemas that require them)
//                    insertQuery = @"INSERT INTO Attendance (AttendanceId, StudentID, AttendanceDate, Status, CreatedDate) 
//                                    VALUES (@AttendanceId, @StudentID, @AttendanceDate, @Status, @CreatedDate)";
//                    parameters = new SqlParameter[]
//                    {
//                        new SqlParameter("@AttendanceId", nextAttendanceId),
//                        new SqlParameter("@StudentID", studentId),
//                        new SqlParameter("@AttendanceDate", attendanceDate),
//                        new SqlParameter("@Status", status),
//                        new SqlParameter("@CreatedDate", DateTime.Today)
//                    };
//                }
//                else
//                {
//                    // Assume AttendanceId is IDENTITY
//                    insertQuery = @"INSERT INTO Attendance (StudentID, AttendanceDate, Status, CreatedDate) 
//                                    VALUES (@StudentID, @AttendanceDate, @Status, @CreatedDate)";
//                    parameters = new SqlParameter[]
//                    {
//                        new SqlParameter("@StudentID", studentId),
//                        new SqlParameter("@AttendanceDate", attendanceDate),
//                        new SqlParameter("@Status", status),
//                        new SqlParameter("@CreatedDate", DateTime.Today)
//                    };
//                }

//                int result = DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
//                if (result > 0)
//                {
//                    MessageBox.Show("Attendance marked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadAttendance();
//                    ClearFields();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error marking attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnUpdate_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtAttendanceId?.Text))
//            {
//                MessageBox.Show("Please select an attendance record to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }
//            if (!ValidateInput()) return;

//            try
//            {
//                const string query = @"UPDATE Attendance SET 
//                                StudentID = @StudentID, 
//                                AttendanceDate = @AttendanceDate, 
//                                Status = @Status 
//                                WHERE AttendanceId = @AttendanceId";

//                SqlParameter[] parameters = new SqlParameter[]
//                {
//                    new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text)),
//                    new SqlParameter("@StudentID", Convert.ToInt32(cmbStudent.SelectedValue)),
//                    new SqlParameter("@AttendanceDate", dtpAttendanceDate.Value.Date),
//                    new SqlParameter("@Status", cmbStatus.SelectedItem.ToString())
//                };

//                int result = ExecuteNonQuery(query, parameters);
//                if (result > 0)
//                {
//                    MessageBox.Show("Attendance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadAttendance();
//                    ClearFields();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error updating attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtAttendanceId?.Text))
//            {
//                MessageBox.Show("Please select an attendance record to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DialogResult res = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (res == DialogResult.Yes)
//            {
//                try
//                {
//                    const string query = "DELETE FROM Attendance WHERE AttendanceId = @AttendanceId";
//                    SqlParameter[] parameters = new SqlParameter[]
//                    {
//                        new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text))
//                    };

//                    int deleteResult = ExecuteNonQuery(query, parameters);
//                    if (deleteResult > 0)
//                    {
//                        MessageBox.Show("Attendance record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadAttendance();
//                        ClearFields();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Error deleting attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void btnClear_Click(object sender, EventArgs e)
//        {
//            ClearFields();
//        }

//        private void btnFilter_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string classFilter = cmbClass.SelectedItem?.ToString() ?? "All";
//                string sectionFilter = cmbSection.SelectedItem?.ToString() ?? "All";

//                string query = @"SELECT a.AttendanceId, a.StudentID, s.FullName AS StudentName, s.Class, s.Section, 
//                                a.AttendanceDate, a.Status 
//                                FROM Attendance a 
//                                INNER JOIN Students s ON a.StudentID = s.StudentID 
//                                WHERE 1=1";

//                var parametersList = new System.Collections.Generic.List<SqlParameter>();

//                if (classFilter != "All")
//                {
//                    query += " AND s.Class = @Class";
//                    parametersList.Add(new SqlParameter("@Class", classFilter));
//                }
//                if (sectionFilter != "All")
//                {
//                    query += " AND s.Section = @Section";
//                    parametersList.Add(new SqlParameter("@Section", sectionFilter));
//                }

//                query += " ORDER BY a.AttendanceDate DESC, s.FullName";

//                DataTable dt = parametersList.Count > 0
//                    ?       DatabaseHelper.ExecuteQuery(query, parametersList.ToArray())
//                    : DatabaseHelper.ExecuteQuery(query);

//                dgvAttendance.DataSource = dt;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error filtering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            try
//            {
//                if (e.RowIndex >= 0)
//                {
//                    DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];
//                    if (row.Cells["AttendanceId"].Value != DBNull.Value && row.Cells["AttendanceId"].Value != null)
//                        txtAttendanceId.Text = row.Cells["AttendanceId"].Value.ToString();
//                    else
//                        txtAttendanceId.Clear();

//                    if (row.Cells["StudentID"].Value != DBNull.Value && row.Cells["StudentID"].Value != null)
//                    {
//                        int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
//                        cmbStudent.SelectedValue = studentId;
//                    }
//                    else
//                    {
//                        cmbStudent.SelectedIndex = -1;
//                    }

//                    if (row.Cells["AttendanceDate"].Value != DBNull.Value && row.Cells["AttendanceDate"].Value != null)
//                        dtpAttendanceDate.Value = Convert.ToDateTime(row.Cells["AttendanceDate"].Value);
//                    else
//                        dtpAttendanceDate.Value = DateTime.Today;

//                    cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error selecting row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnClose_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void panelHeader_Paint(object sender, PaintEventArgs e)
//        {

//        }
//    }
//    csharp Attendance.cs
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    namespace EducationalInstituteManagementSystem
    {
        public partial class Attendance : Form
        {
            private readonly string connectionString =
                @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

            public Attendance()
            {
                InitializeComponent();

                // wire events safely (only if controls exist)
                this.Load += AttendanceForm_Load;
                if (btnMarkAttendance != null) btnMarkAttendance.Click += btnMarkAttendance_Click;
                if (btnUpdate != null) btnUpdate.Click += btnUpdate_Click;
                if (btnDelete != null) btnDelete.Click += btnDelete_Click;
                if (btnClear != null) btnClear.Click += btnClear_Click;
                if (btnFilter != null) btnFilter.Click += btnFilter_Click;
                if (dgvAttendance != null) dgvAttendance.CellClick += dgvAttendance_CellClick;
                // removed btnClose wiring and handler (no close button in UI)
            }

            private void AttendanceForm_Load(object sender, EventArgs e)
            {
                LoadStudents();
                LoadAttendance();

                // Set default date
                if (dtpAttendanceDate != null) dtpAttendanceDate.Value = DateTime.Today;

                // Populate combo boxes
                if (cmbStatus != null)
                {
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Leave" });
                }

                if (cmbClass != null)
                {
                    cmbClass.Items.Clear();
                    cmbClass.Items.AddRange(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
                    cmbClass.SelectedIndex = 0;
                }

                if (cmbSection != null)
                {
                    cmbSection.Items.Clear();
                    cmbSection.Items.AddRange(new string[] { "All", "A", "B", "C", "D" });
                    cmbSection.SelectedIndex = 0;
                }
            }

            private void LoadStudents()
            {
                try
                {
                    const string query = "SELECT StudentID, FullName + ' (Class ' + Class + '-' + Section + ')' AS DisplayName FROM Students ORDER BY FullName";
                    DataTable dt = ExecuteQuery(query);

                    if (cmbStudent == null) return;

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        cmbStudent.DataSource = null;
                        cmbStudent.Items.Clear();
                        return;
                    }

                    cmbStudent.DataSource = dt;
                    cmbStudent.DisplayMember = "DisplayName";
                    cmbStudent.ValueMember = "StudentID";
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
                    const string query = @"SELECT a.AttendanceId, a.StudentID, s.FullName AS StudentName, s.Class, s.Section, 
                                    a.AttendanceDate, a.Status 
                                    FROM Attendance a 
                                    INNER JOIN Students s ON a.StudentID = s.StudentID 
                                    ORDER BY a.AttendanceDate DESC, s.FullName";
                    DataTable dt = ExecuteQuery(query);

                    if (dgvAttendance != null)
                        dgvAttendance.DataSource = dt ?? new DataTable();

                    // Format columns if they exist
                    if (dgvAttendance != null && dgvAttendance.Columns.Count > 0)
                    {
                        if (dgvAttendance.Columns.Contains("AttendanceId"))
                            dgvAttendance.Columns["AttendanceId"].HeaderText = "ID";

                        if (dgvAttendance.Columns.Contains("StudentID"))
                            dgvAttendance.Columns["StudentID"].Visible = false;

                        if (dgvAttendance.Columns.Contains("StudentName"))
                            dgvAttendance.Columns["StudentName"].HeaderText = "Student Name";

                        if (dgvAttendance.Columns.Contains("AttendanceDate"))
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
                if (txtAttendanceId != null) txtAttendanceId.Clear();
                if (cmbStudent != null) cmbStudent.SelectedIndex = -1;
                if (dtpAttendanceDate != null) dtpAttendanceDate.Value = DateTime.Today;
                if (cmbStatus != null) cmbStatus.SelectedIndex = -1;
            }

            private bool ValidateInput()
            {
                if (cmbStudent == null || cmbStudent.DataSource == null || cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a student!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent?.Focus();
                    return false;
                }
                if (cmbStatus == null || cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select attendance status!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus?.Focus();
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
                    string status = cmbStatus.SelectedItem.ToString();

                    // Check if attendance already exists for this student on this date
                    const string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentID = @StudentID AND AttendanceDate = @AttendanceDate";
                    SqlParameter[] checkParams = new SqlParameter[]
                    {
                        new SqlParameter("@StudentID", studentId),
                        new SqlParameter("@AttendanceDate", attendanceDate)
                    };
                    object scalar = ExecuteScalar(checkQuery, checkParams);
                    int existingCount = scalar == null ? 0 : Convert.ToInt32(scalar);

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Attendance already marked for this student on this date!", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // If AttendanceId is not IDENTITY in your DB, generate explicit id
                    long nextAttendanceId = 0;
                    try
                    {
                        object o = ExecuteScalar("SELECT ISNULL(MAX(AttendanceId), 0) + 1 FROM Attendance");
                        if (o != null) nextAttendanceId = Convert.ToInt64(o);
                    }
                    catch
                    {
                        nextAttendanceId = 0;
                    }

                    string insertQuery;
                    SqlParameter[] parameters;

                    if (nextAttendanceId > 0)
                    {
                        insertQuery = @"INSERT INTO Attendance (AttendanceId, StudentID, AttendanceDate, Status, CreatedDate) 
                                        VALUES (@AttendanceId, @StudentID, @AttendanceDate, @Status, @CreatedDate)";
                        parameters = new SqlParameter[]
                        {
                            new SqlParameter("@AttendanceId", (int)nextAttendanceId),
                            new SqlParameter("@StudentID", studentId),
                            new SqlParameter("@AttendanceDate", attendanceDate),
                            new SqlParameter("@Status", status),
                            new SqlParameter("@CreatedDate", DateTime.Today)
                        };
                    }
                    else
                    {
                        insertQuery = @"INSERT INTO Attendance (StudentID, AttendanceDate, Status, CreatedDate) 
                                        VALUES (@StudentID, @AttendanceDate, @Status, @CreatedDate)";
                        parameters = new SqlParameter[]
                        {
                            new SqlParameter("@StudentID", studentId),
                            new SqlParameter("@AttendanceDate", attendanceDate),
                            new SqlParameter("@Status", status),
                            new SqlParameter("@CreatedDate", DateTime.Today)
                        };
                    }

                    int result = ExecuteNonQuery(insertQuery, parameters);
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
                if (string.IsNullOrEmpty(txtAttendanceId?.Text))
                {
                    MessageBox.Show("Please select an attendance record to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateInput()) return;

                try
                {
                    const string query = @"UPDATE Attendance SET 
                                    StudentID = @StudentID, 
                                    AttendanceDate = @AttendanceDate, 
                                    Status = @Status 
                                    WHERE AttendanceId = @AttendanceId";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text)),
                        new SqlParameter("@StudentID", Convert.ToInt32(cmbStudent.SelectedValue)),
                        new SqlParameter("@AttendanceDate", dtpAttendanceDate.Value.Date),
                        new SqlParameter("@Status", cmbStatus.SelectedItem.ToString())
                    };

                    int result = ExecuteNonQuery(query, parameters);
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
                if (string.IsNullOrEmpty(txtAttendanceId?.Text))
                {
                    MessageBox.Show("Please select an attendance record to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    try
                    {
                        const string query = "DELETE FROM Attendance WHERE AttendanceId = @AttendanceId";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@AttendanceId", int.Parse(txtAttendanceId.Text))
                        };

                        int deleteResult = ExecuteNonQuery(query, parameters);
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

                    string query = @"SELECT a.AttendanceId, a.StudentID, s.FullName AS StudentName, s.Class, s.Section, 
                                    a.AttendanceDate, a.Status 
                                    FROM Attendance a 
                                    INNER JOIN Students s ON a.StudentID = s.StudentID 
                                    WHERE 1=1";

                    var parametersList = new System.Collections.Generic.List<SqlParameter>();

                    if (classFilter != "All")
                    {
                        query += " AND s.Class = @Class";
                        parametersList.Add(new SqlParameter("@Class", classFilter));
                    }
                    if (sectionFilter != "All")
                    {
                        query += " AND s.Section = @Section";
                        parametersList.Add(new SqlParameter("@Section", sectionFilter));
                    }

                    query += " ORDER BY a.AttendanceDate DESC, s.FullName";

                    DataTable dt = parametersList.Count > 0
                        ? ExecuteQuery(query, parametersList.ToArray())
                        : ExecuteQuery(query);

                    if (dgvAttendance != null) dgvAttendance.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];
                        if (row.Cells["AttendanceId"].Value != DBNull.Value && row.Cells["AttendanceId"].Value != null)
                            txtAttendanceId.Text = row.Cells["AttendanceId"].Value.ToString();
                        else
                            txtAttendanceId.Clear();

                        if (row.Cells["StudentID"].Value != DBNull.Value && row.Cells["StudentID"].Value != null)
                        {
                            int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                            cmbStudent.SelectedValue = studentId;
                        }
                        else
                        {
                            cmbStudent.SelectedIndex = -1;
                        }

                        if (row.Cells["AttendanceDate"].Value != DBNull.Value && row.Cells["AttendanceDate"].Value != null)
                            dtpAttendanceDate.Value = Convert.ToDateTime(row.Cells["AttendanceDate"].Value);
                        else
                            dtpAttendanceDate.Value = DateTime.Today;

                        cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // --- Simple ADO helpers (in-file) ---
            private DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
            {
                var dt = new DataTable();
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }

            private int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

            private object ExecuteScalar(string sql, params SqlParameter[] parameters)
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }

            private void panelHeader_Paint(object sender, PaintEventArgs e)
            {
            }
        }
    }
