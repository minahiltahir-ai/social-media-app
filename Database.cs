using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public static class Database
    {
        private static readonly string _cs = Program.ConnectionString;

        public static int Execute(string sql, params SqlParameter[] p)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(p);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object Scalar(string sql, params SqlParameter[] p)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(p);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] p)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(p);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
