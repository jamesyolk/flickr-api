using LDPhotoSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LDPhotoSearch.Managers
{
    public interface ISearchManager
    {
        Task<PhotoResultDomain> GetPhotosByTag(string request);
    }
}
