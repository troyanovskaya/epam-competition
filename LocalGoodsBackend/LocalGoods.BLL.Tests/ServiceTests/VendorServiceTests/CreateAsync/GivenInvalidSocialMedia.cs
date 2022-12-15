using System;
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
public class GivenInvalidSocialMedia: VendorServiceBaseSetup
{
    private CreateVendorModel _createVendorModel;
    private Func<Task<Task<VendorModel>>> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _createVendorModel = new CreateVendorModelBuilder().Build();
        _createVendorModel.ViberNumber = null;

        _act = async () => _sut.CreateAsync(_createVendorModel);
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