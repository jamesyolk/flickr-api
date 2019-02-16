using LDPhotoSearch.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LDPhotoSearch.ServiceClients
{
    public class FlickrServiceClient: IFlickrServiceClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public FlickrServiceClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<PhotoResultDomain> GetFlickrFeed(string request)
        {
            var apiUrl = _configuration.GetValue<string>("Flickr:FeedUrl");
            var queryParams = new Dictionary<string, string>(){{ "format", "json" }};
            if(request != null)
            {
                queryParams.Add("tags", request);
            }

            var url = QueryHelpers.AddQueryString(apiUrl, queryParams);
            
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Parse invalid json returned by Flickr
            var length = responseContent.Length - 16;
            var parsed = responseContent.Substring(15, length);

            var result = JsonConvert.DeserializeObject<PhotoResultDomain>(parsed);

            return result;
        }
    }
}
