using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using LocalGoods.BLL.Models.UnitType;
using System.Linq;

namespace LocalGoods.IntegrationalTests.Tests
{
    public class UnitTypesTests
    {
        private TestingWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/UnitTypes";
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
        public async Task GetAll_Void_ReturnsListOfUnitTypesFromDb()
        {
            var expectedUnitTypeIds = new List<Guid>() { new Guid("be508c77-6575-4a01-98cd-5fb2b1d848cb"), new Guid("55f6c87d-f2da-4971-bd67-7514669e6eaf") };

            var httpResponse = await _client.GetAsync(RequestUri);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualUnitTypeModels = JsonSerializer.Deserialize<List<UnitTypeModel>>(stringResponse, _options);

            Assert.That(actualUnitTypeModels.Select(gm => gm.Id), Is.EquivalentTo(expectedUnitTypeIds));
        }

        [Test]
        public async Task GetById_Id_ReturnsUnitTypeFromDbById()
        {
            var id = TestingWebApplicationFactory.UnitTypes[1].Id;

            var httpResponse = await _client.GetAsync($"{RequestUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualUnitTypeModel = JsonSerializer.Deserialize<UnitTypeModel>(stringResponse, _options);

            Assert.AreEqual(actualUnitTypeModel.Id, id);
        }

        [Test]
        public async Task GetById_Id_ReturnsNotFoundStatusCode()
        {
            var expectedStatusCode = HttpStatusCode.NotFound;

            var httpResponse = await _client.GetAsync($"{RequestUri}/{Guid.NewGuid()}");

            Assert.AreEqual(expectedStatusCode, httpResponse.StatusCode);
        }
    }
}
