using AutoMapper;
using LocalGoods.BLL.Services;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace LocalGoods.BLL.Tests.ServiceTests.VendorServiceTests;

public class VendorServiceBaseSetup
{
    protected Mock<IMapper> _mockMapper;
    protected Mock<IVendorRepository> _mockVendorRepository;
    protected Mock<IVendorDeliveryMethodRepository> _mockVendorDeliveryMethodRepository;
    protected Mock<IVendorPaymentMethodRepository> _mockVendorPaymentMethodRepository;
    protected Mock<IDeliveryMethodRepository> _mockDeliveryMethodRepository;
    protected Mock<IPaymentMethodRepository> _mockPaymentMethodRepository;
    protected Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    protected Mock<UserManager<User>> _mockUserManager;
    protected VendorService _sut;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        _mockMapper = new Mock<IMapper>();
        _mockVendorRepository = new Mock<IVendorRepository>();
        _mockVendorDeliveryMethodRepository = new Mock<IVendorDeliveryMethodRepository>();
        _mockVendorPaymentMethodRepository = new Mock<IVendorPaymentMethodRepository>();
        _mockDeliveryMethodRepository = new Mock<IDeliveryMethodRepository>();
        _mockPaymentMethodRepository = new Mock<IPaymentMethodRepository>();
        _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        var mockStore = new Mock<IUserStore<User>>();
        _mockUserManager = new Mock<UserManager<User>>(mockStore.Object, null, null, null, null, null, null, null, null);

        _sut = new VendorService(_mockMapper.Object,
            _mockVendorRepository.Object,
            _mockVendorDeliveryMethodRepository.Object,
            _mockVendorPaymentMethodRepository.Object,
            _mockDeliveryMethodRepository.Object,
            _mockPaymentMethodRepository.Object,
            _mockUserManager.Object,
            _mockHttpContextAccessor.Object);
    }
}