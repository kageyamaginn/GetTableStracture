using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTableStracture
{
    public class ConnectionInfo
    {
        public ConnectionInfo(string databaseType, string databaseName, String userName, String password)
        {
            this.DatabaseType = databaseType;
            this.DatabaseName = databaseName;
            this.UserName = userName;
            this.Password = password;
        }
        public String DatabaseType { get; set; }
        public String DatabaseName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
