using Git.Platform.Database.Enums;
using Git.Platform.Database.Factory;
using Git.Platform.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Database
{
    public class DatabaseConfiguration
    {
        protected const string SELECTED_DATABASE_TYPE = "SelectedDatabaseType";
        protected const string CONNECTIONSTRING_DATABASE = "ConnectionStringDatabase";
        protected IDatabase oData { get; set; }

        public DatabaseConfiguration()
        {
            try
            {
                EnumDatabaseType enumSelectedDatabaseType;
                string sValueSelectedDatabaseType = string.Empty;
                string sKeyConnectionString = string.Empty;
                string sConnectionString = string.Empty;

                sValueSelectedDatabaseType = ConfigurationManager.AppSettings[SELECTED_DATABASE_TYPE];
                sKeyConnectionString = string.Format("{0}_{1}", CONNECTIONSTRING_DATABASE, sValueSelectedDatabaseType);

                enumSelectedDatabaseType = (EnumDatabaseType)Enum.Parse(typeof(EnumDatabaseType), sValueSelectedDatabaseType);
                sConnectionString = ConfigurationManager.AppSettings[sKeyConnectionString];

                this.oData = DatabaseFactory.GetDatabase(enumSelectedDatabaseType, sConnectionString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
