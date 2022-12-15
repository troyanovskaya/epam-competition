using AutoMapper;
using LocalGoods.BLL.Services;
using LocalGoods.DAL.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.CategoryServiceTests;

public class CategoryServiceBaseSetup
{
    protected Mock<ICategoryRepository> _mockCategoryRepository;
    protected Mock<IMapper> _mockMapper;
    protected CategoryService _sut;

    [OneTimeSetUp]
    public void BaseInit()
    {
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _mockMapper = new Mock<IMapper>();

        _sut = new CategoryService(
            _mockCategoryRepository.Object,
            _mockMapper.Object);
    }
}