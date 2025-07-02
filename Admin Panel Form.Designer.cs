namespace WindowsFormsApp1
{
    partial class Admin_Panel_Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvPosts;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnDeletePost;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvPosts = new System.Windows.Forms.DataGridView();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnDeletePost = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).BeginInit();
            this.SuspendLayout();

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(20, 60);
            this.dgvUsers.Size = new System.Drawing.Size(650, 200);
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.dgvUsers.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvUsers.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsers.EnableHeadersVisualStyles = false;

            // dgvPosts
            this.dgvPosts.Location = new System.Drawing.Point(20, 280);
            this.dgvPosts.Size = new System.Drawing.Size(650, 200);
            this.dgvPosts.ReadOnly = true;
            this.dgvPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosts.BackgroundColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.dgvPosts.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvPosts.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPosts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.dgvPosts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.dgvPosts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPosts.EnableHeadersVisualStyles = false;

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(700, 20);
            this.txtSearch.Size = new System.Drawing.Size(120, 25);

            // btnDeleteUser
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.BackColor = System.Drawing.Color.Salmon;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(700, 80);
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            // btnDeletePost
            this.btnDeletePost.Text = "Delete Post";
            this.btnDeletePost.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeletePost.ForeColor = System.Drawing.Color.White;
            this.btnDeletePost.Location = new System.Drawing.Point(700, 300);
            this.btnDeletePost.Size = new System.Drawing.Size(120, 40);
            this.btnDeletePost.Click += new System.EventHandler(this.btnDeletePost_Click);

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(700, 180);
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(700, 400);
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Admin_Panel_Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.dgvPosts);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnDeletePost);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin_Panel_Form";
            this.Text = "Admin Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
