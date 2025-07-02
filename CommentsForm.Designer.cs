namespace WindowsFormsApp1
{
    partial class CommentsForm
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
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.lblAddComment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.SuspendLayout();

            // Theme Colors
            System.Drawing.Color background = System.Drawing.Color.FromArgb(35, 40, 45);
            System.Drawing.Color inputBack = System.Drawing.Color.FromArgb(60, 63, 65);
            System.Drawing.Color text = System.Drawing.Color.WhiteSmoke;
            System.Drawing.Color buttonBack = System.Drawing.Color.SteelBlue;

            // CommentsForm
            this.BackColor = background;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comments";

            // dgvComments
            this.dgvComments.Location = new System.Drawing.Point(50, 40);
            this.dgvComments.Size = new System.Drawing.Size(800, 300);
            this.dgvComments.ReadOnly = true;
            this.dgvComments.BackgroundColor = inputBack;
            this.dgvComments.DefaultCellStyle.BackColor = inputBack;
            this.dgvComments.DefaultCellStyle.ForeColor = text;
            this.dgvComments.ColumnHeadersDefaultCellStyle.BackColor = buttonBack;
            this.dgvComments.ColumnHeadersDefaultCellStyle.ForeColor = text;
            this.dgvComments.EnableHeadersVisualStyles = false;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComments_CellContentClick);

            // txtComment
            this.txtComment.Location = new System.Drawing.Point(200, 370);
            this.txtComment.Multiline = true;
            this.txtComment.Size = new System.Drawing.Size(400, 60);
            this.txtComment.BackColor = inputBack;
            this.txtComment.ForeColor = text;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10);

            // lblAddComment
            this.lblAddComment.Text = "Write a Comment:";
            this.lblAddComment.Location = new System.Drawing.Point(200, 340);
            this.lblAddComment.ForeColor = text;
            this.lblAddComment.AutoSize = true;
            this.lblAddComment.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            // btnAddComment
            this.btnAddComment.Location = new System.Drawing.Point(630, 385);
            this.btnAddComment.Size = new System.Drawing.Size(120, 35);
            this.btnAddComment.Text = "Comment";
            this.btnAddComment.BackColor = buttonBack;
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);

            // Controls
            this.Controls.Add(this.lblAddComment);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.dgvComments);

            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Label lblAddComment;
    }
}
