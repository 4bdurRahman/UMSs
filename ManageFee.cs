using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class ManageFee : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";
        private int selectedFeeId = -1;

        // Printing members
        private PrintDocument printDocFee;
        private PrintDialog printDialogFee;
        private PrintPreviewDialog printPreviewFee;
        private DataGridViewRow printRowFee;

        public ManageFee()
        {
            InitializeComponent();
            LoadFees();
            LoadStudentsForFees();

            // Defensive, idempotent wiring and enable inline edit
            if (dgvFees != null)
            {
                dgvFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFees.MultiSelect = false;

                // allow inline edits on enter
                dgvFees.ReadOnly = false;
                dgvFees.EditMode = DataGridViewEditMode.EditOnEnter;

                dgvFees.CellClick -= dgvFees_CellClick;
                dgvFees.CellClick += dgvFees_CellClick;

                dgvFees.CellEndEdit -= dgvFees_CellEndEdit;
                dgvFees.CellEndEdit += dgvFees_CellEndEdit;
            }

            // Initialize printing objects
            printDocFee = new PrintDocument();
            printDocFee.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            printDocFee.PrintPage -= PrintDocFee_PrintPage;
            printDocFee.PrintPage += PrintDocFee_PrintPage;

            printDialogFee = new PrintDialog { UseEXDialog = true };
            printPreviewFee = new PrintPreviewDialog();
            // associate the document with preview dialog (preview control in WinForms requires this)
            printPreviewFee.Document = printDocFee;
        }

        private void LoadFees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT f.*, s.FullName as StudentName 
                                   FROM Fees f 
                                   INNER JOIN Students s ON f.StudentID = s.StudentID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFees.DataSource = dt;

                    // Make ID and display-only columns read-only
                    if (dgvFees.Columns.Contains("FeeID"))
                        dgvFees.Columns["FeeID"].ReadOnly = true;
                    if (dgvFees.Columns.Contains("FeeId"))
                        dgvFees.Columns["FeeId"].ReadOnly = true;
                    if (dgvFees.Columns.Contains("ChallanNo"))
                        dgvFees.Columns["ChallanNo"].ReadOnly = true;
                    if (dgvFees.Columns.Contains("StudentName"))
                        dgvFees.Columns["StudentName"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading fees: " + ex.Message);
                }
            }
        }

        private void btnGenerateFee_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintFeeSlip_Click(object sender, EventArgs e)
        {

        }

        private void PrintFeeChallan(string challanNo)
        {
            // Simple printing implementation fallback
            MessageBox.Show("Printing Fee Challan: " + challanNo + "\nThis would typically open a print dialog.",
                          "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ClearFeeFields()
        {
            txtFeeAmount.Clear();
            cmbFeeType.SelectedIndex = -1;
            dtpFeeDueDate.Value = DateTime.Now.AddMonths(1);
            cmbFeeStudent.SelectedIndex = -1;
            selectedFeeId = -1;
        }

        private void LoadStudentsCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StudentID, FullName FROM Students";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbFeeStudent.DataSource = dt;
                    cmbFeeStudent.DisplayMember = "FullName";
                    cmbFeeStudent.ValueMember = "StudentID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message);
                }
            }
        }
        private void LoadStudentsForFees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StudentID, FullName FROM Students";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbFeeStudent.DataSource = dt;
                    cmbFeeStudent.DisplayMember = "FullName";
                    cmbFeeStudent.ValueMember = "StudentID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message);
                }
            }
        }

        private void btnGenerateFee_Click_1(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(cmbFeeStudent.SelectedValue);
            string feeType = cmbFeeType.Text;
            decimal amount = Convert.ToDecimal(txtFeeAmount.Text);
            DateTime dueDate = dtpFeeDueDate.Value;
            string challanNo = "CHL-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Fees (StudentID, FeeType, Amount, DueDate, ChallanNo) " +
                                   "VALUES (@StudentID, @FeeType, @Amount, @DueDate, @ChallanNo)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@FeeType", feeType);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@ChallanNo", challanNo);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Fee challan generated successfully!\nChallan No: " + challanNo,
                                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFeeFields();
                        LoadFees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Updated: print using PrintDocument + PrintDialog + Preview
        private void btnPrintFeeSlip_Click_1(object sender, EventArgs e)
        {
            if (dgvFees.SelectedRows.Count > 0)
            {
                printRowFee = dgvFees.SelectedRows[0];

                // Ask user whether to preview or print
                var dr = MessageBox.Show("Preview before printing?\nYes = Preview, No = Print directly, Cancel = Cancel", "Print",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Cancel) return;

                try
                {
                    if (dr == DialogResult.Yes)
                    {
                        // Show print preview
                        printPreviewFee.Document = printDocFee;
                        // Some systems require calling ShowDialog on UI thread
                        printPreviewFee.ShowDialog();
                    }
                    else
                    {
                        // Show print dialog
                        printDialogFee.Document = printDocFee;
                        if (printDialogFee.ShowDialog() == DialogResult.OK)
                        {
                            printDocFee.Print();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Printing error: " + ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // PrintPage event - renders the fee challan content
        private void PrintDocFee_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (printRowFee == null)
                {
                    e.HasMorePages = false;
                    return;
                }

                var g = e.Graphics;
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int lineHeight = 24;

                using (Font titleFont = new Font("Arial", 14, FontStyle.Bold))
                using (Font labelFont = new Font("Arial", 10, FontStyle.Bold))
                using (Font valueFont = new Font("Arial", 10))
                {
                    g.DrawString("FEE CHALLAN", titleFont, Brushes.Black, x, y);
                    y += lineHeight * 2;

                    string challan = GetCellString(printRowFee, "ChallanNo");
                    g.DrawString("Challan No: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(challan, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string student = GetCellString(printRowFee, "StudentName");
                    g.DrawString("Student: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(student, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string feeType = GetCellString(printRowFee, "FeeType");
                    g.DrawString("Fee Type: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(feeType, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string amount = GetCellString(printRowFee, "Amount");
                    g.DrawString("Amount: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(amount, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight;

                    string due = GetCellString(printRowFee, "DueDate");
                    g.DrawString("Due Date: ", labelFont, Brushes.Black, x, y);
                    g.DrawString(due, valueFont, Brushes.Black, x + 120, y);
                    y += lineHeight * 2;

                    g.DrawString("Thank you.", valueFont, Brushes.Black, x, y);
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
            if (row == null || !dgvFees.Columns.Contains(columnName)) return string.Empty;
            var v = row.Cells[columnName].Value;
            if (v == null || v == DBNull.Value) return string.Empty;
            if (v is DateTime dt) return dt.ToShortDateString();
            return v.ToString();
        }

        // ================= DGV CLICK -> POPULATE FIELDS FOR EDIT =================
        private void dgvFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvFees.Rows[e.RowIndex];

                // Attempt to read FeeID (common names: FeeID, FeeId, ID)
                selectedFeeId = -1;
                if (dgvFees.Columns.Contains("FeeID") && row.Cells["FeeID"].Value != DBNull.Value)
                    selectedFeeId = Convert.ToInt32(row.Cells["FeeID"].Value);
                else if (dgvFees.Columns.Contains("FeeId") && row.Cells["FeeId"].Value != DBNull.Value)
                    selectedFeeId = Convert.ToInt32(row.Cells["FeeId"].Value);
                else if (dgvFees.Columns.Contains("ID") && row.Cells["ID"].Value != DBNull.Value)
                    selectedFeeId = Convert.ToInt32(row.Cells["ID"].Value);

                // Student
                if (dgvFees.Columns.Contains("StudentID") && row.Cells["StudentID"].Value != DBNull.Value)
                {
                    int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                    cmbFeeStudent.SelectedValue = studentId;
                }
                else if (dgvFees.Columns.Contains("StudentName") && row.Cells["StudentName"].Value != DBNull.Value)
                {
                    string sName = row.Cells["StudentName"].Value.ToString();
                    int idx = cmbFeeStudent.FindStringExact(sName);
                    cmbFeeStudent.SelectedIndex = idx >= 0 ? idx : -1;
                }
                else
                {
                    cmbFeeStudent.SelectedIndex = -1;
                }

                // FeeType
                if (dgvFees.Columns.Contains("FeeType") && row.Cells["FeeType"].Value != DBNull.Value)
                    cmbFeeType.Text = row.Cells["FeeType"].Value.ToString();
                else
                    cmbFeeType.SelectedIndex = -1;

                // Amount
                if (dgvFees.Columns.Contains("Amount") && row.Cells["Amount"].Value != DBNull.Value)
                    txtFeeAmount.Text = row.Cells["Amount"].Value.ToString();
                else
                    txtFeeAmount.Clear();

                // DueDate
                if (dgvFees.Columns.Contains("DueDate") && row.Cells["DueDate"].Value != DBNull.Value)
                    dtpFeeDueDate.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);
                else
                    dtpFeeDueDate.Value = DateTime.Now.AddMonths(1);

                // Ensure selection
                dgvFees.ClearSelection();
                dgvFees.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting fee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CELL EDIT -> PERSIST INLINE CHANGES =================
        private void dgvFees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvFees.Rows[e.RowIndex];
                string colName = dgvFees.Columns[e.ColumnIndex].Name;

                // Determine fee id from row
                int feeId = -1;
                if (dgvFees.Columns.Contains("FeeID") && row.Cells["FeeID"].Value != DBNull.Value)
                    feeId = Convert.ToInt32(row.Cells["FeeID"].Value);
                else if (dgvFees.Columns.Contains("FeeId") && row.Cells["FeeId"].Value != DBNull.Value)
                    feeId = Convert.ToInt32(row.Cells["FeeId"].Value);
                else if (dgvFees.Columns.Contains("ID") && row.Cells["ID"].Value != DBNull.Value)
                    feeId = Convert.ToInt32(row.Cells["ID"].Value);

                if (feeId <= 0)
                    return;

                // Editable fields: Amount, FeeType, DueDate
                if (colName == "Amount" || colName == "FeeType" || colName == "DueDate")
                {
                    // Prepare new values
                    object newAmount = DBNull.Value;
                    object newFeeType = DBNull.Value;
                    object newDueDate = DBNull.Value;

                    if (dgvFees.Columns.Contains("Amount"))
                        newAmount = row.Cells["Amount"].Value ?? DBNull.Value;
                    if (dgvFees.Columns.Contains("FeeType"))
                        newFeeType = row.Cells["FeeType"].Value ?? DBNull.Value;
                    if (dgvFees.Columns.Contains("DueDate"))
                        newDueDate = row.Cells["DueDate"].Value ?? DBNull.Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string q = @"UPDATE Fees SET Amount=@Amount, FeeType=@FeeType, DueDate=@DueDate
                                     WHERE FeeID=@FeeID";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {
                            // Avoid conditional operator mixing DBNull and decimal (C# 7.3)
                            object amountParam;
                            if (newAmount == DBNull.Value)
                            {
                                amountParam = DBNull.Value;
                            }
                            else
                            {
                                decimal parsed;
                                if (decimal.TryParse(Convert.ToString(newAmount), out parsed))
                                    amountParam = parsed;
                                else
                                    amountParam = DBNull.Value;
                            }

                            cmd.Parameters.AddWithValue("@Amount", amountParam);
                            cmd.Parameters.AddWithValue("@FeeType", newFeeType ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@DueDate", newDueDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@FeeID", feeId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                // keep row selected after edit
                dgvFees.ClearSelection();
                dgvFees.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving cell change: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadFees(); // restore consistent state
            }
        }
    }
}
