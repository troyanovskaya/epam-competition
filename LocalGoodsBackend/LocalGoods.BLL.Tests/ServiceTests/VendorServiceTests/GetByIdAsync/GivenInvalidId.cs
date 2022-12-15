using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Vendor;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.GetByIdAsync;

[TestFixture]
public class GivenInvalidId: VendorServiceBaseSetup
{
    private Func<Task<VendorModel>> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _act = async () => await _sut.GetByIdAsync(Guid.NewGuid());
    }

    [Test]
    public void ThenVendorNotFoundExceptionIsThrown()
    {
        _act.Should().ThrowAsync<VendorNotFoundException>();
    }
}