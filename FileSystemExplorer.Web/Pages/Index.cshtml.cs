using FileSystemExplorer.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemExplorer.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private List<ConfigurationItem> fileSystems;

        public IndexModel(ILogger<IndexModel> logger, FileSystemConfiguration fileSystemConfiguration)
        {
            fileSystems = fileSystemConfiguration.GetFileSystemConfiguration();

            _logger = logger;
        }

        public List<ConfigurationItem> ConfiguredFileSystem
        {
            get
            {
                return fileSystems;
            }
        }

        public void OnGet()
        {
            
        }
    }
}
