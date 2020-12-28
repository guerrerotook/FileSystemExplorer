using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileSystemExplorer.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FileSystemExplorer.Web.Pages
{
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
        
        public ConfigurationItem CurrentConfiguration
        {
            get
            {
                return currentConfiguration;
            }
        }

        public void OnGet(string id)
        {
            currentConfiguration = fileSystemConfiguration.GetConfigurationById(id);
            if (currentConfiguration != null)
            {

            }
        }
    }
}
