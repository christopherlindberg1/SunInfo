using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.ApiClients
{
    public class SunApiClient
    {
        private string _baseUrl = "https://api.sunrise-sunset.org/json";

        private string BuildUrl(string latitude, string longitude, DateTime? date)
        {
            StringBuilder url = new StringBuilder(_baseUrl);

            url.Append($"?lat={ latitude }");
            url.Append($"&lng={ longitude }");

            if (date != null)
            {
                url.Append($"&date={ date.Value.Date }");
            }

            return url.ToString();
        }

        
    }
}
