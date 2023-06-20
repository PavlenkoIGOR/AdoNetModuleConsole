using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetLib.Configurations
{
    public static class ConnectionString
    {
        public static string MsSqlConnection =>
            @"Server=DESKTOP-G5TER77.\SQLEXPRESS;Database=myBD;Trusted_Connection=True;";
    }
}
