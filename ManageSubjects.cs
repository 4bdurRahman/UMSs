using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{

    public partial class ManageSubjects : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        private int selectedSubjectId = -1;

        public ManageSubjects()
        {
            InitializeComponent();
            LoadSubjects();
            LoadTeachersCombo();

            // Wire the grid click so clicking a row fills the detail fields
            if (dgvSubjects != null)
                dgvSubjects.CellClick += dgvSubjects_CellClick;
        }

        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT s.*, t.FullName as TeacherName FROM Subjects s LEFT JOIN Teachers t ON s.TeacherID = t.TeacherID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSubjects.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message);
                }
            }
        }

        private void LoadTeachersCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TeacherID, FullName FROM Teachers";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Use DataSource so we can select by ValueMember easily
                    cmbSubjectTeacher.DisplayMember = "FullName";
                    cmbSubjectTeacher.ValueMember = "TeacherID";
                    cmbSubjectTeacher.DataSource = dt;
                    cmbSubjectTeacher.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading teachers: " + ex.Message);
                }
            }
        }

        // Helper to safely read a cell value by several possible column names
        private string GetCellStringValue(DataGridViewRow row, params string[] possibleNames)
        {
            foreach (var name in possibleNames)
            {
                if (dgvSubjects.Columns.Contains(name))
                {
                    var val = row.Cells[name].Value;
                    if (val != null && val != DBNull.Value)
                        return val.ToString();
                }
            }
            return string.Empty;
        }

        // When a row is clicked, populate the textboxes and combo with row values
        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];

                // Try to get subject id from common column names
                string idVal = GetCellStringValue(row, "SubjectID", "SubjectId", "ID", "Subject_Id");
                selectedSubjectId = -1;
                if (!string.IsNullOrEmpty(idVal) && int.TryParse(idVal, out int sid))
                    selectedSubjectId = sid;

                // Populate text fields using likely column names
                txtSubjectCode.Text = GetCellStringValue(row, "SubjectCode", "Code", "Subject_Code");
                txtSubjectName.Text = GetCellStringValue(row, "SubjectName", "Name", "Subject_Name");
                txtClassName.Text = GetCellStringValue(row, "ClassName", "Class", "ClassName");

                // For teacher, try to read TeacherID (value) or TeacherName (display) and select combo accordingly
                string teacherIdVal = GetCellStringValue(row, "TeacherID", "TeacherId", "Teacher_Id");
                if (!string.IsNullOrEmpty(teacherIdVal) && cmbSubjectTeacher.DataSource != null)
                {
                    // If DataSource is set with ValueMember, select by value
                    try
                    {
                        if (int.TryParse(teacherIdVal, out int tId))
                        {
                            cmbSubjectTeacher.SelectedValue = tId;
                        }
                        else
                        {
                            cmbSubjectTeacher.SelectedValue = teacherIdVal;
                        }
                    }
                    catch
                    {
                        // ignore and fallback to matching by displayed text below
                    }
                }
                else
                {
                    // If we have TeacherName column, try to select by display text
                    string teacherName = GetCellStringValue(row, "TeacherName", "TeacherFullName", "FullName");
                    if (!string.IsNullOrEmpty(teacherName) && cmbSubjectTeacher.Items.Count > 0)
                    {
                        // If DataSource is used, iterate rows to find matching display member
                        if (cmbSubjectTeacher.DataSource is DataTable dt)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                var display = dt.Rows[i][cmbSubjectTeacher.DisplayMember]?.ToString();
                                if (string.Equals(display, teacherName, StringComparison.OrdinalIgnoreCase))
                                {
                                    cmbSubjectTeacher.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // If items are simple strings in "ID - Name" format, match by substring
                            for (int i = 0; i < cmbSubjectTeacher.Items.Count; i++)
                            {
                                var itemText = cmbSubjectTeacher.GetItemText(cmbSubjectTeacher.Items[i]);
                                if (itemText.IndexOf(teacherName, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    cmbSubjectTeacher.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Nothing matched — clear selection
                        cmbSubjectTeacher.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting subject: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSubjectFields()
        {
            txtSubjectCode.Clear();
            txtSubjectName.Clear();
            txtClassName.Clear();
            cmbSubjectTeacher.SelectedIndex = -1;
            selectedSubjectId = -1;
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string code = txtSubjectCode.Text.Trim();
            string name = txtSubjectName.Text.Trim();
            string className = txtClassName.Text.Trim();
            object teacherValue = cmbSubjectTeacher.SelectedValue;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please fill required fields (Subject Code and Name).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Subjects (SubjectCode, SubjectName, Class, TeacherID) VALUES (@Code, @Name, @Class, @TeacherID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Class", (object)className ?? DBNull.Value);
                        if (teacherValue == null || teacherValue == DBNull.Value)
                            cmd.Parameters.AddWithValue("@TeacherID", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(teacherValue));

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSubjectFields();
                            LoadSubjects();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding subject: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId <= 0)
            {
                MessageBox.Show("Please select a subject to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string code = txtSubjectCode.Text.Trim();
            string name = txtSubjectName.Text.Trim();
            string className = txtClassName.Text.Trim();
            object teacherValue = cmbSubjectTeacher.SelectedValue;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please fill required fields (Subject Code and Name).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Use DB column "Class"
                    string query = @"UPDATE Subjects SET SubjectCode=@Code, SubjectName=@Name, [Class]=@Class, TeacherID=@TeacherID
                                     WHERE SubjectID=@SubjectID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Class", (object)className ?? DBNull.Value);
                        if (teacherValue == null || teacherValue == DBNull.Value)
                            cmd.Parameters.AddWithValue("@TeacherID", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TeacherID", Convert.ToInt32(teacherValue));
                        cmd.Parameters.AddWithValue("@SubjectID", selectedSubjectId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Subject updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSubjectFields();
                            LoadSubjects();
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Verify the selected subject.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating subject: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId <= 0)
            {
                MessageBox.Show("Please select a subject to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("Are you sure you want to delete the selected subject?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectID", selectedSubjectId);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearSubjectFields();
                            LoadSubjects();
                        }
                        else
                        {
                            MessageBox.Show("No rows were deleted. Verify the selected subject.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting subject: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
