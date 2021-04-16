using Microsoft.Extensions.Configuration;

using System;
using System.Data.SqlClient;

namespace FagronTech.Infrastructure.Data
{
    public class ConnectionRepository
    {
        protected SqlConnection conn;

        public ConnectionRepository()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();

            conn = new SqlConnection(builder.GetConnectionString("FagronTech"));
        }
    }
}
