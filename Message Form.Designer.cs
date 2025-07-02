namespace WindowsFormsApp1
{
    partial class Message_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.Select_Friend = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.Message_Text = new System.Windows.Forms.Label();
            this.Messages = new System.Windows.Forms.ListBox();
            this.Friends = new System.Windows.Forms.ListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Theme colors
            System.Drawing.Color background = System.Drawing.Color.FromArgb(35, 40, 45);
            System.Drawing.Color text = System.Drawing.Color.WhiteSmoke;
            System.Drawing.Color inputBack = System.Drawing.Color.FromArgb(60, 63, 65);
            System.Drawing.Color buttonBack = System.Drawing.Color.SteelBlue;

            this.BackColor = background;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messages";

            // btnSend
            this.btnSend.BackColor = buttonBack;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(640, 490);
            this.btnSend.Size = new System.Drawing.Size(120, 35);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Select_Friend
            this.Select_Friend.AutoSize = true;
            this.Select_Friend.ForeColor = text;
            this.Select_Friend.Location = new System.Drawing.Point(60, 30);
            this.Select_Friend.Text = "Select Friend";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = text;
            this.lblSearch.Location = new System.Drawing.Point(60, 60);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(130, 55);
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.BackColor = inputBack;
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(60, 490);
            this.txtMessage.Size = new System.Drawing.Size(550, 35);
            this.txtMessage.BackColor = inputBack;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Multiline = true;

            // Message_Text
            this.Message_Text.AutoSize = true;
            this.Message_Text.ForeColor = text;
            this.Message_Text.Location = new System.Drawing.Point(60, 460);
            this.Message_Text.Text = "Type your message:";

            // Messages
            this.Messages.BackColor = inputBack;
            this.Messages.ForeColor = System.Drawing.Color.White;
            this.Messages.Location = new System.Drawing.Point(60, 250);
            this.Messages.Size = new System.Drawing.Size(700, 200);

            // Friends
            this.Friends.BackColor = inputBack;
            this.Friends.ForeColor = System.Drawing.Color.White;
            this.Friends.Location = new System.Drawing.Point(60, 90);
            this.Friends.Size = new System.Drawing.Size(700, 140);
            this.Friends.SelectedIndexChanged += new System.EventHandler(this.Friends_SelectedIndexChanged);

            // btnLogout
            this.btnLogout.BackColor = buttonBack;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(800, 490);
            this.btnLogout.Size = new System.Drawing.Size(120, 35);
            this.btnLogout.Text = "Back";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Message_Form
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.Select_Friend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.Message_Text);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.Friends);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label Select_Friend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label Message_Text;
        private System.Windows.Forms.ListBox Messages;
        private System.Windows.Forms.ListBox Friends;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}
