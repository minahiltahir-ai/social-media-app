using System.Drawing;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    partial class ProfilePageForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picProfile;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblBio;
        private Button btnEditProfile;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picProfile = new PictureBox();
            this.lblFullName = new Label();
            this.lblEmail = new Label();
            this.lblBio = new Label();
            this.btnEditProfile = new Button();
            this.btnBack = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();

            // ProfilePageForm
            this.ClientSize = new Size(700, 400);
            this.BackColor = Color.FromArgb(40, 44, 52);
            this.Text = "My Profile";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ProfilePageForm";

            // picProfile
            this.picProfile.Location = new Point(40, 40);
            this.picProfile.Size = new Size(150, 150);
            this.picProfile.SizeMode = PictureBoxSizeMode.Zoom;
            this.picProfile.BorderStyle = BorderStyle.FixedSingle;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblFullName.ForeColor = Color.WhiteSmoke;
            this.lblFullName.Location = new Point(220, 40);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 12F);
            this.lblEmail.ForeColor = Color.Gainsboro;
            this.lblEmail.Location = new Point(220, 90);

            // lblBio
            this.lblBio.AutoSize = true;
            this.lblBio.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblBio.ForeColor = Color.LightGray;
            this.lblBio.Location = new Point(220, 140);
            this.lblBio.MaximumSize = new Size(400, 0);

            // btnEditProfile
            this.btnEditProfile.Text = "Edit Profile";
            this.btnEditProfile.Size = new Size(120, 40);
            this.btnEditProfile.Location = new Point(220, 220);
            this.btnEditProfile.BackColor = Color.Teal;
            this.btnEditProfile.ForeColor = Color.White;
            this.btnEditProfile.FlatStyle = FlatStyle.Flat;
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.Click += new EventHandler(this.btnEditProfile_Click);

            // btnBack
            this.btnBack.Text = "Back";
            this.btnBack.Size = new Size(120, 40);
            this.btnBack.Location = new Point(360, 220);
            this.btnBack.BackColor = Color.DarkSlateGray;
            this.btnBack.ForeColor = Color.White;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // Add controls
            this.Controls.Add(this.picProfile);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.btnBack);

            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
