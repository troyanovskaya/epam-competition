using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LocalGoods.BLL.Models.Category;
using LocalGoods.BLL.Tests.ServiceTests.Builders.Category;
using LocalGoods.DAL.Entities;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.CategoryServiceTests.GetAllAsync;

[TestFixture]
public class GivenValidRequest: CategoryServiceBaseSetup
{
    private IEnumerable<CategoryModel> _expected;
    private IEnumerable<CategoryModel> _actual;
    private IEnumerable<Category> _entities;

    [OneTimeSetUp]
    public async Task Init()
    {
        _expected = new CategoryModelBuilder().Build(10);
        _entities = new CategoryBuilder().Build(10);

        _mockCategoryRepository
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(_entities);

        _mockMapper
            .Setup(mapper => mapper.Map<IEnumerable<CategoryModel>>(It.IsAny<IEnumerable<Category>>()))
            .Returns(_expected);

        _actual = await _sut.GetAllAsync();
    }

    [Test]
    public void ThenCategoryRepositoryIsCalledOnce()
    {
        _mockCategoryRepository
            .Verify(repo => repo.GetAllAsync(), Times.Once);
    }

    [Test]
    public void ActualShouldBeEqualToExpected()
    {
        _actual.Should().BeEquivalentTo(_expected);
    }
}