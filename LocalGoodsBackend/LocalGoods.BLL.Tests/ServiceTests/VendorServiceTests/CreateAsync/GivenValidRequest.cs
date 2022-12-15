using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentAssertions;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.CreateAsync;

[TestFixture]
public class GivenValidRequest: VendorServiceBaseSetup
{
    private CreateVendorModel _createVendorModel;
    private Guid _userId;
    private VendorModel _expected;
    private VendorModel _actual;

    [OneTimeSetUp]
    public async Task Init()
    {
        _createVendorModel = new CreateVendorModelBuilder().Build();
        _userId = Guid.NewGuid();
        _expected = new VendorModelBuilder().Build();
        
        _mockHttpContextAccessor
            .Setup(accessor => accessor.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("Fake", _userId.ToString()));

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User() { Id = _userId });

        _mockMapper
            .Setup(mapper => mapper.Map<Vendor>(It.IsAny<CreateVendorModel>()))
            .Returns(new Vendor());

        _mockDeliveryMethodRepository
            .Setup(repo => repo.GetExceptIdsAsync(It.IsAny<IEnumerable<Guid>>()))
            .Returns(new List<Guid>());
        
        _mockPaymentMethodRepository
            .Setup(repo => repo.GetExceptIdsAsync(It.IsAny<IEnumerable<Guid>>()))
            .Returns(new List<Guid>());

        _mockMapper
            .Setup(mapper => mapper.Map<VendorModel>(It.IsAny<Vendor>()))
            .Returns(_expected);

        _actual = await _sut.CreateAsync(_createVendorModel);
    }

    [Test]
    public void ThenVendorRepositoryGetByNameAsyncIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.GetByNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void ThenVendorRepositoryGetByUserIdIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.GetByUserIdAsync(_userId), Times.Once);
    }

    [Test]
    public void ThenVendorRepositoryAddAsyncIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.AddAsync(It.IsAny<Vendor>()), Times.Once);
    }

    [Test]
    public void ThenVendorDeliveryMethodRepositoryIsCalledOnce()
    {
        _mockVendorDeliveryMethodRepository
            .Verify(repo => repo.AddRangeAsync(It.IsAny<IEnumerable<VendorDeliveryMethod>>()),
                Times.Once);
    }

    [Test]
    public void ThenVendorPaymentMethodRepositoryIsCalledOnce()
    {
        _mockVendorPaymentMethodRepository
            .Verify(repo => repo.AddRangeAsync(It.IsAny<IEnumerable<VendorPaymentMethod>>()),
                Times.Once);
    }

    [Test]
    public void ThenUserManagerAddToRolAsyncIsCalledOnce()
    {
        _mockUserManager
            .Verify(um => um.AddToRoleAsync(It.IsAny<User>(), "Vendor"), Times.Once);
    }
    
    [Test]
    public void ThenSaveChangesAsyncIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void ThenActualIsEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}