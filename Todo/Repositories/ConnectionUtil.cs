using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ConnectionUtil
    {
        public IConfiguration _configuration;
        public ConnectionUtil(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("DapperConfig").Value;
        }
    }
}
