namespace FileSystemExplorer.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FileSystemExplorer.Web.Configuration;
    using FileSystemExplorer.Web.Explorer;
    using FileSystemExplorer.Web.Explorer.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class ExploreModel : PageModel
    {
        private readonly ILogger<ExploreModel> _logger;
        private ConfigurationItem currentConfiguration;
        private FileSystemConfiguration fileSystemConfiguration;

        public ExploreModel(ILogger<ExploreModel> logger, FileSystemConfiguration fileSystemConfiguration)
        {
            this.fileSystemConfiguration = fileSystemConfiguration;

            _logger = logger;
        }

        public IQueryable<Item> Items { get; set; }

        public ConfigurationItem CurrentConfiguration
        {
            get
            {
                return currentConfiguration;
            }
        }

        public IActionResult OnGet(string id, string directory = null)
        {
            currentConfiguration = fileSystemConfiguration.GetConfigurationById(id);
            if (currentConfiguration != null)
            {
                FileSystemExplorerManager manager = new FileSystemExplorerManager(currentConfiguration);
                List<Item> items = new List<Item>();
                manager.SetRelativeDirectory(directory);
                items.AddRange(manager.GetSubdirectories());
                items.AddRange(manager.GetFiles());
                this.Items = items.AsQueryable();
            }

            return Page();
        }
    }
}
