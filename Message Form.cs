using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Message_Form : Form
    {
        private readonly User currentUser;
        private List<FriendItem> allFriends = new List<FriendItem>();

        public Message_Form(User user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            currentUser = user;
            LoadFriends();
        }

        private class FriendItem
        {
            public int UserID { get; set; }
            public string FullName { get; set; }
            public override string ToString() => FullName;
        }

        private void LoadFriends()
        {
            Friends.Items.Clear();
            allFriends.Clear();

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT U.UserID, U.FullName 
                    FROM Users U
                    WHERE U.UserID != @CurrentUserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserID", currentUser.UserID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var friend = new FriendItem
                            {
                                UserID = (int)reader["UserID"],
                                FullName = reader["FullName"].ToString()
                            };
                            allFriends.Add(friend);
                        }
                    }
                }
            }

            DisplayFilteredFriends("");
        }

        private void DisplayFilteredFriends(string searchText)
        {
            Friends.Items.Clear();
            var filtered = string.IsNullOrWhiteSpace(searchText)
                ? allFriends
                : allFriends.Where(f => f.FullName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            foreach (var f in filtered)
                Friends.Items.Add(f);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayFilteredFriends(txtSearch.Text);
        }

        private void Friends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Friends.SelectedItem is FriendItem selectedFriend)
                LoadMessages(selectedFriend.UserID);
        }

        private void LoadMessages(int friendId)
        {
            Messages.Items.Clear();

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT * FROM Messages
                    WHERE (SenderID = @U1 AND ReceiverID = @U2)
                       OR (SenderID = @U2 AND ReceiverID = @U1)
                    ORDER BY Sent_Date";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@U1", currentUser.UserID);
                    cmd.Parameters.AddWithValue("@U2", friendId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string senderName = (int)reader["SenderID"] == currentUser.UserID ? "You" : GetUserName((int)reader["SenderID"]);
                            Messages.Items.Add($"[{reader["Sent_Date"]}] {senderName}: {reader["Message_Text"]}");
                        }
                    }
                }
            }
        }

        private string GetUserName(int userId)
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT FullName FROM Users WHERE UserID = @uid", conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    return cmd.ExecuteScalar()?.ToString() ?? "Unknown";
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!(Friends.SelectedItem is FriendItem selectedFriend))
            {
                MessageBox.Show("Please select a friend to send message.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please write a message.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Messages (SenderID, ReceiverID, Message_Text) VALUES (@s, @r, @m)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@s", currentUser.UserID);
                    cmd.Parameters.AddWithValue("@r", selectedFriend.UserID);
                    cmd.Parameters.AddWithValue("@m", txtMessage.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            txtMessage.Clear();
            LoadMessages(selectedFriend.UserID);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Only close the form
        }
    }
}
