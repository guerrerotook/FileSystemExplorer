using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemExplorer.Web.Configuration
{
    public class FileSystemConfiguration
    {
        private IConfiguration configuration;
        private List<ConfigurationItem> currentConfiguration;

        public FileSystemConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
            GetFileSystemConfiguration();
        }

        public List<ConfigurationItem> GetFileSystemConfiguration()
        {
            if (currentConfiguration == null)
            {
                currentConfiguration = new List<ConfigurationItem>();

                IConfigurationSection fileSystemConfigurationSection = configuration.GetSection("FileSystem");
                if (fileSystemConfigurationSection != null)
                {
                    foreach (var children in fileSystemConfigurationSection.GetChildren())
                    {
                        ConfigurationItem item = new ConfigurationItem()
                        {
                            Name = children.GetSection("Name").Value,
                            Path = children.GetSection("Path").Value
                        };
                        item.CalculateId();
                        currentConfiguration.Add(item);
                    }
                }
            }

            return currentConfiguration;
        }

        public ConfigurationItem GetConfigurationById(string value)
        {
            ConfigurationItem result = null;

            if (!string.IsNullOrEmpty(value))
            {
                result = currentConfiguration
                    .Where(p => p.Id == value)
                    .FirstOrDefault();
            }

            return result;
        }
    }
}
