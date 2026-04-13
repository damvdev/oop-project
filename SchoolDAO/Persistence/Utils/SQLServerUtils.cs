using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAO.Persistence.Utils
{
    public class SQLServerUtils
    {
        public static string OpenConnection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");

        }
    }
}
