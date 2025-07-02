
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private readonly User currentUser;
        private int selectedPostId = -1;

        public MainForm(User user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;

            btnAdminPanel.Visible = currentUser.IsAdmin;

            lblWelcome.Text = $"Welcome, {currentUser.FullName}!";
            lblBio.Text = string.IsNullOrWhiteSpace(currentUser.Bio) ? "No bio available." : currentUser.Bio;

            LoadProfilePicture();
            ApplyHoverEffects();
            LoadPosts();
        }

        private void BtnAdminPanel_Click(object sender, EventArgs e)
        {
            Admin_Panel_Form adminPanel = new Admin_Panel_Form();
            adminPanel.ShowDialog();
        }

        private void LoadProfilePicture()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(currentUser.ProfilePicture) && File.Exists(currentUser.ProfilePicture))
                {
                    Image original = Image.FromFile(currentUser.ProfilePicture);
                    Bitmap rounded = MakeRoundedImage(original, picProfile.Width, picProfile.Height);
                    picProfile.Image = rounded;
                }
                else
                {
                    picProfile.Image = null;
                }
            }
            catch
            {
                picProfile.Image = null;
            }
        }

        private Bitmap MakeRoundedImage(Image original, int width, int height)
        {
            Bitmap rounded = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(rounded))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, width, height);
                g.SetClip(path);
                g.DrawImage(original, 0, 0, width, height);
            }
            return rounded;
        }

        private void ApplyHoverEffects()
        {
            Button[] buttons = { btnCreatePost, btnRefresh, btnMessages, btnComments, btnLogout, btnAdminPanel };
            foreach (Button btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Teal;
                btn.ForeColor = Color.White;
                btn.MouseEnter += (s, e) => { btn.BackColor = Color.DarkCyan; };
                btn.MouseLeave += (s, e) => { btn.BackColor = Color.Teal; };
            }
        }

        private void LoadPosts()
        {
            flowPosts.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
@"SELECT 
    P.PostID, 
    U.FullName, 
    P.Content, 
    P.MediaURL, 
    P.PostDate,
    (SELECT COUNT(*) FROM Likes L WHERE L.PostID = P.PostID) AS LikeCount
  FROM Posts P 
  JOIN Users U ON P.UserID = U.UserID 
  ORDER BY P.PostDate DESC", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int postId = (int)reader["PostID"];
                    string author = reader["FullName"].ToString();
                    string content = reader["Content"].ToString();
                    string media = reader["MediaURL"]?.ToString();

                    Panel postPanel = new Panel
                    {
                        Width = flowPosts.Width - 40,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10),
                        BackColor = Color.LightGray
                    };

                    Label lblAuthor = new Label
                    {
                        Text = "By: " + author,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Location = new Point(10, 10)
                    };

                    Label lblContent = new Label
                    {
                        Text = content,
                        AutoSize = true,
                        Font = new Font("Segoe UI Emoji", 11F, FontStyle.Regular),
                        MaximumSize = new Size(postPanel.Width - 20, 0),
                        Location = new Point(10, 35),
                        UseCompatibleTextRendering = true
                    };

                    postPanel.Controls.Add(lblContent);
                    int currentY = lblContent.Bottom + 10;

                    postPanel.Controls.Add(lblAuthor);
                 


                    // ✅ Total Likes Code Block
                    SqlCommand likeCmd = new SqlCommand("SELECT COUNT(*) FROM Likes WHERE PostID = @postId", conn);
                    likeCmd.Parameters.AddWithValue("@postId", postId);
                    int likeCount = (int)reader["LikeCount"];

                    Label lblLikes = new Label
                    {
                        Text = $"Likes: {likeCount}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        Location = new Point(10, currentY)
                    };
                    postPanel.Controls.Add(lblLikes);
                    currentY = lblLikes.Bottom + 10;


                    PictureBox img = new PictureBox
                    {
                        Size = new Size(postPanel.Width - 20, 180),
                        //Size = new Size(120, 100),
                        Location = new Point(10, currentY),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Visible = !string.IsNullOrWhiteSpace(media)
                    };

                    if (img.Visible && File.Exists(media))
                    {
                        img.Image = Image.FromFile(media);
                        postPanel.Controls.Add(img);
                        currentY = img.Bottom + 10;
                    }

                    Button btnLike = new Button
                    {
                        Text = "Like",
                        Width = 60,
                        Location = new Point(postPanel.Width - 140, currentY),
                        Tag = postId
                    };
                    btnLike.Click += BtnLike_Click;

                    Button btnComment = new Button
                    {
                        Text = "Comment",
                        Width = 75,
                        Location = new Point(postPanel.Width - 220, currentY),
                        Tag = postId
                    };
                    btnComment.Click += BtnComment_Click;

                    postPanel.Controls.Add(btnLike);
                    postPanel.Controls.Add(btnComment);

                    postPanel.Height = currentY + 50;
                    flowPosts.Controls.Add(postPanel);
                }
            }
        }


        private void BtnComment_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedPostId = (int)btn.Tag;
            new CommentsForm(selectedPostId, currentUser.UserID).Show();
        }

        private void BtnLike_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int postId = (int)btn.Tag;

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Likes WHERE UserID = @u AND PostID = @p", conn);
                check.Parameters.AddWithValue("@u", currentUser.UserID);
                check.Parameters.AddWithValue("@p", postId);

                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("You already liked this post.");
                    return;
                }

                SqlCommand like = new SqlCommand("INSERT INTO Likes (UserID, PostID) VALUES (@u, @p)", conn);
                like.Parameters.AddWithValue("@u", currentUser.UserID);
                like.Parameters.AddWithValue("@p", postId);
                like.ExecuteNonQuery();

                MessageBox.Show("Liked!");
                selectedPostId = postId;
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            if (selectedPostId == -1)
            {
                MessageBox.Show("Please select a post first.");
                return;
            }

            new CommentsForm(selectedPostId, currentUser.UserID).Show();
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            new Create_Post_Form(currentUser).ShowDialog();
            LoadPosts();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            new Message_Form(currentUser).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPosts();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            ProfilePageForm profileForm = new ProfilePageForm(currentUser);
            profileForm.ShowDialog();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Restart();
        }
    }
}