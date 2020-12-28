using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystemExplorer.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemExplorer.WebTests;
using System.Net.Http;
using System.Net;

namespace FileSystemExplorer.Web.Controllers.Tests
{
    [TestClass()]
    public class FileControllerTests
    {
        [TestMethod()]
        public async Task GetDirectoryTest()
        {
            using (ServerManager server = new ServerManager())
            {
                HttpResponseMessage response = await server.Client.GetAsync("api/File/b1309c00e09af836e424f638d165cc21c66cc0cc4ee321b24b6f0e91fd42c7a7/GetDirectory");                
                response.EnsureSuccessStatusCode();
                Assert.Equals(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}