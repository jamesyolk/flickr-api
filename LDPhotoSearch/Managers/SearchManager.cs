using LDPhotoSearch.Models;
using LDPhotoSearch.ServiceClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LDPhotoSearch.Managers
{
    public class SearchManager: ISearchManager
    {
        private IFlickrServiceClient _flickrServiceClient;

        public SearchManager(IFlickrServiceClient flickrServiceClient)
        {
            _flickrServiceClient = flickrServiceClient;
        }

        public async Task<PhotoResultDomain> GetPhotosByTag(string request)
        {
            return await _flickrServiceClient.GetFlickrFeed(request);
        }
    }
}
