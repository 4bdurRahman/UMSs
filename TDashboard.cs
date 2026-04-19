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
    public partial class TDashboard : Form
    {
        int teacherID;
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public TDashboard(int teacherID)
        {
            this.teacherID = teacherID;
            InitializeComponent();
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get assigned classes count
                    string query1 = @"SELECT COUNT(DISTINCT Class) 
                                     FROM Subjects WHERE TeacherID = @TeacherID";
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.Parameters.AddWithValue("@TeacherID", teacherID);
                    lblClassesCount.Text = cmd1.ExecuteScalar().ToString();

                    // Get students count in assigned classes
                    string query2 = @"SELECT COUNT(DISTINCT s.StudentID) 
                                     FROM Students s
                                     INNER JOIN Subjects sub ON s.Class = sub.Class
                                     WHERE sub.TeacherID = @TeacherID";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.Parameters.AddWithValue("@TeacherID", teacherID);
                    lblStudentsCount.Text = cmd2.ExecuteScalar().ToString();

                    // Get assignments posted
                    string query3 = @"SELECT COUNT(*) FROM Assignments 
                                     WHERE TeacherID = @TeacherID";
                    SqlCommand cmd3 = new SqlCommand(query3, conn);
                    cmd3.Parameters.AddWithValue("@TeacherID", teacherID);
                    lblAssignmentsCount.Text = cmd3.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard stats: " + ex.Message);
                }
            }
        }

    }
}
