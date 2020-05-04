using System.Configuration;
using System.Data;

namespace SimpleMvvmDemo.Common
{
    public class SqlDb
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        }

        public static IDbConnection UpdateConnection => new SqlServerConnection(GetConnectionString());

    }
}
