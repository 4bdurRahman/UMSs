using EducationalInstituteManagementSystem.Models;
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
    public partial class SAdmitCard : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int studentID;

        public SAdmitCard(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
        }

        private void btnGetAdmitCard_Click(object sender, EventArgs e)
        {
            GenerateAdmitCard();
        }

        private void GenerateAdmitCard()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get student info
                    string studentQuery = @"SELECT s.* FROM Students s 
                                          WHERE s.StudentID = @StudentID";

                    SqlCommand studentCmd = new SqlCommand(studentQuery, conn);
                    studentCmd.Parameters.AddWithValue("@StudentID", studentID);

                    SqlDataReader reader = studentCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string studentName = reader["FullName"].ToString();
                        string regNo = reader["RegistrationNo"].ToString();
                        string studentClass = reader["Class"].ToString();
                        string section = reader["Section"].ToString();
                        reader.Close();

                        // Generate admit card
                        string examType = cmbExamType.Text;
                        DateTime examDate = dtpExamDate.Value;
                        string seatNo = "SEAT-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string examCenter = "Main Examination Hall, Institute Campus";

                        // Insert into database
                        string insertQuery = @"INSERT INTO AdmitCards (StudentID, ExamType, ExamDate, 
                                             ExamCenter, SeatNo) 
                                             VALUES (@StudentID, @ExamType, @ExamDate, 
                                             @ExamCenter, @SeatNo)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@StudentID", studentID);
                        insertCmd.Parameters.AddWithValue("@ExamType", examType);
                        insertCmd.Parameters.AddWithValue("@ExamDate", examDate);
                        insertCmd.Parameters.AddWithValue("@ExamCenter", examCenter);
                        insertCmd.Parameters.AddWithValue("@SeatNo", seatNo);

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Admit Card Generated Successfully!\n\n" +
                                          $"Name: {studentName}\n" +
                                          $"Registration No: {regNo}\n" +
                                          $"Class: {studentClass} - {section}\n" +
                                          $"Exam Type: {examType}\n" +
                                          $"Exam Date: {examDate.ToString("dd-MMM-yyyy")}\n" +
                                          $"Seat No: {seatNo}\n" +
                                          $"Exam Center: {examCenter}",
                                          "Admit Card", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating admit card: " + ex.Message);
                }
            }
        }

        private void btnPrintAdmitCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing Admit Card\nThis would typically open a print dialog.",
                          "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing Result Card\nThis would typically open a print dialog.",
                          "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
