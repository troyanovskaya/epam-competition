using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.DeleteAsync;

[TestFixture]
public class GivenValidRequest: ProductServiceBaseSetup
{
    private Guid _id;
    private Guid _userId;

    [OneTimeSetUp]
    public async Task Init()
    {
        _id = Guid.NewGuid();
        _userId = Guid.NewGuid();

        _mockProductRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Product {Vendor = new Vendor {UserId = _userId }});
        
        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", _userId.ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = Guid.NewGuid() });

        await _sut.DeleteProductAsync(_id);
    }

    [Test]
    public void ThenProductRepositoryGetByIdIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.GetByIdAsync(_id), Times.Once);
    }

    [Test]
    public void ThenProductRepositoryDeleteAsyncIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.DeleteByIdAsync(_id), Times.Once);
    }

    [Test]
    public void ThenSaveChangesAsyncIsCalledOnce()
    {
        _mockProductRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }
}