using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LDPhotoSearch.Managers;
using LDPhotoSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LDPhotoSearch.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchManager _searchManager;

        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        /// <summary>
        /// Search Flickr feed with keywords
        /// </summary>
        /// <param name="q">Keywords to search, use comma to search multiple keywords</param>
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPhotos([FromQuery] string q)
        {
            PhotoResultDomain msg = null;

            try
            {
                var response = await _searchManager.GetPhotosByTag(q);
                msg = response;
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok(msg);
        }
    }
}