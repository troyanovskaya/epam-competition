using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Product;
using LocalGoods.DAL.Entities;
using LocalGoods.Shared.FilterModels;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.GetAllByVendorId;

[TestFixture]
public class GivenValidRequest: ProductServiceBaseSetup
{
    private IEnumerable<ProductModel> _expected;
    private IEnumerable<Product> _entities;
    private IEnumerable<ProductModel> _actual;
    private Guid _vendorId;

    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new ProductModelBuilder().Build(10).ToList();
        _entities = new ProductBuilder().Build(10);
        _vendorId = _expected.First().VendorId;

        _mockProductRepository
            .Setup(repo => repo.GetByFilterAsync(It.IsAny<Expression<Func<Product, bool>>>()))
            .ReturnsAsync(_entities);

        _mockMapper
            .Setup(mapper => mapper.Map<IEnumerable<ProductModel>>(It.IsAny<IEnumerable<Product>>()))
            .Returns(_expected);

        _actual = await _sut.GetByVendorIdAsync(_vendorId);
    }

    [Test]
    public void ThenProductRepositoryIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.GetByFilterAsync(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
    }

    [Test]
    public void ThenActualIsEquivalentToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}