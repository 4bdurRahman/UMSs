using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class ManageStudent : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public ManageStudent()
        {
            InitializeComponent();

            // Ensure form load populates grid
            this.Load += ManageStudent_Load;

            // Safe wiring for controls in case designer didn't wire them
            if (dgvStudents != null) dgvStudents.CellClick += dgvStudents_CellClick;
            if (btnAddStudent != null) btnAddStudent.Click += btnAddStudent_Click;
            if (btnUpdateStudent != null) btnUpdateStudent.Click += btnUpdateStudent_Click;
            if (btnDeleteStudent != null) btnDeleteStudent.Click += btnDeleteStudent_Click;
        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Select explicit columns so column names are predictable
                    string query = @"SELECT StudentID, RegistrationNo, FullName, FatherName, 
                                     CONVERT(VARCHAR(10), DOB, 120) AS DOB, Contact, Address, Class, Section 
                                     FROM Students ORDER BY FullName";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string regNo = txtRegNo.Text.Trim();
            string fullName = txtStudentName.Text.Trim();
            string fatherName = txtFatherName.Text.Trim();
            DateTime dob = dtpDOB.Value.Date;
            string contact = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();
            string studentClass = cmbClass.Text;
            string section = cmbSection.Text;

            if (string.IsNullOrEmpty(regNo) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please fill required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Students (RegistrationNo, FullName, FatherName, DOB, Contact, Address, Class, Section) " +
                                   "VALUES (@RegNo, @FullName, @FatherName, @DOB, @Contact, @Address, @Class, @Section)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@FatherName", fatherName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Class", studentClass);
                    cmd.Parameters.AddWithValue("@Section", section);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearStudentFields();
                        LoadStudents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearStudentFields()
        {
            txtRegNo.Clear();
            txtStudentName.Clear();
            txtFatherName.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            cmbClass.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Today;
        }

        // -------------------- handle grid row click and populate fields --------------------
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvStudents.Rows.Count) return;

                var row = dgvStudents.Rows[e.RowIndex];

                string GetCellString(string col)
                {
                    if (!dgvStudents.Columns.Contains(col)) return string.Empty;
                    var val = row.Cells[col].Value;
                    return (val == null || val == DBNull.Value) ? string.Empty : val.ToString();
                }

                txtRegNo.Text = GetCellString("RegistrationNo");
                txtStudentName.Text = GetCellString("FullName");
                txtFatherName.Text = GetCellString("FatherName");

                // DOB -> set DateTimePicker (handles string or DateTime)
                string dobStr = GetCellString("DOB");
                if (DateTime.TryParse(dobStr, out DateTime parsedDob))
                    dtpDOB.Value = parsedDob;
                else
                    dtpDOB.Value = DateTime.Today;

                txtContact.Text = GetCellString("Contact");
                txtAddress.Text = GetCellString("Address");

                // Select class/section in combobox if item exists, otherwise set text
                string cls = GetCellString("Class");
                if (!string.IsNullOrEmpty(cls))
                {
                    int idx = cmbClass.FindStringExact(cls);
                    if (idx >= 0) cmbClass.SelectedIndex = idx;
                    else cmbClass.Text = cls;
                }
                else cmbClass.SelectedIndex = -1;

                string section = GetCellString("Section");
                if (!string.IsNullOrEmpty(section))
                {
                    int idx = cmbSection.FindStringExact(section);
                    if (idx >= 0) cmbSection.SelectedIndex = idx;
                    else cmbSection.Text = section;
                }
                else cmbSection.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting student row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --------------------------------------------------------------------------------------

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);
            string regNo = txtRegNo.Text.Trim();
            string fullName = txtStudentName.Text.Trim();
            string fatherName = txtFatherName.Text.Trim();
            DateTime dob = dtpDOB.Value.Date;
            string contact = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();
            string studentClass = cmbClass.Text;
            string section = cmbSection.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Students SET RegistrationNo=@RegNo, FullName=@FullName, FatherName=@FatherName,
                                     DOB=@DOB, Contact=@Contact, Address=@Address, Class=@Class, Section=@Section
                                     WHERE StudentID=@StudentID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RegNo", regNo);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@FatherName", fatherName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Class", studentClass);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearStudentFields();
                        LoadStudents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating student: " + ex.Message);
                }
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudents();
                            ClearStudentFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
    
        }
    }
}
