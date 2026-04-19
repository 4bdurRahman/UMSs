using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace EducationalInstituteManagementSystem
{
    public partial class AdminPanelForm : Form
    {
         

         private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public AdminPanelForm()
        {
            InitializeComponent();
            
            //ADashboard dashboard = new ADashboard();
            //OpenChildForm(dashboard, null);
            OpenChildForm(new ADashboard(), null);

        }
        //private void ActivateButton(object btnSender)
        //{
        //    if (btnSender != null)
        //    {
        //        if (currentButton != (Button)btnSender)
        //        {
        //            DisableButton();
        //            Color color = SelectThemeColor();
        //            currentButton = (Button)btnSender;
        //            currentButton.BackColor = color;
        //            currentButton.ForeColor = Color.White;
        //            currentButton.Font = this.buttonProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            panelTitleBar.BackColor = color;
        //            panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
        //            ThemeColor.PrimaryColor = color;
        //            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
        //            btnCloseChildForm.Visible = true;
        //        }
        //    }


        //}

        //private void DisableButton()
        //{
        //    foreach (Control previousBtn in panelMenu.Controls)
        //    {
        //        if (previousBtn.GetType() == typeof(Button))
        //        {
        //            previousBtn.BackColor = Color.FromArgb(51, 51, 76);
        //            previousBtn.ForeColor = Color.Gainsboro;
        //            previousBtn.Font = this.buttonProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        }
        //    }
        //}

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.Show();
            //lblTitle.Text = childForm.Text;

        }



        // Manage Users Tab


        // Manage Students Tab


        // Manage Teachers Tab

        // Manage Subjects Tab


        // Fees Management


        // Salary Management

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        // Helper methods for loading combobox data
        

        

        

        

       

        

       

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {

        }
        
        private void btnUsers_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            AdminPanelForm a = new AdminPanelForm();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ADashboard(), sender);
        }

        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ManageUser(), sender);
        }

        private void btnStudents_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ManageStudent(), sender);
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageTeacher(), sender);
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageSubjects(), sender);
        }

        private void btnFees_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageFee(), sender);
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageSalary(), sender);
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new ADashboard(), sender);         }
    }
}