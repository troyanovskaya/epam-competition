using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.GetByUserIdAsync;

[TestFixture]
public class GivenValidRequest: VendorServiceBaseSetup
{
    private Guid _userId;
    private VendorModel _expected;
    private VendorModel _actual;

    [OneTimeSetUp]
    public async Task Init()
    {
        _userId = Guid.NewGuid();
        _expected = new VendorModelBuilder().Build();

        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new User());

        _mockVendorRepository
            .Setup(repo => repo.GetByUserIdAsync(_userId))
            .ReturnsAsync(new Vendor());

        _mockMapper
            .Setup(mapper => mapper.Map<VendorModel>(It.IsAny<Vendor>()))
            .Returns(_expected);

        _actual = await _sut.GetByUserIdAsync(_userId);
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
            .Verify(repo => repo.GetByUserIdAsync(_userId), Times.Once);
    }
    
    [Test]
    public void ThenActualIsEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}