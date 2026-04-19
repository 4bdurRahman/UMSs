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
    public partial class ADashboard : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        public ADashboard()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Count Students
                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Students", conn);
                    lblStudents.Text = cmd1.ExecuteScalar().ToString();

                    // Count Teachers
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Teachers", conn);
                    lblTeachers.Text = cmd2.ExecuteScalar().ToString();

                    // Count Pending Fees
                    SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Fees WHERE Status = 'Pending'", conn);
                    lblPendingFees.Text = cmd3.ExecuteScalar().ToString();

                    // Count Pending Salary
                    SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Salary WHERE Status = 'Pending'", conn);
                    lblPendingSalary.Text = cmd4.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard: " + ex.Message);
                }
            }
        }
    }

}
