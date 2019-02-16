using Newtonsoft.Json;
using System;

namespace LDPhotoSearch.Models
{
    public class PhotoItemDomain
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("media")]
        public MediaLink Media { get; set; }       
        [JsonProperty("date_taken")]
        public DateTime DateTaken { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("published")]
        public DateTime Published { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("author_id")]
        public string AuthorId { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
    }
}