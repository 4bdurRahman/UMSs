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
    public partial class SResult : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        int studentID;

        public SResult(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
            LoadStudentResults();
            
        }
        private void LoadStudentResults()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT r.*, s.SubjectName, 
                                   CAST((r.MarksObtained * 100.0 / r.TotalMarks) AS DECIMAL(5,2)) as Percentage
                                   FROM Results r 
                                   INNER JOIN Subjects s ON r.SubjectID = s.SubjectID
                                   WHERE r.StudentID = @StudentID 
                                   ORDER BY r.ExamType, s.SubjectName";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@StudentID", studentID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvResults.DataSource = dt;

                    // Calculate and display overall percentage
                    if (dt.Rows.Count > 0)
                    {
                        decimal totalMarks = 0;
                        decimal totalObtained = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            totalObtained += Convert.ToDecimal(row["MarksObtained"]);
                            totalMarks += Convert.ToDecimal(row["TotalMarks"]);
                        }

                        decimal overallPercentage = (totalObtained * 100) / totalMarks;
                        lblOverallPercentage.Text = overallPercentage.ToString("0.00") + "%";
                        lblOverallGrade.Text = CalculateOverallGrade(overallPercentage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading results: " + ex.Message);
                }
            }
        }

        private string CalculateOverallGrade(decimal percentage)
        {
            if (percentage >= 90) return "A+";
            else if (percentage >= 80) return "A";
            else if (percentage >= 70) return "B";
            else if (percentage >= 60) return "C";
            else if (percentage >= 50) return "D";
            else return "F";
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
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
    }
}
