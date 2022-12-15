using LocalGoods.BLL.Models.UnitType;
using LocalGoods.DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalGoods.IntegrationalTests.Tests
{
    public class DeliveryMethodsTests
    {
        private TestingWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/DeliveryMethods";
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
        public async Task GetAll_Void_ReturnsListOfDeliveryMethodsFromDb()
        {
            var expectedIds = new List<Guid>() { new Guid("16d4764c-60d8-4720-ab4c-aff9916618f6"), new Guid("9d82e197-90c7-4f72-9cfc-816c614a0bab") };

            var httpResponse = await _client.GetAsync(RequestUri);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModels = JsonSerializer.Deserialize<List<DeliveryMethod>>(stringResponse, _options);

            Assert.That(actualModels.Select(gm => gm.Id), Is.EquivalentTo(expectedIds));
        }

        [Test]
        public async Task GetById_Id_ReturnsDeliveryMethodFromDbById()
        {
            var id = TestingWebApplicationFactory.DeliveryMethods[1].Id;

            var httpResponse = await _client.GetAsync($"{RequestUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModel = JsonSerializer.Deserialize<DeliveryMethod>(stringResponse, _options);

            Assert.AreEqual(actualModel.Id, id);
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
