using FileSystemExplorer.Web.Configuration;
using FileSystemExplorer.Web.Explorer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemExplorer.Web.Controllers
{
    [Route("api/[controller]/{id}/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private FileSystemConfiguration fileSystemConfiguration;
        private FileSystemExplorerManager manager;

        public FileController(FileSystemConfiguration fileSystemConfiguration)
        {
            this.fileSystemConfiguration = fileSystemConfiguration;
            
        }


        [HttpGet] 
        public List<string> GetDirectory(string id, string directory = null)
        {
            manager = new FileSystemExplorerManager(fileSystemConfiguration.GetConfigurationById(id));
            manager.SetRelativeDirectory(directory);
            return manager.GetSubdirectories();
        }

        [HttpGet]
        public List<string> GetFiles(string id, string directory = null)
        {
            manager = new FileSystemExplorerManager(fileSystemConfiguration.GetConfigurationById(id));
            manager.SetRelativeDirectory(directory);
            return manager.GetFiles();
        }
    }
}
