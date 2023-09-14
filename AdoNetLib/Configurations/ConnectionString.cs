using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetLib.Configurations
{
    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Data Source=.\sqlexpress;Database=myDB;Trusted_Connection=True;Encrypt=false";
    }
}
