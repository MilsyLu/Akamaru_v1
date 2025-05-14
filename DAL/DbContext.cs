using System.Data.SqlClient;

namespace DAL
{
    public class DbContext
    {
        private readonly string connectionString = "Server=FASTER\\SQLEXPRESS;Database=Akamaru_v1;Integrated Security=True;";

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
