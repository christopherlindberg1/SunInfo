using CoreLibrary.Models;
using System;
using System.Threading.Tasks;

namespace CoreLibrary.ApiClients
{
    public interface ISunApiClient
    {
        Task<SunDataModel> GetSunInformation(string latitude, string longitude, DateTime? date);
    }
}