using System.Data;
using System.Data.SqlClient;

namespace Ecomtest_Repository
{
    public class ConnectionString
    {
        public static string Cs = "server=NANA\\NICKSOFT;database=EcomTestDb;Trusted_Connection=true";
        public SqlConnection Conn = new SqlConnection(Cs);
        public SqlCommand Cmd = new SqlCommand();
        public SqlDataAdapter Da = new SqlDataAdapter();
        private string CoreConnectionString { get; set; }

        public string GetConnectionString()
        {
            return CoreConnectionString;
        }
        public void ConnectionDispose()
        {
            if (Conn.State != ConnectionState.Broken && Conn.State != ConnectionState.Executing &&
                Conn.State != ConnectionState.Connecting && Conn.State != ConnectionState.Fetching) return;
            Conn.Close();
            Cmd.Parameters.Clear();
            Cmd.Dispose();
        }

        public void ResetSqlCommand()
        {
            Cmd.Parameters.Clear();
            Cmd.Dispose();
        }
    }
}
