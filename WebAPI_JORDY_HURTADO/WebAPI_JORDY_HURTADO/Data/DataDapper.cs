using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAPI_JORDY_HURTADO.Data
{
    public class DataDapper
    {
        private readonly string _connectionString;

        public DataDapper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new
                InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
