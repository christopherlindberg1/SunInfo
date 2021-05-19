using CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace CoreLibrary.ApiClients
{
    public class SunApiClient : ISunApiClient
    {
        private IApiHelper _apiHelper;
        private string _baseUrl = "https://api.sunrise-sunset.org/json";

        public SunApiClient(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<SunDataModel> GetSunInformation(string latitude, string longitude, DateTime? date)
        {
            string url = BuildUrl(latitude, longitude, date);

            using (HttpResponseMessage response = await _apiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string stringResult = await response.Content.ReadAsStringAsync();

                    return ParseJsonResponse(stringResult);
                }
                else
                {
                    throw new InvalidOperationException(response.ReasonPhrase);
                }
            }
        }

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

        private SunDataModel ParseJsonResponse(string jsonString)
        {
            JsonDocument document = JsonDocument.Parse(jsonString);
            JsonElement result = document.RootElement.GetProperty("results");

            DateTime sunrise = DateTime.Parse(result.GetProperty("sunrise").ToString());
            DateTime sunset = DateTime.Parse(result.GetProperty("sunset").ToString());

            SunDataModel sunDataModel = new SunDataModel
            {
                Sunrise = sunrise,
                Sunset = sunset
            };

            return sunDataModel;
        }
    }
}
