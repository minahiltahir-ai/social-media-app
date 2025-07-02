using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Admin_Panel_Form : Form
    {
        public Admin_Panel_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            LoadUsers();
            LoadPosts();

            txtSearch.TextChanged += TxtSearch_TextChanged;

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT UserID, FullName, Email, IsAdmin FROM Users", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void LoadPosts()
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(@"
                    SELECT P.PostID, U.FullName AS Author, P.Content, P.PostDate
                    FROM Posts P
                    JOIN Users U ON P.UserID = U.UserID", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPosts.DataSource = dt;
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadUsers();
                    MessageBox.Show("User deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            if (dgvPosts.SelectedRows.Count > 0)
            {
                int postId = Convert.ToInt32(dgvPosts.SelectedRows[0].Cells["PostID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this post?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Posts WHERE PostID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", postId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadPosts();
                    MessageBox.Show("Post deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a post to delete.");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (keyword == "search..." || keyword == "")
            {
                LoadUsers();
                LoadPosts();
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();

                // Search in Users
                SqlDataAdapter userAdapter = new SqlDataAdapter(
                    "SELECT UserID, FullName, Email, IsAdmin FROM Users WHERE LOWER(FullName) LIKE @kw OR LOWER(Email) LIKE @kw", conn);
                userAdapter.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                DataTable userTable = new DataTable();
                userAdapter.Fill(userTable);
                dgvUsers.DataSource = userTable;

                // Search in Posts
                SqlDataAdapter postAdapter = new SqlDataAdapter(
    @"SELECT P.PostID, U.FullName AS Author, P.Content, P.PostDate
      FROM Posts P 
      JOIN Users U ON P.UserID = U.UserID
      WHERE LOWER(CAST(P.Content AS VARCHAR(MAX))) LIKE @kw 
         OR LOWER(U.FullName) LIKE @kw", conn);

                postAdapter.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                DataTable postTable = new DataTable();
                postAdapter.Fill(postTable);
                dgvPosts.DataSource = postTable;
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadPosts();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
