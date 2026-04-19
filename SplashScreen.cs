using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class SplashScreen : Form
    {
        // runtime controls (will reuse designer controls if present)
        private Label lblTitle;
        private Label lblSubtitle;
        private PictureBox pbLogo;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Timer uiTimer;

        // configuration
        private const int FadeStep = 5;           // opacity step for fade in/out
        private const int TimerInterval = 40;     // ms -> controls progress speed
        private int progressTarget = 100;

        public SplashScreen()
        {
            InitializeComponent();

            // idempotent load wiring
            this.Load -= SplashScreen_Load;
            this.Load += SplashScreen_Load;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
           // ensure controls exist (designer may already have them)
            EnsureControls();

            // initialize visuals
            this.Opacity = 0;
            lblTitle.Text = GetAppTitle();
            lblSubtitle.Text = GetAppSubtitle();
            lblStatus.Text = "Starting...";
            progressBar.Value = 0;

            // start UI timer (drives progress and fade)
            uiTimer = new Timer { Interval = TimerInterval };
            uiTimer.Tick -= UiTimer_Tick;
            uiTimer.Tick += UiTimer_Tick;
            uiTimer.Start();
        }

        private void EnsureControls()
        {
            // try to reuse designer controls if they exist
            var found = this.Controls.Find("lblTitle", true);
            lblTitle = found.Length > 0 ? (Label)found[0] : null;

            found = this.Controls.Find("lblSubtitle", true);
            lblSubtitle = found.Length > 0 ? (Label)found[0] : null;

            var foundPb = this.Controls.Find("pbLogo", true);
            pbLogo = foundPb.Length > 0 ? (PictureBox)foundPb[0] : null;

            found = this.Controls.Find("progressBar", true);
            progressBar = found.Length > 0 ? (ProgressBar)found[0] : null;

            found = this.Controls.Find("lblStatus", true);
            lblStatus = found.Length > 0 ? (Label)found[0] : null;

            // create missing controls with a clean layout
            if (lblTitle == null)
            {
                lblTitle = new Label
                {
                    Name = "lblTitle",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(35, 35, 35),
                    Location = new Point(20, 18),
                    Size = new Size(this.ClientSize.Width - 140, 36),
                    BackColor = Color.Transparent
                };
                this.Controls.Add(lblTitle);
            }

            if (lblSubtitle == null)
            {
                lblSubtitle = new Label
                {
                    Name = "lblSubtitle",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    ForeColor = Color.DimGray,
                    Location = new Point(20, 58),
                    Size = new Size(this.ClientSize.Width - 140, 20),
                    BackColor = Color.Transparent
                };
                this.Controls.Add(lblSubtitle);
            }

            if (pbLogo == null)
            {
                pbLogo = new PictureBox
                {
                    Name = "pbLogo",
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(96, 96),
                    Location = new Point(this.ClientSize.Width - 116, 12),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    BackColor = Color.Transparent
                };

                // try to load embedded resource image named "SplashScreen.png" from resources if available
                try
                {
                    var asm = Assembly.GetExecutingAssembly();
                    // developer may add "Resources.SplashLogo.png" to resources; this is a best-effort attempt
                    var stream = asm.GetManifestResourceStream("EducationalInstituteManagementSystem.SplashScreen.png");
                    if (stream != null)
                        pbLogo.Image = Image.FromStream(stream);
                }
                catch
                {
                    // ignore - logo optional
                }

                this.Controls.Add(pbLogo);
            }

            if (progressBar == null)
            {
                progressBar = new ProgressBar
                {
                    Name = "progressBar",
                    Style = ProgressBarStyle.Continuous,
                    Location = new Point(20, this.ClientSize.Height - 48),
                    Size = new Size(this.ClientSize.Width - 40, 18),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                    Maximum = 100,
                    Value = 0
                };
                this.Controls.Add(progressBar);
            }

            if (lblStatus == null)
            {
                lblStatus = new Label
                {
                    Name = "lblStatus",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(20, this.ClientSize.Height - 78),
                    Size = new Size(this.ClientSize.Width - 140, 20),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                    BackColor = Color.Transparent
                };
                this.Controls.Add(lblStatus);
            }
        }

        private string GetAppTitle()
        {
            try
            {
                var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                var name = asm.GetName().Name;
                var version = asm.GetName().Version;
                return $"{name} v{version}";
            }
            catch
            {
                return "Educational Institute Management System";
            }
        }

        private string GetAppSubtitle()
        {
            return "Welcome — loading modules and preparing your experience...";
        }

        private int _tickCounter = 0;
        private async void UiTimer_Tick(object sender, EventArgs e)
        {
            // progressive stages: fade-in -> load simulation -> fade-out -> open LoginForm
            // 1) Fade-in
            if (this.Opacity < 1.0 && _tickCounter < 10)
            {
                this.Opacity = Math.Min(1.0, this.Opacity + FadeStep / 100.0);
            }

            // simulate staged initialization and update status text
            // increase progress with slight randomness for natural feel
            var rnd = new Random();
            int inc = 1 + rnd.Next(0, 3); // 1..3
            progressBar.Value = Math.Min(progressBar.Maximum, progressBar.Value + inc);

            UpdateStatusByProgress(progressBar.Value);

            _tickCounter++;

            // when progress completes, small delay then transition
            if (progressBar.Value >= progressTarget)
            {
                uiTimer.Stop();

                // slight pause for user to read "Ready"
                lblStatus.Text = "Ready";
                await Task.Delay(350);

                // fade out smoothly
                for (double op = this.Opacity; op > 0; op -= 0.08)
                {
                    this.Opacity = Math.Max(0, op);
                    await Task.Delay(20);
                }

                // open login form on UI thread and hide splash (do not Close() here)
                try
                {
                    var login = new LoginForm();

                    // Ensure application stays alive: hide splash and make login the visible UI.
                    // When login closes, close splash to end application.
                    login.FormClosed -= Login_FormClosed;
                    login.FormClosed += Login_FormClosed;

                    this.Hide();
                    login.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open Login form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // If login cannot open, close the splash to avoid locking UI
                    this.Close();
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            // when login form is closed, close splash (end application)
            this.Close();
        }

        private void UpdateStatusByProgress(int value)
        {
            if (value < 10) lblStatus.Text = "Initializing...";
            else if (value < 30) lblStatus.Text = "Loading modules...";
            else if (value < 60) lblStatus.Text = "Connecting to database...";
            else if (value < 85) lblStatus.Text = "Preparing user interface...";
            else if (value < 99) lblStatus.Text = "Finalizing...";
            else lblStatus.Text = "Almost ready...";
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
