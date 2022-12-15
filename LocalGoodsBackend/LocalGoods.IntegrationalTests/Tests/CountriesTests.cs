using LocalGoods.BLL.Models.UnitType;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using LocalGoods.DAL.Entities;

namespace LocalGoods.IntegrationalTests.Tests
{
    public class CountriesTests
    {
        private TestingWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/Countries";
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
        public async Task GetAll_Void_ReturnsListOfCountriesFromDb()
        {
            var expectedIds = new List<Guid>() { new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65"), new Guid("ea2db0cb-5c16-4764-a513-6e9303fe29e8") };

            var httpResponse = await _client.GetAsync(RequestUri);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModels = JsonSerializer.Deserialize<List<Country>>(stringResponse, _options);

            Assert.That(actualModels.Select(gm => gm.Id), Is.EquivalentTo(expectedIds));
        }

        [Test]
        public async Task GetAllCitiesByCountryId_Id_ReturnsListOfCitiesByCountryFromDb()
        {
            var cityId = new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65");
            var expectedIds = new List<Guid>() { new Guid("e22137e8-4a34-4e9c-a959-0e6d86d2fe65") };

            var httpResponse = await _client.GetAsync($"{RequestUri}/{cityId}/cities");

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModels = JsonSerializer.Deserialize<List<City>>(stringResponse, _options);

            Assert.That(actualModels.Select(gm => gm.Id), Is.EquivalentTo(expectedIds));
        }

        [Test]
        public async Task GetById_Id_ReturnsNotFoundStatusCode()
        {
            var expectedStatusCode = HttpStatusCode.NotFound;

            var httpResponse = await _client.GetAsync($"{RequestUri}/{Guid.NewGuid()}/cities");

            Assert.AreEqual(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
