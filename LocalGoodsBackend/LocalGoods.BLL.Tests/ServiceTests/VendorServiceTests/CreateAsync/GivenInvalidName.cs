using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.CreateAsync;

[TestFixture]
public class GivenInvalidName: VendorServiceBaseSetup
{
    private CreateVendorModel _createVendorModel;
    private Guid _userId;
    private Func<Task<VendorModel>> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _createVendorModel = new CreateVendorModelBuilder().Build();
        _userId = Guid.NewGuid();

        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", _userId.ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = _userId });

        _mockVendorRepository
            .Setup(repo => repo.GetByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(new Vendor());

        _act = async () => await _sut.CreateAsync(_createVendorModel);
    }
    
    [Test]
    public void ThenVendorBadRequestExceptionIsThrown()
    {
        _act.Should().ThrowAsync<VendorBadRequestException>();
    }
    
    [Test]
    public void ThenVendorRepositoryAddAsyncIsNeverCalled()
    {
        _mockVendorRepository
            .Verify(repo => repo.AddAsync(It.IsAny<Vendor>()), Times.Never);
    }
    
    [Test]
    public void ThenSaveChangesAsyncIsNeverCalled()
    {
        _mockVendorRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Never);
    }
}