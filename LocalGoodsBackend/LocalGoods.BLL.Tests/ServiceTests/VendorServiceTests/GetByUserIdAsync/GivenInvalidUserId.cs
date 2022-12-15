using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Vendor;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.GetByUserIdAsync;

[TestFixture]
public class GivenInvalidUserId: VendorServiceBaseSetup
{
    private Func<Task<VendorModel>> _act;
    private Guid _userId;

    [OneTimeSetUp]
    public async Task Init()
    {
        _userId = Guid.NewGuid();
        
        _mockUserManager
            .Setup(um => um.FindByIdAsync(It.IsAny<string>()));

        _act = async () => await _sut.GetByUserIdAsync(_userId);
    }

    [Test]
    public void ThenUserNotFoundExceptionIsThrown()
    {
        _act.Should().ThrowAsync<UserNotFoundException>();
    }

    [Test]
    public void ThenVendorRepositoryIsNeverCalled()
    {
        _mockVendorRepository
            .Verify(repo => repo.GetByUserIdAsync(_userId), Times.Never);
    }
}