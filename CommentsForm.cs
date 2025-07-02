using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CommentsForm : Form
    {
        private int postId;
        private int currentUserId;

        public CommentsForm(int postId, int userId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.postId = postId;
            this.currentUserId = userId;
            LoadComments();
        }

        private void LoadComments()
        {
            using (SqlConnection con = new SqlConnection(Program.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT U.FullName AS [User], C.CommentText AS [Comment], C.CommentDate AS [Date] 
                      FROM Comments C 
                      JOIN Users U ON C.UserID = U.UserID 
                      WHERE C.PostID = @pid 
                      ORDER BY C.CommentDate DESC", con);

                cmd.Parameters.AddWithValue("@pid", postId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvComments.DataSource = dt;

                dgvComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvComments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvComments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvComments.DefaultCellStyle.Font = new Font("Segoe UI Emoji", 10F);

            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please enter a comment.");
                return;
            }

            using (SqlConnection con = new SqlConnection(Program.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Comments (PostID, UserID, CommentText) 
                      VALUES (@p, @u, @c)", con);
                cmd.Parameters.AddWithValue("@p", postId);
                cmd.Parameters.AddWithValue("@u", currentUserId);
                cmd.Parameters.AddWithValue("@c", txtComment.Text);
                cmd.ExecuteNonQuery();
            }

            txtComment.Clear();
            LoadComments();
        }

        private void dgvComments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle row click actions if needed later
        }
    }
}
