using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.GlobalVariables
{
    public static class MyHttpClient
    {
        public static HttpClient client = new HttpClient();

        static MyHttpClient()
        {
            client.BaseAddress = new Uri("http://localhost:45325/api/");
        }
    }
}
