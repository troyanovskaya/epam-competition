using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Services;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.ProductServiceTests;

public class ProductServiceBaseSetup
{
    protected Mock<IMapper> _mockMapper;
    protected Mock<IProductRepository> _mockProductRepository;
    protected Mock<IVendorRepository> _mockVendorRepository;
    protected Mock<IUnitTypeRepository> _mockUnitTypeRepository;
    protected Mock<IImageRepository> _mockImageRepository;
    protected Mock<ICategoryRepository> _mockCategoryRepository;
    protected Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    protected Mock<UserManager<User>> _mockUserManager;
    protected ProductService _sut;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        _mockMapper = new Mock<IMapper>();
        _mockProductRepository = new Mock<IProductRepository>();
        _mockVendorRepository = new Mock<IVendorRepository>();
        _mockUnitTypeRepository = new Mock<IUnitTypeRepository>();
        _mockImageRepository = new Mock<IImageRepository>();
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var mockStore = new Mock<IUserStore<User>>();
        _mockUserManager = new Mock<UserManager<User>>(mockStore.Object, null, null, null, null, null, null, null, null);

        _sut = new ProductService(
            _mockMapper.Object,
            _mockProductRepository.Object,
            _mockVendorRepository.Object,
            _mockUnitTypeRepository.Object,
            _mockImageRepository.Object,
            _mockCategoryRepository.Object,
            _mockHttpContextAccessor.Object,
            _mockUserManager.Object);
    }
}