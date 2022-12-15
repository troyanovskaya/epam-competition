using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Product;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.CreateAsync;

[TestFixture]
public class GivenInvalidUserId: ProductServiceBaseSetup
{
    private CreateProductModel _model;
    private Guid _userId;
    private Func<Task<ProductModel>> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _model = new CreateProductModelBuilder().Build();
        _userId = Guid.NewGuid();

        _mockUnitTypeRepository
            .Setup(repo => repo.CheckIfEntityExistsByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);

        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", Guid.NewGuid().ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = Guid.NewGuid() });

        _mockVendorRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Vendor() {UserId = _userId});

        _act = async  () => await _sut.CreateAsync(_model);
    }

    [Test]
    public void ThenProductBadRequestExceptionIsThrown()
    {
        _act.Should().ThrowAsync<ProductBadRequestException>();
    }

    [Test]
    public void ThenProductAddAsyncIsNeverCalled()
    {
        _mockProductRepository
            .Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Never);
    }
    
    [Test]
    public void ThenSaveChangesAsyncIsNeverCalled()
    {
        _mockProductRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Never);
    }
}