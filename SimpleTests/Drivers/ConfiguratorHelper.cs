using Microsoft.Extensions.Configuration;
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

        public static UISettingModel GetUISection()
        {
            return Config.GetSection("uiSection").Get<UISettingModel>();
        }
    }
}
