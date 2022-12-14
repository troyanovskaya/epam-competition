using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Product;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.GetByIdAsync;

[TestFixture]
public class GivenInvalidRequest: ProductServiceBaseSetup
{
    private ProductModel _expected;
    private Product _entity;
    private Guid _id;
    private Func<Task<ProductModel>> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new ProductModelBuilder().Build();
        _entity = new ProductBuilder().Build();
        _id = Guid.NewGuid();

        _mockProductRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_entity);

        _mockMapper
            .Setup(mapper => mapper.Map<ProductModel>(It.IsAny<Product>()))
            .Returns(_expected);

        _act = async () => await _sut.GetByIdAsync(_id);
    }

    [Test]
    public void ThenProductNotFoundExceptionIsThrown()
    {
        _act.Should().ThrowAsync<ProductNotFoundException>();
    }
}