using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.DeleteAsync;

[TestFixture]
public class GivenInvalidUserId: ProductServiceBaseSetup
{
    private Guid _id;
    private Guid _userId;
    private Func<Task> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _id = Guid.NewGuid();
        _userId = Guid.NewGuid();

        _mockProductRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Product {Vendor = new Vendor {UserId = Guid.NewGuid() }});
        
        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", _userId.ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = Guid.NewGuid() });

        _act = async () => await _sut.DeleteProductAsync(_id);
    }

    [Test]
    public void ThenAuthExceptionIsThrown()
    {
        _act.Should().ThrowAsync<AuthException>();
    }
    
    [Test]
    public void ThenProductRepositoryDeleteAsyncIsNeverCalled()
    {
        _mockProductRepository
            .Verify(repo => repo.DeleteAsync(It.IsAny<Product>()), Times.Never);
    }

    [Test]
    public void ThenSaveChangesAsyncIsNeverCalled()
    {
        _mockProductRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Never);
    }
}