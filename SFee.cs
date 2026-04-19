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
    public partial class SFee : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        int studentID;

        public SFee(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
            LoadFeeStatus();
            
        }

        private void LoadFeeStatus()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT FeeID, FeeType, Amount, DueDate, PaidAmount, 
                                   PaymentDate, Status, ChallanNo,
                                   (Amount - PaidAmount) as RemainingAmount
                                   FROM Fees 
                                   WHERE StudentID = @StudentID
                                   ORDER BY DueDate";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@StudentID", studentID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvFees.DataSource = dt;

                    // Calculate summary
                    decimal totalDue = 0;
                    decimal totalPaid = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        totalDue += Convert.ToDecimal(row["Amount"]);
                        totalPaid += Convert.ToDecimal(row["PaidAmount"]);
                    }

                    lblTotalDue.Text = totalDue.ToString("C");
                    lblTotalPaid.Text = totalPaid.ToString("C");
                    lblRemaining.Text = (totalDue - totalPaid).ToString("C");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading fee status: " + ex.Message);
                }
            }
        }

        private void btnGetFeeChallan_Click(object sender, EventArgs e)
        {
            if (dgvFees.SelectedRows.Count > 0)
            {
                string challanNo = dgvFees.SelectedRows[0].Cells["ChallanNo"].Value.ToString();
                PrintFeeChallan(challanNo);
            }
        }

        private void PrintFeeChallan(string challanNo)
        {
            MessageBox.Show("Printing Fee Challan: " + challanNo + "\nThis would typically open a print dialog.",
                          "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetFeeChallan_Click_1(object sender, EventArgs e)
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
