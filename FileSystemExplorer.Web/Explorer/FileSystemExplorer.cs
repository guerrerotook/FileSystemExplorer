using FileSystemExplorer.Web.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemExplorer.Web.Explorer
{
    public class FileSystemExplorerManager
    {
        private ConfigurationItem configuration;
        private string currentPath;

        public FileSystemExplorerManager(ConfigurationItem configuration)
        {
            this.configuration = configuration;
            Reset();
        }

        public void Reset()
        {
            currentPath = configuration.Path;
        }

        public bool Exits()
        {
            return Directory.Exists(currentPath);
        }

        public void SetRelativeDirectory(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {                
                string temporalPath = Path.Combine(currentPath, value);
                temporalPath = Path.GetFullPath(temporalPath);
                if (temporalPath.ToLowerInvariant().StartsWith(configuration.Path.ToLowerInvariant()))
                {
                    // TODO: Check that the combination of the path never leave the configuration.Path property. 
                    // Allowing an attacker to access file system outside the scope.
                    currentPath = temporalPath;
                }
            }
        }

        public List<string> GetSubdirectories()
        {
            List<string> result = new List<string>();
            result.AddRange(Directory.GetDirectories(currentPath));
            return result;
        }

        public List<string> GetFiles()
        {
            List<string> result = new List<string>();
            result.AddRange(Directory.GetFiles(currentPath));
            return result;
        }
    }
}
