using LDPhotoSearch.Controllers;
using LDPhotoSearch.Managers;
using LDPhotoSearch.ServiceClients;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class UnitTest : Mocks
    {
        public UnitTest()
        {

        }

        [Theory]
        [InlineData("dog", 200)]
        public async Task ControllerTest(string searchParameter, int statusCode)
        {
            //Arrange
            var controller = new SearchController(searchManager);

            //Act
            var response = await controller.GetPhotos(searchParameter);
            OkObjectResult result = (OkObjectResult)response;

            //Assert
            Assert.Equal(result.StatusCode, statusCode);
        }

        [Theory]
        [InlineData("dog", 3)]
        public async Task ManagerTest(string searchParameter, int count)
        {
            //Arrange
            var manager = new SearchManager(flickrServiceClient);

            //Act
            var response = await manager.GetPhotosByTag(searchParameter);

            //Assert
            Assert.Equal(response.Items.Count, count);
        }

        [Theory]
        [InlineData("dog")]
        public async Task ServiceClientTest(string searchParameter)
        {
            //Arrange
            var serviceClient = new FlickrServiceClient(httpClient, configuration);

            //Act
            var response = await serviceClient.GetFlickrFeed(searchParameter);

            //Assert
            Assert.NotNull(response);
        }
    }
}
