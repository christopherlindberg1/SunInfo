using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CoreLibrary.ApiClients
{
    public interface IApiHelper
    {
        HttpClient HttpClient { get; set; }
    }
}
