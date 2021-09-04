using System;
using System.Net.Http;

using Constants;

using Domain;

namespace HttpServices
{
    public class HttpResourceService : HttpEntityServiceLite
    {
        public HttpResourceService(HttpClient httpClient) : base(httpClient)
        {
            httpClient.BaseAddress = DeployedState.IsDeployed ? new Uri(ApiUrl.ServerApiImageUrlDeployed) : new Uri(ApiUrl.ServerApiBase);

            this.HttpClient = httpClient;

            this.Url = ApiUrl.S_ServerApi_Resources_S;
            this.UrlApiUploader = ApiUrl.S_ApiUpload;
        }
    }
}
