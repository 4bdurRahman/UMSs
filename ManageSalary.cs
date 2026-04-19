using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
// disambiguate Font types
using iTextFont = iTextSharp.text.Font;
using DrawingFont = System.Drawing.Font;

namespace EducationalInstituteManagementSystem
{
    public partial class ManageSalary : Form
    {
        string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        private int selectedSalaryId = -1;

        // Printing members
        private PrintDocument printDocSalary;
        private PrintDialog printDialogSalary;
        private PrintPreviewDialog printPreviewSalary;
        private DataGridViewRow printRowSalary;

        public ManageSalary()
        {
            InitializeComponent();
            LoadSalary();
            LoadTeachersForSalary();

            // Defensive, idempotent event wiring
            if (dgvSalary != null)
            {
                dgvSalary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSalary.MultiSelect = false;

                // Allow inline edits on enter (single click to edit)
                dgvSalary.ReadOnly = false;
                dgvSalary.EditMode = DataGridViewEditMode.EditOnEnter;

                // Make certain columns read-only (ids, computed, display-only)
                dgvSalary.CellClick -= dgvSalary_CellClick;
                dgvSalary.CellClick += dgvSalary_CellClick;

                dgvSalary.CellEndEdit -= dgvSalary_CellEndEdit;
                dgvSalary.CellEndEdit += dgvSalary_CellEndEdit;
            }

            // If update/delete buttons exist in designer, wire them safely
            if (btnGenerateSalary != null)
            {
                // keep existing Generate handler (already wired in designer)
            }
            if (btnPrintSalarySlip != null)
            {
                // keep existing Print handler (already wired in designer)
            }
            // Optional: wire update/delete if you have buttons named btnUpdateSalary / btnDeleteSalary
            if (this.Controls != null)
            {
                var btnUpdate = this.Controls.Find("btnUpdateSalary", true);
                if (btnUpdate.Length > 0 && btnUpdate[0] is Button updateButton)
                {
                    updateButton.Click -= btnUpdateSalary_Click;
                    updateButton.Click += btnUpdateSalary_Click;
                }

                var btnDelete = this.Controls.Find("btnDeleteSalary", true);
                if (btnDelete.Length > 0 && btnDelete[0] is Button deleteButton)
                {
                    deleteButton.Click -= btnDeleteSalary_Click;
                    deleteButton.Click += btnDeleteSalary_Click;
                }
            }

            // Initialize printing objects for salary
            printDocSalary = new PrintDocument();
            printDocSalary.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            printDocSalary.PrintPage -= PrintDocSalary_PrintPage;
            printDocSalary.PrintPage += PrintDocSalary_PrintPage;

            printDialogSalary = new PrintDialog { UseEXDialog = true };
            printPreviewSalary = new PrintPreviewDialog { Document = printDocSalary };
        }

        // ================= LOAD SALARY =================
        private void LoadSalary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT s.*, t.FullName AS TeacherName
                                     FROM Salary s
                                     INNER JOIN Teachers t ON s.TeacherID = t.TeacherID";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSalary.DataSource = dt;

