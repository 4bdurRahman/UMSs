using EducationalInstituteManagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class TeacherPanelForm : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int teacherID;
        public bool isLoading = false;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        // constructor now accepts a Users.UserID and resolves the matching Teachers.TeacherID
        public TeacherPanelForm(int userID)
        {
            InitializeComponent();

            // Resolve TeacherID from Users.UserID:
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string resolveQuery = @"
                        SELECT t.TeacherID
                        FROM Teachers t
                        INNER JOIN Users u ON t.TeacherCode = u.Username
                        WHERE u.UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(resolveQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        object scalar = cmd.ExecuteScalar();
                        if (scalar != null && scalar != DBNull.Value)
                        {
                            teacherID = Convert.ToInt32(scalar);
                            MessageBox.Show("Resolved Teacher ID: " + teacherID, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // fallback: no teacher found for this user - set to 0 and notify
                            teacherID = 0;
                            MessageBox.Show("No teacher record found for the provided user id.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                teacherID = 0;
                MessageBox.Show("Error resolving teacher id: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load teacher info (will use resolved teacherID)
            LoadTeacherInfo();

            // Load initial data for dashboard
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.Show();
            //lblTitle.Text = childForm.Text;

        }

        private void LoadTeacherInfo()
        {
            if (teacherID <= 0) return; // nothing to load

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query teacher by TeacherID (we already resolved it in ctor)
                    string query = @"SELECT * FROM Teachers WHERE TeacherID = @TeacherID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTeacherName.Text = reader["FullName"].ToString();
                                lblTeacherCode.Text = reader["TeacherCode"].ToString();
                                // teacherID already set
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading teacher info: " + ex.Message);
                }
            }
        }

        
        // Add Results Tab Methods
        

        

        // Attendance Tab Methods
        

        // Assignments Tab Methods
        

        // Salary Tab Methods
        

        private void tabControlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This method is kept for backward compatibility
            // Main logic is now in tabControlTeacher_Selected
        }

        // Event handlers for combo boxes
        

        

       

        

        // Clear methods
        
       

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        // DataGridView cell click for attendance
        

        // Initialize form
        private void TeacherPanelForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new TDashboard(teacherID), sender);
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TAssignment(teacherID), sender);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TDashboard(teacherID), sender);
        }

        private void btnAddResults_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TResult(teacherID), sender);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TAttendence(teacherID), sender);
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TSalary(teacherID), sender);
        }
    }
}