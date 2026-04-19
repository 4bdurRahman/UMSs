using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class SDashboard : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        int studentID;

        public SDashboard(int studentID)
        {
            InitializeComponent();

            // assign incoming id to the field
            this.studentID = studentID;

            // ensure Load handler is idempotent
            this.Load -= SDashboard_Load;
            this.Load += SDashboard_Load;
        }

        private void SDashboard_Load(object sender, EventArgs e)
        {
            // Designer provides the visual controls (lblWelcome, lblStudentName, lblStudentDetails, pbStudentPhoto)
            // Provide defaults so UI doesn't show nulls
            lblWelcome.Text = "Welcome!";
            lblStudentName.Text = "";
            lblStudentDetails.Text = "Loading student information...";

            if (studentID <= 0)
            {
                lblWelcome.Text = "Welcome!";
                lblStudentName.Text = "Student not identified";
                lblStudentDetails.Text = "";
                return;
            }
                
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query only columns that exist in your Students table
                    string query = @"
                        SELECT FullName,
                               RegistrationNo,
                               FatherName,
                               ISNULL(CONVERT(varchar(10), DOB, 103), '') AS DOB,
                               ISNULL(Contact,'') AS Contact,
                               ISNULL(Address,'') AS Address,
                               ISNULL([Class],'') AS Class,
                               ISNULL([Section],'') AS Section,
                               ISNULL(CONVERT(varchar(10), AdmissionDate, 103), '') AS AdmissionDate
                        FROM Students
                        WHERE StudentID = @StudentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader["FullName"]?.ToString() ?? "";
                                string regNo = reader["RegistrationNo"]?.ToString() ?? "";
                                string father = reader["FatherName"]?.ToString() ?? "";
                                string dob = reader["DOB"]?.ToString() ?? "";
                                string contact = reader["Contact"]?.ToString() ?? "";
                                string address = reader["Address"]?.ToString() ?? "";
                                string cls = reader["Class"]?.ToString() ?? "";
                                string section = reader["Section"]?.ToString() ?? "";
                                string admission = reader["AdmissionDate"]?.ToString() ?? "";

                                lblWelcome.Text = $"Welcome, {fullName}!";

 lblStudentName.Text = fullName;

                                // Nicely formatted details block
                                lblStudentDetails.Text =
                                    $"Registration No: {regNo}{Environment.NewLine}" +
                                    $"Father's Name: {father}{Environment.NewLine}" +
                                    $"Class / Section: {cls} / {section}{Environment.NewLine}" +
                                    (string.IsNullOrWhiteSpace(dob) ? "" : $"DOB: {dob}{Environment.NewLine}") +
                                    (string.IsNullOrWhiteSpace(admission) ? "" : $"Admission Date: {admission}{Environment.NewLine}") +
                                    (string.IsNullOrWhiteSpace(contact) ? "" : $"Contact: {contact}{Environment.NewLine}") +
                                    (string.IsNullOrWhiteSpace(address) ? "" : $"Address: {address}");

                                // Optional: load photo if you have a Photo column (uncomment and adjust)
                                // if (!reader.IsDBNull(reader.GetOrdinal("Photo")))
                                // {
                                //     var bytes = (byte[])reader["Photo"];
                                //     using (var ms = new System.IO.MemoryStream(bytes))
                                //         pbStudentPhoto.Image = Image.FromStream(ms);
                                // }

                                // Styling for clarity (designer fonts preserved; adjust if needed)
                                lblWelcome.Font = new Font(lblWelcome.Font.FontFamily, 18, FontStyle.Bold);
                                lblStudentName.Font = new Font(lblStudentName.Font.FontFamily, 12, FontStyle.Regular);
                            }
                            else
                            {
                                lblWelcome.Text = "Welcome!";
                                lblStudentName.Text = "Student record not found";
                                lblStudentDetails.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStudentDetails.Text = "Unable to load student data.";
            }
        }
    }
}