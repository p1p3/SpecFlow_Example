using System;
using System.Configuration;
using System.Globalization;

namespace SpecFlowHelpers.Configuration
{
  
    public class AppConfiguration : IAppConfiguration
    {
        #region Constants

        public const string CommandTimeoutSqlServer = "CommandTimeoutSqlServer";
        public const int DefaultCommandTimeoutSqlServer = 30;

        #endregion

        #region Public Properties

        public int CommandTimeoutSql
        {
            get
            {
                string configuratedValue = this.GetValue(CommandTimeoutSqlServer);

                if (string.IsNullOrWhiteSpace(configuratedValue))
                {
                    return DefaultCommandTimeoutSqlServer;
                }
                else
                {
                    return Convert.ToInt32(configuratedValue, CultureInfo.InvariantCulture);
                }
            }
        }


        #endregion

        #region Public Methods

        public string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        #endregion
    }
}
