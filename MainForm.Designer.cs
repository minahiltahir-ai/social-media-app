using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picProfile;
        private Label lblWelcome;
        private Label lblBio;
        private FlowLayoutPanel flowPosts;
        private Button btnCreatePost;
        private Button btnRefresh;
        private Button btnMessages;
        private Button btnLogout;
        private Button btnComments;
        private Button btnAdminPanel;
        private Button btnMyProfile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picProfile = new PictureBox();
            this.lblWelcome = new Label();
            this.lblBio = new Label();
            this.flowPosts = new FlowLayoutPanel();
            this.btnCreatePost = new Button();
            this.btnRefresh = new Button();
            this.btnMessages = new Button();
            this.btnComments = new Button();
            this.btnLogout = new Button();
            this.btnAdminPanel = new Button();
            this.btnMyProfile = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();

            // Form properties
            this.ClientSize = new Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "Social Media Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(40, 44, 52);

            // Picture Profile
            this.picProfile.Location = new Point(900, 20);
            this.picProfile.Size = new Size(80, 80);
            this.picProfile.SizeMode = PictureBoxSizeMode.Zoom;
            this.picProfile.BorderStyle = BorderStyle.FixedSingle;

            // Welcome Label
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.WhiteSmoke;
            this.lblWelcome.Location = new Point(20, 20);
            this.lblWelcome.Text = "Welcome, User!";

            // Bio Label
            this.lblBio.AutoSize = true;
            this.lblBio.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBio.ForeColor = Color.LightGray;
            this.lblBio.Location = new Point(700, 105);
            this.lblBio.Text = "Bio will appear here...";

            // FlowPosts
            this.flowPosts.Location = new Point(20, 140);
            this.flowPosts.Size = new Size(960, 350);
            this.flowPosts.AutoScroll = true;
            this.flowPosts.BackColor = Color.FromArgb(50, 54, 64);
            this.flowPosts.BorderStyle = BorderStyle.FixedSingle;

            // Button array and properties
            Button[] buttons = { btnCreatePost, btnRefresh, btnMessages, btnComments, btnLogout, btnAdminPanel, btnMyProfile };
            string[] texts = { "Create Post", "Refresh", "Messages", "Comments", "Logout", "Admin Panel", "My Profile" };
            Color[] colors = {
                Color.Teal, Color.SteelBlue, Color.MediumSlateBlue,
                Color.SlateGray, Color.Crimson, Color.DarkOrange, Color.DarkCyan
            };

            int left = 20;
            int top = 510;

            for (int i = 0; i < buttons.Length; i++)
            {
                var btn = buttons[i];
                btn.Text = texts[i];
                btn.Location = new Point(left, top);
                btn.Size = new Size(130, 40);
                btn.BackColor = colors[i];
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                left += 140;
                this.Controls.Add(btn);
            }

            // Only visible to Admin 
            this.btnAdminPanel.Visible = false;

            // Event bindings
            btnCreatePost.Click += new System.EventHandler(this.btnCreatePost_Click);
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            btnMessages.Click += new System.EventHandler(this.btnMessages_Click);
            btnComments.Click += new System.EventHandler(this.btnComments_Click);
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            btnAdminPanel.Click += new System.EventHandler(this.BtnAdminPanel_Click);
            btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);

            // Add controls
            this.Controls.Add(this.picProfile);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.flowPosts);

            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
