using EducationalInstituteManagementSystem.Models;
using EducationalInstituteManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EducationalInstituteManagementSystem
{
    public partial class PrintResultForm : Form
    {
        private readonly int _studentID;
        private readonly ResultService _resultService;
        private StudentResultSummary _resultSummary;

        private readonly Color PrimaryColor = Color.FromArgb(41, 128, 185);
        private readonly Color BackgroundColor = Color.FromArgb(236, 240, 241);

        public PrintResultForm(int studentID)
        {
            InitializeComponent();
            _studentID = studentID;
            _resultService = new ResultService();
            ApplyColorScheme();
            LoadResultData();
        }

        private void ApplyColorScheme()
        {
            this.BackColor = BackgroundColor;
            btnPrint.BackColor = PrimaryColor;
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        private void LoadResultData()
        {
            try
            {
                _resultSummary = _resultService.GetStudentResultSummary(_studentID);

                // Display result in preview
                txtResultPreview.Text = GenerateResultText();
                txtResultPreview.Font = new Font("Consolas", 10F);
                txtResultPreview.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading result data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateResultText()
        {
            if (_resultSummary == null) return "No result data available.";

            string result = "EDUCATIONAL INSTITUTE MANAGEMENT SYSTEM\n";
            result += "============================================\n\n";
            result += $"STUDENT RESULT CARD\n";
            result += $"===================\n\n";
            result += $"Student Name: {_resultSummary.Student.FirstName} {_resultSummary.Student.LastName}\n";
            result += $"Registration No: {_resultSummary.Student.RegistrationNo}\n";
            result += $"Class: {_resultSummary.Student.ClassName}\n";
            result += $"Academic Year: 2024\n\n";

            result += "SUBJECT WISE RESULTS:\n";
            result += "---------------------\n";
            result += "Subject               Marks     %     Grade Points\n";
            result += "--------------------------------------------------\n";

            foreach (var subjectResult in _resultSummary.Results)
            {
                result += $"{subjectResult.SubjectName,-20} {subjectResult.MarksObtained,3}/{subjectResult.TotalMarks,-3} ";
                result += $"{subjectResult.Percentage,6:F2}% {subjectResult.Grade,3} {subjectResult.GradePoint,4:F2}\n";
            }

            result += $"\nACADEMIC SUMMARY:\n";
            result += $"-----------------\n";
            result += $"Total Credit Hours: {_resultSummary.TotalCreditHours}\n";
            result += $"Total Grade Points: {_resultSummary.TotalGradePoints:F2}\n";
            result += $"GPA: {_resultSummary.GPA:F2}\n";
            result += $"CGPA: {_resultSummary.AcademicSummary?.CGPA ?? _resultSummary.GPA:F2}\n";
            result += $"Overall Percentage: {_resultSummary.OverallPercentage:F2}%\n\n";

            result += "GRADING SYSTEM:\n";
            result += "---------------\n";

            var grades = _resultService.GetGradingSystem();
            foreach (var grade in grades)
            {
                result += $"{grade.GradeLetter} = {grade.GradePoint:F2} points ({grade.MinPercentage}% - {grade.MaxPercentage}%)\n";
            }

            result += $"\nDate: {DateTime.Now:dd-MMM-yyyy}\n";
            result += "============================================";

            return result;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(PrintResultPage);

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing: {ex.Message}", "Print Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintResultPage(object sender, PrintPageEventArgs e)
        {
            if (_resultSummary == null) return;

            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);
            Font smallFont = new Font("Arial", 8);

            float yPos = 50;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;

            // Header
            e.Graphics.DrawString("EDUCATIONAL INSTITUTE MANAGEMENT SYSTEM", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            e.Graphics.DrawString("STUDENT RESULT CARD", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // Student Info
            e.Graphics.DrawString($"Student Name: {_resultSummary.Student.FirstName} {_resultSummary.Student.LastName}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Registration No: {_resultSummary.Student.RegistrationNo}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Class: {_resultSummary.Student.ClassName}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Academic Year: 2024", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Results Table Header
            e.Graphics.DrawString("Subject", subHeaderFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("Marks", subHeaderFont, Brushes.Black, leftMargin + 150, yPos);
            e.Graphics.DrawString("%", subHeaderFont, Brushes.Black, leftMargin + 220, yPos);
            e.Graphics.DrawString("Grade", subHeaderFont, Brushes.Black, leftMargin + 260, yPos);
            e.Graphics.DrawString("Points", subHeaderFont, Brushes.Black, leftMargin + 320, yPos);
            yPos += 25;

            // Draw line
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Results
            foreach (var result in _resultSummary.Results)
            {
                e.Graphics.DrawString(result.SubjectName, normalFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString($"{result.MarksObtained}/{result.TotalMarks}", normalFont, Brushes.Black, leftMargin + 150, yPos);
                e.Graphics.DrawString($"{result.Percentage:F2}%", normalFont, Brushes.Black, leftMargin + 220, yPos);
                e.Graphics.DrawString(result.Grade, normalFont, Brushes.Black, leftMargin + 260, yPos);
                e.Graphics.DrawString($"{result.GradePoint:F2}", normalFont, Brushes.Black, leftMargin + 320, yPos);
                yPos += 20;
            }

            yPos += 20;

            // Academic Summary
            e.Graphics.DrawString($"GPA: {_resultSummary.GPA:F2}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            e.Graphics.DrawString($"CGPA: {_resultSummary.AcademicSummary?.CGPA ?? _resultSummary.GPA:F2}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            e.Graphics.DrawString($"Overall Percentage: {_resultSummary.OverallPercentage:F2}%", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            // Footer
            e.Graphics.DrawString($"Printed on: {DateTime.Now:dd-MMM-yyyy HH:mm}", smallFont, Brushes.Black, leftMargin, yPos);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}