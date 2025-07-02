namespace WindowsFormsApp1
{
    partial class Login_Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.LinkLabel lblRegister;

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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.LightGray;
            this.btnReset.Location = new System.Drawing.Point(430, 260);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 30);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.Teal;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(320, 260);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 30);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // txtLoginEmail
            this.txtLoginEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoginEmail.Location = new System.Drawing.Point(300, 100);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(220, 22);
            this.txtLoginEmail.TabIndex = 16;

            // txtLoginPassword
            this.txtLoginPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoginPassword.Location = new System.Drawing.Point(300, 160);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(220, 22);
            this.txtLoginPassword.TabIndex = 15;

            // Password
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Password.Location = new System.Drawing.Point(200, 163);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(68, 15);
            this.Password.TabIndex = 12;
            this.Password.Text = "Password:";

            // Email
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Email.Location = new System.Drawing.Point(200, 103);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(41, 15);
            this.Email.TabIndex = 11;
            this.Email.Text = "Email:";

            // lblRegister
            this.lblRegister.AutoSize = true;
            this.lblRegister.LinkColor = System.Drawing.Color.DarkCyan;
            this.lblRegister.Location = new System.Drawing.Point(320, 310);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(160, 15);
            this.lblRegister.TabIndex = 20;
            this.lblRegister.TabStop = true;
            this.lblRegister.Text = "Don't have an account? Sign up";
            this.lblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRegister_LinkClicked);

            // Login_Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLoginEmail);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_Form";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
