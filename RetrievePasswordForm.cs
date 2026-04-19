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
    public partial class RetrievePasswordForm : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public RetrievePasswordForm()
        {
            InitializeComponent();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string cnic = txtCNIC.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(cnic) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter both CNIC and Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Username, Password FROM Users WHERE CNIC = @CNIC AND Email = @Email";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string username = reader["Username"].ToString();
                        string password = reader["Password"].ToString();

                        MessageBox.Show($"Username: {username}\nPassword: {password}", "Password Retrieved",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No account found with provided CNIC and Email!", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}