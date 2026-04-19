using EducationalInstituteManagementSystem;
using EducationalInstituteManagementSystem.Models;
using EducationalInstituteManagementSystem.Services;
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
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, Role FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role AND IsActive = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int userID = Convert.ToInt32(reader["UserID"]);
                        string userRole = reader["Role"].ToString();

                        this.Hide();

                        if (userRole == "Admin")
                        {
                            AdminPanelForm adminForm = new AdminPanelForm();
                            adminForm.Show();
                        }
                        else if (userRole == "Teacher")
                        {
                            TeacherPanelForm teacherForm = new TeacherPanelForm(userID);
                            teacherForm.Show();
                        }
                        else if (userRole == "Student")
                        {
                            StudentPanelForm studentForm = new StudentPanelForm(userID);
                            studentForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username, password or role!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRetrievePassword_Click(object sender, EventArgs e)
        {
            RetrievePasswordForm retrieveForm = new RetrievePasswordForm();
            retrieveForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}