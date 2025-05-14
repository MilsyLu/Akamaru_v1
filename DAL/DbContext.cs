using System.Data.SqlClient;

namespace DAL
{
    public class DbContext
    {
        //CUSTODES-DELL
        private readonly string connectionString = "Server=CUSTODES-DELL\\SQLEXPRESS;Database=Akamaru_v1;Integrated Security=True;";

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
