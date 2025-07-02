namespace WindowsFormsApp1
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.FullName = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.Confirm_Password = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.ConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRejister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ProfilePicture = new System.Windows.Forms.Label();
            this.txtProfilePic = new System.Windows.Forms.TextBox();
            this.Bio = new System.Windows.Forms.Label();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(35, 40, 45);

            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color labelColor = System.Drawing.Color.WhiteSmoke;
            System.Drawing.Color textboxBack = System.Drawing.Color.FromArgb(60, 63, 65);
            System.Drawing.Color textboxFore = System.Drawing.Color.White;
            System.Drawing.Color buttonBack = System.Drawing.Color.SteelBlue;
            System.Drawing.Color buttonFore = System.Drawing.Color.White;

            this.FullName.AutoSize = true;
            this.FullName.ForeColor = labelColor;
            this.FullName.Location = new System.Drawing.Point(147, 161);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(65, 20);
            this.FullName.Text = "Full Name";
            this.FullName.Font = labelFont;

            this.Email.AutoSize = true;
            this.Email.ForeColor = labelColor;
            this.Email.Location = new System.Drawing.Point(147, 210);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(42, 20);
            this.Email.Text = "Email";
            this.Email.Font = labelFont;

            this.Password.AutoSize = true;
            this.Password.ForeColor = labelColor;
            this.Password.Location = new System.Drawing.Point(147, 273);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(69, 20);
            this.Password.Text = "Password";
            this.Password.Font = labelFont;

            this.Confirm_Password.AutoSize = true;
            this.Confirm_Password.ForeColor = labelColor;
            this.Confirm_Password.Location = new System.Drawing.Point(148, 326);
            this.Confirm_Password.Name = "Confirm_Password";
            this.Confirm_Password.Size = new System.Drawing.Size(121, 20);
            this.Confirm_Password.Text = "Confirm Password";
            this.Confirm_Password.Font = labelFont;

            this.ProfilePicture.AutoSize = true;
            this.ProfilePicture.ForeColor = labelColor;
            this.ProfilePicture.Location = new System.Drawing.Point(122, 35);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(96, 20);
            this.ProfilePicture.Text = "Profile Picture";
            this.ProfilePicture.Font = labelFont;

            this.Bio.AutoSize = true;
            this.Bio.ForeColor = labelColor;
            this.Bio.Location = new System.Drawing.Point(147, 101);
            this.Bio.Name = "Bio";
            this.Bio.Size = new System.Drawing.Size(31, 20);
            this.Bio.Text = "Bio";
            this.Bio.Font = labelFont;

            System.Windows.Forms.TextBox[] textBoxes = new[] { txtFullName, txtPassword, txtEmail, ConfirmPassword, txtBio, txtProfilePic };
            foreach (var tb in textBoxes)
            {
                tb.BackColor = textboxBack;
                tb.ForeColor = textboxFore;
                tb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            }

            this.txtFullName.Location = new System.Drawing.Point(297, 158);
            this.txtFullName.Width = 280;
            this.txtPassword.Location = new System.Drawing.Point(297, 266);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Width = 280;
            this.txtEmail.Location = new System.Drawing.Point(297, 203);
            this.txtEmail.Width = 280;
            this.ConfirmPassword.Location = new System.Drawing.Point(297, 319);
            this.ConfirmPassword.PasswordChar = '*';
            this.ConfirmPassword.Width = 280;
            this.txtProfilePic.Location = new System.Drawing.Point(297, 35);
            this.txtProfilePic.ReadOnly = true;
            this.txtProfilePic.Width = 180;
            this.txtBio.Location = new System.Drawing.Point(297, 101);
            this.txtBio.Multiline = true;
            this.txtBio.Width = 280;
            this.txtBio.Height = 40;

            this.picPreview.Location = new System.Drawing.Point(600, 30);
            this.picPreview.Size = new System.Drawing.Size(120, 120);
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            System.Windows.Forms.Button[] buttons = new[] { btnRejister, btnCancel, btnBrowse };
            foreach (var btn in buttons)
            {
                btn.BackColor = buttonBack;
                btn.ForeColor = buttonFore;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            }

            this.btnRejister.Location = new System.Drawing.Point(297, 380);
            this.btnRejister.Size = new System.Drawing.Size(120, 35);
            this.btnRejister.Text = "Register";
            this.btnRejister.Click += new System.EventHandler(this.btnRejister_Click);

            this.btnCancel.Location = new System.Drawing.Point(437, 380);
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += (s, e) => this.Close();

            this.btnBrowse.Location = new System.Drawing.Point(490, 33);
            this.btnBrowse.Size = new System.Drawing.Size(75, 30);
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.ForeColor = labelColor;
            this.chkIsAdmin.Location = new System.Drawing.Point(647, 382);
            this.chkIsAdmin.Text = "Is Admin";
            this.chkIsAdmin.Font = labelFont;

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Text = "Registration Form";

            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.chkIsAdmin);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBio);
            this.Controls.Add(this.Bio);
            this.Controls.Add(this.txtProfilePic);
            this.Controls.Add(this.ProfilePicture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRejister);
            this.Controls.Add(this.ConfirmPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.Confirm_Password);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.FullName);
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
        }

        #endregion

        private System.Windows.Forms.Label FullName;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Confirm_Password;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox ConfirmPassword;
        private System.Windows.Forms.Button btnRejister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label ProfilePicture;
        private System.Windows.Forms.TextBox txtProfilePic;
        private System.Windows.Forms.Label Bio;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.PictureBox picPreview;
    }
}
