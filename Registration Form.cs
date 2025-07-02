using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Theme styling
            this.BackColor = Color.FromArgb(35, 40, 45);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.WhiteSmoke;
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(60, 60, 65);
                    txt.ForeColor = Color.White;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = Color.SteelBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
                else if (ctrl is CheckBox cb)
                {
                    cb.ForeColor = Color.WhiteSmoke;
                }
            }
        }

        private void btnRejister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text);

            using (SqlConnection con = new SqlConnection(Program.ConnectionString))
            {
                con.Open();

                SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", con);
                checkEmail.Parameters.AddWithValue("@Email", txtEmail.Text);

                int exists = (int)checkEmail.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Email already registered.");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Users (FullName, Email, Password, Bio, ProfilePicture, IsAdmin)
                      VALUES (@FullName, @Email, @Password, @Bio, @ProfilePicture, @IsAdmin)", con);

                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Bio", txtBio.Text);
                cmd.Parameters.AddWithValue("@ProfilePicture", txtProfilePic.Text);
                cmd.Parameters.AddWithValue("@IsAdmin", chkIsAdmin.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration successful!");

                // Open login form after registration
                this.Hide();
                Login_Form login = new Login_Form(); 
                login.Show();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtProfilePic.Text = ofd.FileName;
                picPreview.Image = Image.FromFile(ofd.FileName); // Preview....
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form(); //open login form ....
            login.Show();
        }
    }
}
