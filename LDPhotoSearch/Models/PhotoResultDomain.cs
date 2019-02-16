using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDPhotoSearch.Models
{
    public class PhotoResultDomain
    {
        public PhotoResultDomain()
        {
            Items = new List<PhotoItemDomain>();
        }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
        [JsonProperty("generator")]
        public string Generator { get; set; }
        [JsonProperty("items")]
        public List<PhotoItemDomain> Items { get; set; }
    }
}
