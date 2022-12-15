using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests.GetByIdAsync;

[TestFixture]
public class GivenValidRequest: VendorServiceBaseSetup
{
    private VendorModel _expected;
    private Vendor _entity;
    private Guid _id;
    private VendorModel _actual;

    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new VendorModelBuilder().Build();
        _entity = new VendorBuilder().Build();
        _id = Guid.NewGuid();

        _mockVendorRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_entity);

        _mockMapper
            .Setup(mapper => mapper.Map<VendorModel>(It.IsAny<Vendor>()))
            .Returns(_expected);

        _actual = await _sut.GetByIdAsync(_id);
    }
    
    [Test]
    public void ThenVendorRepositoryIsCalledOnce()
    {
        _mockVendorRepository
            .Verify(repo => repo.GetByIdAsync(_id), Times.Once);
    }
    
    [Test]
    public void ThenActualIsEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}