using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDusingSP.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("sqlConnection");
        }
        public IDbConnection createCon()
            =>new SqlConnection(connectionString);
    }
}
