using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string hashedPassword = SecurityHelper.HashPassword(txtLoginPassword.Text);

            using (SqlConnection con = new SqlConnection(Program.ConnectionString))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT UserID, Bio, ProfilePicture, FullName, Email, IsAdmin
              FROM Users
              WHERE Email = @Email AND Password = @Password", con);

                cmd.Parameters.AddWithValue("@Email", txtLoginEmail.Text);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User loggedInUser = new User
                    {
                        UserID = (int)reader["UserID"],
                        Bio = reader["Bio"].ToString(),
                        ProfilePicture = reader["ProfilePicture"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };

                    // Main form open ho ga.....
                    MainForm dashboard = new MainForm(loggedInUser);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
        }


        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
            this.Hide();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}