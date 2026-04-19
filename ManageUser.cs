using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace EducationalInstituteManagementSystem
{
    public partial class ManageUser : Form
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        public ManageUser()
        {
            InitializeComponent();

            // keep InitializeComponent first — then initialize handlers deterministically
            InitializeEventHandlers();
        }

        // Idempotent event wiring and defensive control state setup
        private void InitializeEventHandlers()
        {
            // Ensure controls exist
            if (dgvUsers != null)
            {
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.MultiSelect = false;
                dgvUsers.ClearSelection();

                // Remove previous subscriptions then add ours
                dgvUsers.CellClick -= dgvUsers_CellClick;
                dgvUsers.CellClick += dgvUsers_CellClick;
            }

            if (btnAddUser != null)
            {
                btnAddUser.Enabled = true;
                btnAddUser.Click -= btnAddUser_Click_1;
                btnAddUser.Click += btnAddUser_Click_1;
            }

            if (btnUpdateUser != null)
            {
                btnUpdateUser.Enabled = true;
                btnUpdateUser.Click -= btnUpdateUser_Click_1;
                btnUpdateUser.Click += btnUpdateUser_Click_1;
            }

            if (btnDeleteUser != null)
            {
                btnDeleteUser.Enabled = true;
                btnDeleteUser.Click -= btnDeleteUser_Click_1;
                btnDeleteUser.Click += btnDeleteUser_Click_1;
            }

            // Optional: ensure combo has expected items (so selection works)
            if (cmbUserRole != null && cmbUserRole.Items.Count == 0)
            {
                cmbUserRole.Items.Clear();
                cmbUserRole.Items.AddRange(new object[] { "Admin", "Teacher", "Student" });
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, Username, Password, Role, CNIC, Email, IsActive FROM Users";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;

                    if (dgvUsers.Columns.Contains("UserID"))
                        dgvUsers.Columns["UserID"].Visible = false;
                    if (dgvUsers.Columns.Contains("IsActive"))
                        dgvUsers.Columns["IsActive"].Visible = false;

                    dgvUsers.ClearSelection();

                    // DEBUG helper: write columns to Output window (no message boxes)
                    var cols = string.Join(", ", dgvUsers.Columns.Cast<DataGridViewColumn>().Select(c => $"'{c.Name}'"));
                    Debug.WriteLine("dgvUsers columns: " + cols);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbUserRole.Text;
            string cnic = txtCNIC.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(cnic) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Password, Role, CNIC, Email) " +
                                   "VALUES (@Username, @Password, @Role, @CNIC, @Email)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearUserFields();
                        LoadUsers();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Unique constraint violation
                    {
                        MessageBox.Show("Username or CNIC already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUpdateUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows == null || dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            if (!dgvUsers.Columns.Contains("UserID") || selectedRow.Cells["UserID"].Value == null)
            {
                MessageBox.Show("Selected row does not contain a valid UserID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbUserRole.Text;
            string cnic = txtCNIC.Text.Trim();
            string email = txtEmail.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Users SET Username = @Username, Password = @Password, " +
                                   "Role = @Role, CNIC = @CNIC, Email = @Email WHERE UserID = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearUserFields();
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows == null || dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            if (!dgvUsers.Columns.Contains("UserID") || selectedRow.Cells["UserID"].Value == null)
            {
                MessageBox.Show("Selected row does not contain a valid UserID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                if (dgvUsers.Columns.Contains("Username") && row.Cells["Username"].Value != DBNull.Value)
                    txtUsername.Text = row.Cells["Username"].Value.ToString();
                else
                    txtUsername.Clear();

                if (dgvUsers.Columns.Contains("Password") && row.Cells["Password"].Value != DBNull.Value)
                    txtPassword.Text = row.Cells["Password"].Value.ToString();
                else
                    txtPassword.Clear();

                if (dgvUsers.Columns.Contains("Role") && row.Cells["Role"].Value != DBNull.Value)
                {
                    string roleVal = row.Cells["Role"].Value.ToString();
                    int idx = cmbUserRole.FindStringExact(roleVal);
                    cmbUserRole.SelectedIndex = idx >= 0 ? idx : -1;
                }
                else
                {
                    cmbUserRole.SelectedIndex = -1;
                }

                if (dgvUsers.Columns.Contains("CNIC") && row.Cells["CNIC"].Value != DBNull.Value)
                    txtCNIC.Text = row.Cells["CNIC"].Value.ToString();
                else
                    txtCNIC.Clear();

                if (dgvUsers.Columns.Contains("Email") && row.Cells["Email"].Value != DBNull.Value)
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                else
                    txtEmail.Clear();

                dgvUsers.ClearSelection();
                dgvUsers.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUserFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtCNIC.Clear();
            txtEmail.Clear();
            cmbUserRole.SelectedIndex = -1;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }
    }
}