using LDPhotoSearch.Managers;
using LDPhotoSearch.Models;
using LDPhotoSearch.ServiceClients;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Mocks
    {
        protected ISearchManager searchManager;
        protected IFlickrServiceClient flickrServiceClient;
        private string dataPath = "PhotoResultDomainData.json";
        protected IConfiguration configuration;
        protected IHttpClientFactory httpClient;


        public Mocks()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

            httpClient = Substitute.For<IHttpClientFactory>();

            flickrServiceClient = Substitute.For<IFlickrServiceClient>();

            searchManager = Substitute.For<ISearchManager>();

            Init();
        }



        private void Init()
        {
            var domain = HydratePhotoResultDomain();

            searchManager.GetPhotosByTag(Arg.Any<string>()).Returns(Task.FromResult(HydratePhotoResultDomain()));

            flickrServiceClient.GetFlickrFeed(Arg.Any<string>()).Returns(Task.FromResult(HydratePhotoResultDomain()));

            httpClient.CreateClient().Returns(new HttpClient());
        }

        private PhotoResultDomain HydratePhotoResultDomain()
        {
            PhotoResultDomain photoResultDomain;

            var json = ReadFile(dataPath);

            return photoResultDomain = JsonConvert.DeserializeObject<PhotoResultDomain>(json);

        }


        private string ReadFile(string fileToRead)
        {
            using (StreamReader sr = new StreamReader(fileToRead))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
