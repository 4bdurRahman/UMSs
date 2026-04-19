using EducationalInstituteManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class TSalary : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int teacherID;
        public TSalary(int teacherID)
        {
            this.teacherID = teacherID;
            InitializeComponent();

            LoadTeacherSalary();
        }

        private void LoadTeacherSalary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT SalarySlipNo, Month, Year, NetSalary, Status, PaymentDate
                                   FROM Salary 
                                   WHERE TeacherID = @TeacherID 
                                   ORDER BY Year DESC, 
                                   CASE Month 
                                       WHEN 'January' THEN 1
                                       WHEN 'February' THEN 2
                                       WHEN 'March' THEN 3
                                       WHEN 'April' THEN 4
                                       WHEN 'May' THEN 5
                                       WHEN 'June' THEN 6
                                       WHEN 'July' THEN 7
                                       WHEN 'August' THEN 8
                                       WHEN 'September' THEN 9
                                       WHEN 'October' THEN 10
                                       WHEN 'November' THEN 11
                                       WHEN 'December' THEN 12
                                   END DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@TeacherID", teacherID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSalary.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading salary: " + ex.Message);
                }
            }
        }

        private void btnViewSalary_Click(object sender, EventArgs e)
        {
            LoadTeacherSalary();
        }

        private void btnPrintSalary_Click(object sender, EventArgs e)
        {
            if (dgvSalary.SelectedRows.Count > 0)
            {
                string slipNo = dgvSalary.SelectedRows[0].Cells["SalarySlipNo"].Value.ToString();
                PrintSalarySlip(slipNo);
            }
            else
            {
                MessageBox.Show("Please select a salary record to print!", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintSalarySlip(string slipNo)
        {
            MessageBox.Show($"Printing Salary Slip: {slipNo}\n\n" +
                          "This would open a print dialog in the full version.",
                          "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintSalary_Click_1(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            string filePath = @"C:\Users\Win\Desktop\VP Projects\hello.pdf";   // choose any path
            //export pdf helper
            void ExportPDF(string exportFilePath)
            {
                PrintDocument printDoc = new PrintDocument();

                // Use Microsoft Print to PDF
                printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDoc.PrinterSettings.PrintToFile = true;
                printDoc.PrinterSettings.PrintFileName = exportFilePath;

                printDoc.PrintPage += (s, ev) =>
                {
                    Font font = new Font("Arial", 12);
                    ev.Graphics.DrawString(
                        "Hello, this PDF is generated using Microsoft official printing.",
                        font,
                        Brushes.Black,
                        new PointF(100, 100)
                    );
                };

                printDoc.Print();
            }
            ExportPDF(@"C:\Users\Public\official_pdf.pdf");
        }

        private void TSalary_Load(object sender, EventArgs e)
        {

        }

        // Tab Switching
        //private void tabControlTeacher_Selected(object sender, TabControlEventArgs e)
        //{
        //    isLoading = true;

        //    try
        //    {
        //        switch (e.TabPage.Name)
        //        {
        //            case "tabPageDashboard":
        //                LoadDashboardStats();
        //                break;

        //            case "tabPageAddResults":
        //                break;

        //            case "tabPageAttendance":
        //                LoadClassesForAttendance();
        //                break;

        //            case "tabPageAssignments":
        //                LoadClassesForAssignments();
        //                break;

        //            case "tabPageSalary":
        //                LoadTeacherSalary();
        //                break;
        //        }
        //    }
        //    finally
        //    {
        //        isLoading = false;
        //    }
        //}
    }
}
