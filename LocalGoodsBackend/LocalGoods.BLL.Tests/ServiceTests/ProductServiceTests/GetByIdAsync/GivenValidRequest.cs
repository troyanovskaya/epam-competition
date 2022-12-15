using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Product;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.GetByIdAsync;

[TestFixture]
public class GivenValidRequest: ProductServiceBaseSetup
{
    private ProductModel _expected;
    private Product _entity;
    private Guid _id;
    private ProductModel _actual;


    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new ProductModelBuilder().Build();
        _entity = new ProductBuilder().Build();
        _id = _expected.Id;

        _mockProductRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_entity);

        _mockMapper
            .Setup(mapper => mapper.Map<ProductModel>(It.IsAny<Product>()))
            .Returns(_expected);

        _actual = await _sut.GetByIdAsync(_id);
    }

    [Test]
    public void ThenProductRepositoryIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.GetByIdAsync(_id), Times.Once);
    }

    [Test]
    public void ThenActualIsEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}