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
    public partial class SAttendence : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int studentID;

        public SAttendence(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
            LoadStudentAttendance();
        }

        private void LoadStudentAttendance()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get student's class safely
                    string classQuery = "SELECT Class FROM Students WHERE StudentID = @StudentID";
                    using (SqlCommand classCmd = new SqlCommand(classQuery, conn))
                    {
                        classCmd.Parameters.AddWithValue("@StudentID", studentID);
                        object classObj = classCmd.ExecuteScalar();
                        if (classObj == null || classObj == DBNull.Value)
                        {
                            MessageBox.Show("Student class not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        string studentClass = classObj.ToString();

                        // Get attendance for each subject.
                        // Avoid divide-by-zero by using CASE WHEN COUNT(...) = 0 THEN 0 ELSE ... END
                        string query = @"
                            SELECT s.SubjectName,
                                   COUNT(a.AttendanceID) AS TotalClasses,
                                   SUM(CASE WHEN a.Status = 'Present' THEN 1 ELSE 0 END) AS PresentClasses,
                                   CASE WHEN COUNT(a.AttendanceID) = 0 
                                        THEN CAST(0 AS DECIMAL(5,2))
                                        ELSE CAST(SUM(CASE WHEN a.Status = 'Present' THEN 1.0 ELSE 0 END) * 100.0 / COUNT(a.AttendanceID) AS DECIMAL(5,2))
                                   END AS AttendancePercentage
                            FROM Subjects s
                            LEFT JOIN Attendance a
                              ON s.SubjectID = a.SubjectID
                             AND a.StudentID = @StudentID
                            WHERE s.Class = @Class
                            GROUP BY s.SubjectName
                            ORDER BY s.SubjectName;";

                        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@StudentID", studentID);
                            da.SelectCommand.Parameters.AddWithValue("@Class", studentClass);

                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvAttendance.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
