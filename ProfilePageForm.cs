using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ProfilePageForm : Form
    {
        private readonly User currentUser;

        public ProfilePageForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadProfileDetails();
        }

        private void LoadProfileDetails()
        {
            lblFullName.Text = currentUser.FullName;
            lblEmail.Text = currentUser.Email;
            lblBio.Text = currentUser.Bio;

            if (!string.IsNullOrWhiteSpace(currentUser.ProfilePicture) && File.Exists(currentUser.ProfilePicture))
            {
                picProfile.Image = Image.FromFile(currentUser.ProfilePicture);
            }
            else
            {
                picProfile.Image = null;
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            EditProfileForm editForm = new EditProfileForm(currentUser);
            editForm.ShowDialog();

            // Reload updated details
            LoadProfileDetails();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
