namespace FileSystemExplorer.Web.Explorer.Model
{
    using FileSystemExplorer.Web.Configuration;
    using System;

    public class Item
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public string Path { get; set; }

        public DateTime LastTimeUpdated { get; set; }

        public ConfigurationItem Source { get; set; }

        public ItemType ItemType { get; set; }
    }
}
