using System.Drawing;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    partial class EditProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblBio;
        private Label lblProfilePic;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtBio;
        private TextBox txtProfilePic;
        private Button btnBrowse;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFullName = new Label();
            this.lblEmail = new Label();
            this.lblPassword = new Label();
            this.lblBio = new Label();
            this.lblProfilePic = new Label();
            this.txtFullName = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPassword = new TextBox();
            this.txtBio = new TextBox();
            this.txtProfilePic = new TextBox();
            this.btnBrowse = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Form
            this.ClientSize = new Size(500, 420);
            this.Name = "EditProfileForm";
            this.Text = "Edit Profile";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(58, 63, 75);

            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color labelColor = Color.WhiteSmoke;

            // Labels
            this.lblFullName.Text = "Full Name:";
            this.lblFullName.Location = new Point(40, 40);
            this.lblFullName.ForeColor = labelColor;
            this.lblFullName.Font = labelFont;

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(40, 80);
            this.lblEmail.ForeColor = labelColor;
            this.lblEmail.Font = labelFont;

            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new Point(40, 120);
            this.lblPassword.ForeColor = labelColor;
            this.lblPassword.Font = labelFont;

            this.lblBio.Text = "Bio:";
            this.lblBio.Location = new Point(40, 160);
            this.lblBio.ForeColor = labelColor;
            this.lblBio.Font = labelFont;

            this.lblProfilePic.Text = "Profile Picture:";
            this.lblProfilePic.Location = new Point(40, 200);
            this.lblProfilePic.ForeColor = labelColor;
            this.lblProfilePic.Font = labelFont;

            // Textboxes
            Size textboxSize = new Size(280, 27);
            this.txtFullName.Location = new Point(180, 40);
            this.txtFullName.Size = textboxSize;

            this.txtEmail.Location = new Point(180, 80);
            this.txtEmail.Size = textboxSize;

            this.txtPassword.Location = new Point(180, 120);
            this.txtPassword.Size = textboxSize;
            this.txtPassword.UseSystemPasswordChar = true;

            this.txtBio.Location = new Point(180, 160);
            this.txtBio.Size = textboxSize;

            this.txtProfilePic.Location = new Point(180, 200);
            this.txtProfilePic.Size = textboxSize;
            this.txtProfilePic.ReadOnly = true;

            // Browse Button
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Location = new Point(180, 240);
            this.btnBrowse.Size = new Size(280, 30);
            this.btnBrowse.BackColor = Color.DimGray;
            this.btnBrowse.ForeColor = Color.White;
            this.btnBrowse.FlatStyle = FlatStyle.Flat;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.Click += new EventHandler(this.BtnBrowse_Click);

            // Save Button
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(90, 300);
            this.btnSave.Size = new Size(130, 40);
            this.btnSave.BackColor = Color.Teal;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(250, 300);
            this.btnCancel.Size = new Size(130, 40);
            this.btnCancel.BackColor = Color.DarkSlateGray;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Controls
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.txtBio);
            this.Controls.Add(this.lblProfilePic);
            this.Controls.Add(this.txtProfilePic);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
        }
    }
}
