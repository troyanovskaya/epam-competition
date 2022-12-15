using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Product;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.CreateAsync;

[TestFixture]
public class GivenValidRequest: ProductServiceBaseSetup
{
    private CreateProductModel _model;
    private ProductModel _actual;
    private ProductModel _expected;
    private Guid _userId;
    private Product _entity;

    [OneTimeSetUp]
    public async Task Init()
    {
        _model = new CreateProductModelBuilder().Build();
        _entity = new ProductBuilder().Build();
        _expected = new ProductModelBuilder().Build();
        _userId = Guid.NewGuid();

        _mockUnitTypeRepository
            .Setup(repo => repo.CheckIfEntityExistsByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);

        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", _userId.ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = Guid.NewGuid() });

        _mockVendorRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Vendor() {UserId = _userId});

        _mockMapper
            .Setup(mapper => mapper.Map<Product>(It.IsAny<CreateProductModel>()))
            .Returns(_entity);

        _mockMapper
            .Setup(mapper => mapper.Map<ProductModel>(It.IsAny<Product>()))
            .Returns(_expected);
        
        _actual = await _sut.CreateAsync(_model);
    }

    [Test]
    public void ThenUnitTypeRepositoryIsCalledOnce()
    {
        _mockUnitTypeRepository
            .Verify(repo => repo.CheckIfEntityExistsByIdAsync(_model.UnitTypeId), Times.Once);
    }

    [Test]
    public void ThenUserManagerIsCalledOnce()
    {
        _mockUserManager
            .Verify(um => um.FindByIdAsync(_userId.ToString()), Times.Once);
    }

    [Test]
    public void ThenVendorRepositoryIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.GetByIdAsync(_model.VendorId), Times.Once);
    }

    [Test]
    public void ThenSaveChangesAsyncIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void ThenActualIsEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}