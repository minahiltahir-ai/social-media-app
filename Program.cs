using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp1
{



    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }

    public static class Session
    {
        public static int UserID;
        public static string Email;
        public static string FullName;

    }
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Bio { get; set; }

        public string ProfilePicture { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }

    public class Message
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get; set; }
    }

    internal static class Program
    {

        public static string ConnectionString = "Data Source=DESKTOP-7A3EJ54\\SQLEXPRESS;Initial Catalog=Social_Media_DB;Integrated Security=True;";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new WelcomeForm());
        }
    }
}
