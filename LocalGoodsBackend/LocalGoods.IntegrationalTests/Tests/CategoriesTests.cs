using LocalGoods.DAL.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace LocalGoods.IntegrationalTests.Tests
{
    public class CategoriesTests
    {
        private TestingWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/Categories";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };


        [SetUp]
        public void Setup()
        {
            _factory = new TestingWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GetAll_Void_ReturnsListOfCategoriesFromDb()
        {
            var expectedIds = new List<Guid>() { new Guid("9bc8afad-4ae9-44c3-b0d6-c1899f107489"), new Guid("86e17735-2063-4567-8a3a-e9f1d22cbb0a") };

            var httpResponse = await _client.GetAsync(RequestUri);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModels = JsonSerializer.Deserialize<List<Category>>(stringResponse, _options);

            Assert.That(actualModels.Select(gm => gm.Id), Is.EquivalentTo(expectedIds));
        }
    }
}
