using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Create_Post_Form : Form
    {
        private readonly User _currentUser;
        private readonly string[] emojis = new string[] { "🕊","✨","👀","😀", "😂", "😍", "👍", "🔥", "🎉", "😢", "😎", "💡", "❓","❤" };

        public Create_Post_Form(User user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _currentUser = user;

            lblUserInfo.Text = $"Posting as: {_currentUser.FullName}";
            lblUserInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblUserInfo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUserInfo.Location = new Point((this.ClientSize.Width - lblUserInfo.Width) / 2, 10);
            lblUserInfo.Anchor = AnchorStyles.Top;

            cmbPostType.Items.AddRange(new string[]
            {
                "Casual","Life Update", "Question", "Achievement", "Announcement", "Other"
            });
            cmbPostType.SelectedIndex = 0;

            AddEmojiButtons();
        }

        private void AddEmojiButtons()
        {
            pnlEmojis.Controls.Clear();
            foreach (var emoji in emojis)
            {
                Button btn = new Button();
                btn.Text = emoji;
                btn.Font = new Font("Segoe UI Emoji", 10);
                btn.Width = 35;
                btn.Height = 30;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(70, 70, 75);
                btn.ForeColor = Color.White;
                btn.Margin = new Padding(3);
                btn.Click += (s, e) => txtContent.AppendText(emoji);
                pnlEmojis.Controls.Add(btn);
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    picPreview.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Please enter post content.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Posts (UserID, Content, MediaURL, PostDate)
                  VALUES (@u, @c, @img, GETDATE())", conn);

                    cmd.Parameters.AddWithValue("@u", _currentUser.UserID);

                    // ✅ Use Unicode prefix N before string for emoji compatibility
                    string finalContent = $"{cmbPostType.SelectedItem}: {txtContent.Text}";
                    cmd.Parameters.AddWithValue("@c", finalContent);

                    if (string.IsNullOrWhiteSpace(txtImagePath.Text))
                        cmd.Parameters.AddWithValue("@img", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@img", txtImagePath.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Post shared successfully!");
                txtContent.Clear();
                txtImagePath.Clear();
                picPreview.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating post: " + ex.Message);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Post_Form_Load(object sender, EventArgs e)
        {
            // Future enhancements can go here
        }
    }
}
