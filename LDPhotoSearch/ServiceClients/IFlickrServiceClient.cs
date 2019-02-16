using LDPhotoSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LDPhotoSearch.ServiceClients
{
    public interface IFlickrServiceClient
    {
        Task<PhotoResultDomain> GetFlickrFeed(string request);
    }
}
