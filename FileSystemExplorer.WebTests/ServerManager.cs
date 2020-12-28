using FileSystemExplorer.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemExplorer.WebTests
{
    public class ServerManager : IDisposable
    {
        public HttpClient Client { get; private set; }

        public ServerManager()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            if (Client != null)
            {
                Client.Dispose();
            }
        }
    }
}
