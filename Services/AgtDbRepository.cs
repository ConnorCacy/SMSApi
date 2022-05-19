using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
namespace SMSApi.Services
{
    public class AgtDbRepository : IAgtDbRepository
    {
        private readonly IConfiguration _config;

        public AgtDbRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetPhoneByAgtNumber(string agtNumber)
        {
            using (var con = new SqlConnection(
                _config.GetConnectionString("default")))
                return await con.QuerySingleOrDefaultAsync<string>(
                    "SELECT Phone FROM AgentInfo WHERE AgentNumber = @agtNumber",
                    new { agtNumber });
        }
    }
}
