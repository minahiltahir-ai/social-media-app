using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackgroundImage = Properties.Resources.welcome_bg;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            label1.BackColor = Color.Transparent;
            lblSubText.BackColor = Color.Transparent;
        }
        //public WelcomeForm()
        //{
        //    InitializeComponent();
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.BackColor = Color.FromArgb(40, 44, 52); // dark
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
            this.Hide();
        }
    }
}
