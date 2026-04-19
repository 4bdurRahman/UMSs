using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class ManageTeacher : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        private int selectedTeacherId = -1;

        public ManageTeacher()
        {
            InitializeComponent();
            LoadTeachers();

            // Wire the grid click so clicking a row fills the detail fields
            if (dgvTeachers != null)
                dgvTeachers.CellClick += dgvTeachers_CellClick;
        }

        private void LoadTeachers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Teachers";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTeachers.DataSource = dt;

                    // Optionally hide the id column visually
                    if (dgvTeachers.Columns.Contains("TeacherId"))
                        dgvTeachers.Columns["TeacherId"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading teachers: " + ex.Message);
                }
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
        }

        private void ClearTeacherFields()
        {
            txtTeacherCode.Clear();
            txtTeacherName.Clear();
            txtQualification.Clear();
            txtTeacherContact.Clear();
            txtTeacherEmail.Clear();
            txtSalary.Clear();
            selectedTeacherId = -1;
        }

        // When a row is clicked, populate the textboxes with row values
        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvTeachers.Rows[e.RowIndex];

                // Safely read columns by name if present
                if (dgvTeachers.Columns.Contains("TeacherId") && row.Cells["TeacherId"].Value != DBNull.Value)
                    selectedTeacherId = Convert.ToInt32(row.Cells["TeacherId"].Value);
                else
                    selectedTeacherId = -1;

                if (dgvTeachers.Columns.Contains("TeacherCode"))
                    txtTeacherCode.Text = row.Cells["TeacherCode"].Value?.ToString() ?? string.Empty;

                if (dgvTeachers.Columns.Contains("FullName"))
                    txtTeacherName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;

                if (dgvTeachers.Columns.Contains("Qualification"))
                    txtQualification.Text = row.Cells["Qualification"].Value?.ToString() ?? string.Empty;

                if (dgvTeachers.Columns.Contains("Contact"))
                    txtTeacherContact.Text = row.Cells["Contact"].Value?.ToString() ?? string.Empty;

                if (dgvTeachers.Columns.Contains("Email"))
                    txtTeacherEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;

                if (dgvTeachers.Columns.Contains("Salary"))
                    txtSalary.Text = row.Cells["Salary"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting teacher: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // OPTIONAL: Update and Delete handlers that use selectedTeacherId
        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateTeacher_Click_1(object sender, EventArgs e)
        {
            if (selectedTeacherId <= 0)
            {
                MessageBox.Show("Please select a teacher to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string teacherCode = txtTeacherCode.Text.Trim();
            string fullName = txtTeacherName.Text.Trim();
            string qualification = txtQualification.Text.Trim();
            string contact = txtTeacherContact.Text.Trim();
            string email = txtTeacherEmail.Text.Trim();
            decimal salary = 0;
            decimal.TryParse(txtSalary.Text, out salary);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Teachers SET TeacherCode=@TeacherCode, FullName=@FullName, Qualification=@Qualification,
                                    Contact=@Contact, Email=@Email, Salary=@Salary WHERE TeacherId=@TeacherId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeacherCode", teacherCode);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Qualification", qualification);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@TeacherId", selectedTeacherId);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Teacher updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTeacherFields();
                        LoadTeachers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating teacher: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteTeacher_Click_1(object sender, EventArgs e)
        {
            if (selectedTeacherId <= 0)
            {
                MessageBox.Show("Please select a teacher to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("Are you sure you want to delete the selected teacher?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Teachers WHERE TeacherId = @TeacherId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeacherId", selectedTeacherId);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Teacher deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTeacherFields();
                        LoadTeachers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting teacher: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddTeacher_Click_1(object sender, EventArgs e)
        {

            string teacherCode = txtTeacherCode.Text.Trim();
            string fullName = txtTeacherName.Text.Trim();
            string qualification = txtQualification.Text.Trim();
            string contact = txtTeacherContact.Text.Trim();
            string email = txtTeacherEmail.Text.Trim();
            decimal salary = 0;
            decimal.TryParse(txtSalary.Text, out salary);

            if (string.IsNullOrEmpty(teacherCode) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please fill required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Teachers (TeacherCode, FullName, Qualification, Contact, Email, Salary) " +
                                   "VALUES (@TeacherCode, @FullName, @Qualification, @Contact, @Email, @Salary)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeacherCode", teacherCode);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Qualification", qualification);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Salary", salary);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Teacher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTeacherFields();
                        LoadTeachers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
