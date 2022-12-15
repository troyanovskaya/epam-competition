using System;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests.DeleteAsync;

[TestFixture]
public class GivenInvalidId: ProductServiceBaseSetup
{
    private Func<Task> _act;

    [OneTimeSetUp]
    public async Task Init()
    {
        _act = async () => await _sut.DeleteProductAsync(Guid.NewGuid());
    }

    [Test]
    public void ThenProductNotFoundExceptionIsThrown()
    {
        _act.Should().ThrowAsync<ProductNotFoundException>();
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