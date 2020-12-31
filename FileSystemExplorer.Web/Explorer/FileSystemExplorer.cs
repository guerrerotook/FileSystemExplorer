namespace FileSystemExplorer.Web.Explorer
{
    using FileSystemExplorer.Web.Configuration;
    using FileSystemExplorer.Web.Explorer.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

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

        public List<Item> GetSubdirectories()
        {
            List<Item> result = new List<Item>();
            result.AddRange(ConvertPathToItems(Directory.GetDirectories(currentPath)));
            return result;
        }

        public List<Item> GetFiles()
        {
            List<Item> result = new List<Item>();
            result.AddRange(ConvertPathToItems(Directory.GetFiles(currentPath)));
            return result;
        }

        private List<Item> ConvertPathToItems(IEnumerable<string> paths)
        {
            List<Item> result = new List<Item>();

            if (paths != null && paths.Count() > 0)
            {
                foreach (var path in paths)
                {
                    FileInfo info = new FileInfo(path);
                    Item item = new Item()
                    {
                        Path = path,
                        Created = info.CreationTime,
                        Name = Path.GetFileName(path),
                        LastTimeUpdated = info.LastWriteTime,
                        Source = configuration,
                        ItemType = ItemType.File
                        
                    };
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