                    // Set column-level readonly after binding to avoid making primary key editable
                    if (dgvSalary.Columns.Contains("SalaryID"))
                        dgvSalary.Columns["SalaryID"].ReadOnly = true;
                    if (dgvSalary.Columns.Contains("TeacherID"))
                        dgvSalary.Columns["TeacherID"].ReadOnly = true;
                    if (dgvSalary.Columns.Contains("TeacherName"))
                        dgvSalary.Columns["TeacherName"].ReadOnly = true;
                    if (dgvSalary.Columns.Contains("SalarySlipNo"))
                        dgvSalary.Columns["SalarySlipNo"].ReadOnly = true;
                    if (dgvSalary.Columns.Contains("NetSalary"))
                        dgvSalary.Columns["NetSalary"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load Error: " + ex.Message);
                }
            }
        }

        // ================= LOAD TEACHERS =================
        private void LoadTeachersForSalary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da =
                        new SqlDataAdapter("SELECT TeacherID, FullName FROM Teachers", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbSalaryTeacher.DataSource = dt;
                    cmbSalaryTeacher.DisplayMember = "FullName";
                    cmbSalaryTeacher.ValueMember = "TeacherID";
                    cmbSalaryTeacher.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Teacher Load Error: " + ex.Message);
                }
            }
        }

        // ================= GENERATE SALARY =================
        private void btnGenerateSalary_Click_1(object sender, EventArgs e)
        {
            try
            {
                int teacherID = Convert.ToInt32(cmbSalaryTeacher.SelectedValue);
                string month = cmbSalaryMonth.Text;
                int year = Convert.ToInt32(txtSalaryYear.Text);

                decimal basic = Convert.ToDecimal(txtBasicSalary.Text);
                decimal allow = Convert.ToDecimal(txtAllowances.Text);
                decimal deduct = Convert.ToDecimal(txtDeductions.Text);
                decimal net = basic + allow - deduct;

                string slipNo = "SAL-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Salary
                        (TeacherID, Month, Year, BasicSalary, Allowances,
                         Deductions, NetSalary, SalarySlipNo)
                        VALUES
                        (@TeacherID,@Month,@Year,@Basic,@Allow,@Deduct,@Net,@Slip)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Basic", basic);
                        cmd.Parameters.AddWithValue("@Allow", allow);
                        cmd.Parameters.AddWithValue("@Deduct", deduct);
                        cmd.Parameters.AddWithValue("@Net", net);
                        cmd.Parameters.AddWithValue("@Slip", slipNo);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Salary Generated!\nSlip: " + slipNo);
                LoadSalary();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Generate Error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtBasicSalary.Clear();
            txtAllowances.Clear();
            txtDeductions.Clear();
            txtSalaryYear.Clear();
            cmbSalaryMonth.SelectedIndex = -1;
            cmbSalaryTeacher.SelectedIndex = -1;
            selectedSalaryId = -1;
        }

        // ================= PRINT / EXPORT PDF =================
        private void btnPrintSalarySlip_Click_1(object sender, EventArgs e)
        {
            if (dgvSalary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a salary record.");
                return;
            }

            // Set the row that will be printed
            printRowSalary = dgvSalary.SelectedRows[0];

            // Ask user for action (Preview / Print / Export PDF)
            var res = MessageBox.Show("Choose action:\nYes = Preview\nNo = Print\nCancel = Export PDF",
                                       "Print or Export", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            try
            {
                if (res == DialogResult.Yes)
                {
                    // Preview
                    printPreviewSalary.Document = printDocSalary;
                    printPreviewSalary.ShowDialog();
                }
                else if (res == DialogResult.No)
                {
                    // Print directly via PrintDialog
                    printDialogSalary.Document = printDocSalary;
                    if (printDialogSalary.ShowDialog() == DialogResult.OK)
                    {
                        printDocSalary.Print();
                    }
                }
                else
                {
                    // Export to PDF (existing behavior)
                    string folder =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pdfs");

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string filePath = Path.Combine(
                        folder, "SalarySlip_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");

                    ExportPDF(filePath);

                    MessageBox.Show("PDF Created:\n" + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing/Export error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= PDF USING ITEXTSHARP =================
        private void ExportPDF(string path)
        {
            DataGridViewRow row = dgvSalary.SelectedRows[0];

            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            doc.Open();

            // use aliased iTextSharp font type to avoid ambiguity
            iTextFont title = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            iTextFont text = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            doc.Add(new Paragraph("SALARY SLIP\n\n", title));

            doc.Add(new Paragraph("Teacher: " + row.Cells["TeacherName"].Value, text));
            doc.Add(new Paragraph("Month: " + row.Cells["Month"].Value, text));
            doc.Add(new Paragraph("Year: " + row.Cells["Year"].Value, text));
            doc.Add(new Paragraph("Basic Salary: " + row.Cells["BasicSalary"].Value, text));
            doc.Add(new Paragraph("Allowances: " + row.Cells["Allowances"].Value, text));
            doc.Add(new Paragraph("Deductions: " + row.Cells["Deductions"].Value, text));
            doc.Add(new Paragraph("Net Salary: " + row.Cells["NetSalary"].Value, text));

            doc.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        // PrintPage event for Salary print
        private void PrintDocSalary_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (printRowSalary == null)
                {
                    e.HasMorePages = false;
                    return;
                }

                Graphics g = e.Graphics;
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int lineHeight = 24;

                // use aliased System.Drawing.Font type to avoid ambiguity
                using (DrawingFont titleFont = new DrawingFont("Arial", 14, System.Drawing.FontStyle.Bold))
                using (DrawingFont labelFont = new DrawingFont("Arial", 10, System.Drawing.FontStyle.Bold))
                using (DrawingFont valueFont = new DrawingFont("Arial", 10))
                {
                    g.DrawString("SALARY SLIP", titleFont, Brushes.Black, x, y);
                    y += lineHeight * 2;

                    string slipNo = GetCellString(printRowSalary, "SalarySlipNo");
                    g.DrawString("Slip No: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(slipNo, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string teacher = GetCellString(printRowSalary, "TeacherName");
                    g.DrawString("Teacher: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(teacher, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string month = GetCellString(printRowSalary, "Month");
                    string year = GetCellString(printRowSalary, "Year");
                    g.DrawString("Period: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(month + " / " + year, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string basic = GetCellString(printRowSalary, "BasicSalary");
                    g.DrawString("Basic Salary: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(basic, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string allow = GetCellString(printRowSalary, "Allowances");
                    g.DrawString("Allowances: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(allow, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string deduct = GetCellString(printRowSalary, "Deductions");
                    g.DrawString("Deductions: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(deduct, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string net = GetCellString(printRowSalary, "NetSalary");
                    g.DrawString("Net Salary: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(net, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight * 2;

                    g.DrawString("Authorized Signature: ____________________", valueFont, Brushes.Black, x, y);
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print page error: " + ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
            }
        }

        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row == null || !dgvSalary.Columns.Contains(columnName)) return string.Empty;
            var v = row.Cells[columnName].Value;
            if (v == null || v == DBNull.Value) return string.Empty;
            if (v is DateTime dt) return dt.ToShortDateString();
            return v.ToString();
        }

        // ================= DGV CLICK -> POPULATE FIELDS FOR EDIT =================
        private void dgvSalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvSalary.Rows[e.RowIndex];

                // Attempt to read SalaryID (common names: SalaryID, SalaryId, ID)
                selectedSalaryId = -1;
                if (dgvSalary.Columns.Contains("SalaryID") && row.Cells["SalaryID"].Value != DBNull.Value)
                    selectedSalaryId = Convert.ToInt32(row.Cells["SalaryID"].Value);
                else if (dgvSalary.Columns.Contains("SalaryId") && row.Cells["SalaryId"].Value != DBNull.Value)
                    selectedSalaryId = Convert.ToInt32(row.Cells["SalaryId"].Value);
                else if (dgvSalary.Columns.Contains("ID") && row.Cells["ID"].Value != DBNull.Value)
                    selectedSalaryId = Convert.ToInt32(row.Cells["ID"].Value);

                // Teacher
                if (dgvSalary.Columns.Contains("TeacherID") && row.Cells["TeacherID"].Value != DBNull.Value)
                {
                    int teacherId = Convert.ToInt32(row.Cells["TeacherID"].Value);
                    cmbSalaryTeacher.SelectedValue = teacherId;
                }
                else if (dgvSalary.Columns.Contains("TeacherName") && row.Cells["TeacherName"].Value != DBNull.Value)
                {
                    // fallback to match by display name
                    string tName = row.Cells["TeacherName"].Value.ToString();
                    int idx = cmbSalaryTeacher.FindStringExact(tName);
                    cmbSalaryTeacher.SelectedIndex = idx >= 0 ? idx : -1;
                }
                else
                {
                    cmbSalaryTeacher.SelectedIndex = -1;
                }

                // Month
                if (dgvSalary.Columns.Contains("Month") && row.Cells["Month"].Value != DBNull.Value)
                    cmbSalaryMonth.Text = row.Cells["Month"].Value.ToString();
                else
                    cmbSalaryMonth.SelectedIndex = -1;

                // Year
                if (dgvSalary.Columns.Contains("Year") && row.Cells["Year"].Value != DBNull.Value)
                    txtSalaryYear.Text = row.Cells["Year"].Value.ToString();
                else
                    txtSalaryYear.Clear();

                // Basic / Allow / Deduct
                if (dgvSalary.Columns.Contains("BasicSalary") && row.Cells["BasicSalary"].Value != DBNull.Value)
                    txtBasicSalary.Text = row.Cells["BasicSalary"].Value.ToString();
                else
                    txtBasicSalary.Clear();

                if (dgvSalary.Columns.Contains("Allowances") && row.Cells["Allowances"].Value != DBNull.Value)
                    txtAllowances.Text = row.Cells["Allowances"].Value.ToString();
                else
                    txtAllowances.Clear();

                if (dgvSalary.Columns.Contains("Deductions") && row.Cells["Deductions"].Value != DBNull.Value)
                    txtDeductions.Text = row.Cells["Deductions"].Value.ToString();
                else
                    txtDeductions.Clear();

                // Select the clicked row so update/delete use SelectedRows if needed
                dgvSalary.ClearSelection();
                dgvSalary.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting salary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CELL EDIT -> PERSIST INLINE CHANGES =================
        private void dgvSalary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvSalary.Rows[e.RowIndex];
                string colName = dgvSalary.Columns[e.ColumnIndex].Name;

                // Determine salary id from row
                int salaryId = -1;
                if (dgvSalary.Columns.Contains("SalaryID") && row.Cells["SalaryID"].Value != DBNull.Value)
                    salaryId = Convert.ToInt32(row.Cells["SalaryID"].Value);
                else if (dgvSalary.Columns.Contains("SalaryId") && row.Cells["SalaryId"].Value != DBNull.Value)
                    salaryId = Convert.ToInt32(row.Cells["SalaryId"].Value);
                else if (dgvSalary.Columns.Contains("ID") && row.Cells["ID"].Value != DBNull.Value)
                    salaryId = Convert.ToInt32(row.Cells["ID"].Value);

                if (salaryId <= 0)
                    return;

                // Editable numeric fields: BasicSalary, Allowances, Deductions
                if (colName == "BasicSalary" || colName == "Allowances" || colName == "Deductions")
                {
                    decimal basic = TryGetDecimal(row, "BasicSalary");
                    decimal allow = TryGetDecimal(row, "Allowances");
                    decimal deduct = TryGetDecimal(row, "Deductions");
                    decimal net = basic + allow - deduct;

                    // Update all salary amount fields and NetSalary atomically
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string q = @"UPDATE Salary SET BasicSalary=@Basic, Allowances=@Allow, Deductions=@Deduct, NetSalary=@Net
                                     WHERE SalaryID=@SalaryID";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@Basic", basic);
                            cmd.Parameters.AddWithValue("@Allow", allow);
                            cmd.Parameters.AddWithValue("@Deduct", deduct);
                            cmd.Parameters.AddWithValue("@Net", net);
                            cmd.Parameters.AddWithValue("@SalaryID", salaryId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Reflect computed NetSalary in grid
                    if (dgvSalary.Columns.Contains("NetSalary"))
                        row.Cells["NetSalary"].Value = net;
                }
                else if (colName == "Month" || colName == "Year")
                {
                    // Update single column
                    object newVal = row.Cells[colName].Value ?? DBNull.Value;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string q = $"UPDATE Salary SET [{colName}] = @Val WHERE SalaryID = @SalaryID";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@Val", newVal ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@SalaryID", salaryId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    // Non-editable or unsupported columns: ignore
                }

                // Keep row selected after edit
                dgvSalary.ClearSelection();
                dgvSalary.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cell change: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadSalary(); // reload to restore consistent state
            }
        }

        private decimal TryGetDecimal(DataGridViewRow row, string columnName)
        {
            if (!dgvSalary.Columns.Contains(columnName)) return 0m;
            var v = row.Cells[columnName].Value;
            if (v == null || v == DBNull.Value) return 0m;
            decimal outVal;
            if (decimal.TryParse(Convert.ToString(v), out outVal)) return outVal;
            return 0m;
        }

        // ================= OPTIONAL: UPDATE SELECTED SALARY =================
        // Adds an Update button handler if you add a btnUpdateSalary button in the designer.
        private void btnUpdateSalary_Click(object sender, EventArgs e)
        {
            if (selectedSalaryId <= 0)
            {
                MessageBox.Show("Please select a salary record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int teacherID = cmbSalaryTeacher.SelectedValue != null ? Convert.ToInt32(cmbSalaryTeacher.SelectedValue) : 0;
                string month = cmbSalaryMonth.Text;
                int year = 0;
                int.TryParse(txtSalaryYear.Text, out year);

                decimal basic = 0, allow = 0, deduct = 0;
                decimal.TryParse(txtBasicSalary.Text, out basic);
                decimal.TryParse(txtAllowances.Text, out allow);
                decimal.TryParse(txtDeductions.Text, out deduct);
                decimal net = basic + allow - deduct;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Salary SET TeacherID=@TeacherID, Month=@Month, Year=@Year,
                                     BasicSalary=@Basic, Allowances=@Allow, Deductions=@Deduct, NetSalary=@Net
                                     WHERE SalaryID=@SalaryID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        cmd.Parameters.AddWithValue("@Month", month ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Basic", basic);
                        cmd.Parameters.AddWithValue("@Allow", allow);
                        cmd.Parameters.AddWithValue("@Deduct", deduct);
                        cmd.Parameters.AddWithValue("@Net", net);
                        cmd.Parameters.AddWithValue("@SalaryID", selectedSalaryId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Salary updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSalary();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Verify the selected record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating salary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= OPTIONAL: DELETE SELECTED SALARY =================
        // Adds a Delete button handler if you add a btnDeleteSalary button in the designer.
        private void btnDeleteSalary_Click(object sender, EventArgs e)
        {
            if (selectedSalaryId <= 0)
            {
                MessageBox.Show("Please select a salary record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("Are you sure you want to delete the selected salary record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Salary WHERE SalaryID = @SalaryID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SalaryID", selectedSalaryId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Salary record deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSalary();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. Verify the selected record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting salary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
