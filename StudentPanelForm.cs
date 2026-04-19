using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class StudentPanelForm : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        int studentID;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public StudentPanelForm(int userID)
        {
            studentID = userID;

            InitializeComponent();
            studentID = userID;
            LoadStudentInfo();

            SDashboard dashboard = new SDashboard(userID);
            OpenChildForm(dashboard, null);
        }

        private void LoadStudentInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT s.* FROM Students s 
                                   INNER JOIN Users u ON s.RegistrationNo = u.Username 
                                   WHERE u.UserID = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", studentID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblStudentName.Text = reader["FullName"].ToString();
                        lblRegNo.Text = reader["RegistrationNo"].ToString();
                        //lblClass.Text = reader["Class"].ToString();
                        //lblSection.Text = reader["Section"].ToString();
                        studentID = Convert.ToInt32(reader["StudentID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student info: " + ex.Message);
                }
            }
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

        // Results Tab




        // Attendance Tab


        // Assignments Tab


        // Fee Status Tab




        // Admit Card Tab


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

        private void tabControlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SDashboard(studentID), sender);

        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SResult(studentID), sender);

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SAttendence(studentID), sender);

        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SAssignment(studentID), sender);

        }

        private void btnFeeStatus_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SFee(studentID), sender);

        }

        private void btnAdmitCard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SAdmitCard(studentID), sender);

        }
    }
}