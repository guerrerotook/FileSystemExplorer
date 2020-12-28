using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemExplorer.Web.Configuration
{
    public class ConfigurationItem
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public void CalculateId()
        {
            if (!string.IsNullOrEmpty(Path) && !string.IsNullOrEmpty(Name))
            {
                UTF8Encoding encoding = new UTF8Encoding();

                using (HMACSHA256 sha256Hash = new HMACSHA256(encoding.GetBytes("mysuperkey")))
                {
                    byte[] hashResult = sha256Hash.ComputeHash(encoding.GetBytes(string.Concat(Name, Path)));
                    Id = BitConverter.ToString(hashResult).Replace("-", "").ToLower();
                }
            }
        }
    }
}
