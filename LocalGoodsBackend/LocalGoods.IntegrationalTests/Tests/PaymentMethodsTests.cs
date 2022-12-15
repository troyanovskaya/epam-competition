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
    public class PaymentMethodsTests
    {
        private TestingWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/PaymentMethods";
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
        public async Task GetAll_Void_ReturnsListOfPaymentMethodsFromDb()
        {
            var expectedIds = new List<Guid>() { new Guid("35504646-c984-4ac7-9dc2-66f4ea37a28b"), new Guid("ee963372-7320-43b3-b467-9702ac1dd770") };

            var httpResponse = await _client.GetAsync(RequestUri);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModels = JsonSerializer.Deserialize<List<PaymentMethod>>(stringResponse, _options);

            Assert.That(actualModels.Select(gm => gm.Id), Is.EquivalentTo(expectedIds));
        }

        [Test]
        public async Task GetById_Id_ReturnsPaymentMethodFromDbById()
        {
            var id = TestingWebApplicationFactory.PaymentMethods[1].Id;

            var httpResponse = await _client.GetAsync($"{RequestUri}/{id}");

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actualModel = JsonSerializer.Deserialize<PaymentMethod>(stringResponse, _options);

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
