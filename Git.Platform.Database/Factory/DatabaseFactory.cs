using Git.Platform.Database.Databases;
using Git.Platform.Database.Enums;
using Git.Platform.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Database.Factory
{
    public static class DatabaseFactory
    {
        public static IDatabase GetDatabase(EnumDatabaseType sTypeConnection, string sConnectionString)
        {
            IDatabase oReturnDatabase = null;

            switch (sTypeConnection)
            {
                case EnumDatabaseType.SqlServer:
                    oReturnDatabase = new DatabaseSqlServer(sConnectionString);
                    break;
                case EnumDatabaseType.Oracle:
                    oReturnDatabase = new DatabaseOracle(sConnectionString);
                    break;
                case EnumDatabaseType.MySQL:
                    oReturnDatabase = new DatabaseMySQL(sConnectionString);
                    break;
                case EnumDatabaseType.SQLite:
                    oReturnDatabase = new DatabaseSQLite(sConnectionString);
                    break;
                default:
                    oReturnDatabase = null;
                    break;
            }

            return oReturnDatabase;
        }
    }
}
