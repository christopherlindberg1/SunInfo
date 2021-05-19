using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CoreLibrary.ApiClients
{
    public class ApiHelper
    {
        public HttpClient HttpClient { get; set; }

        public ApiHelper()
        {
            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            HttpClient = new HttpClient();

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
