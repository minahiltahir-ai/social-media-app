using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class EditProfileForm : Form
    {
        private readonly User currentUser;

        public EditProfileForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            txtFullName.Text = currentUser.FullName;
            txtEmail.Text = currentUser.Email;
            txtBio.Text = currentUser.Bio;
            txtProfilePic.Text = currentUser.ProfilePicture;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtProfilePic.Text = ofd.FileName;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Program.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET FullName = @name, Bio = @bio, ProfilePicture = @pic WHERE UserID = @id", con);

                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@bio", txtBio.Text.Trim());
                cmd.Parameters.AddWithValue("@pic", txtProfilePic.Text.Trim());
                cmd.Parameters.AddWithValue("@id", currentUser.UserID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Profile updated successfully.");
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
