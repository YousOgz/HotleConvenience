using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotleConvenience.Lib.Http
{
    public class HttpTool
    {

        public static async Task<string> GetStringAsync(string uri)
        {
            using (HttpClient httpClient = new HttpClient()) { 
                return await httpClient.GetStringAsync(uri);
            }
        }
    }
}
