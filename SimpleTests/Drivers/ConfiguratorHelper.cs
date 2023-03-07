using Microsoft.Extensions.Configuration;
using SimpleTests.Support.Models;
using SimpleTests.Support.SettingModels;

namespace SimpleTests.Drivers
{
    internal class ConfiguratorHelper
    {
        private static readonly string FileName = Path.GetFullPath(@"..//..//..//Properties//settings.json");
        private static readonly IConfigurationRoot Config;

        static ConfiguratorHelper()
        {
            Config = ReadFromJsonFile(FileName);
        }

        private static IConfigurationRoot ReadFromJsonFile(string fileName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(fileName);

            return builder.Build();
        }

        public static UrlSettingModel GetUISection()
        {
            return Config.GetSection("uiSection").Get<UrlSettingModel>();
        }

        public static UrlSettingModel GetAPISection()
        {
            return Config.GetSection("apiSection").Get<UrlSettingModel>();
        }

        public static SqlSectionModel GetSqlSectionModel()
        {
            return Config.GetSection("dbSection").Get<SqlSectionModel>();
        }

    }
}
