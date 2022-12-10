using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorDeliveryMethodRepository _vendorDeliveryMethodRepository;
        private readonly IVendorPaymentMethodRepository _vendorPaymentMethodRepository;
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string VendorRole = "Vendor";

        public VendorService(IMapper mapper, IVendorRepository vendorRepository,
            IVendorDeliveryMethodRepository vendorDeliveryMethodRepository,
            IVendorPaymentMethodRepository vendorPaymentMethodRepository,
            IDeliveryMethodRepository deliveryMethodRepository,
            IPaymentMethodRepository paymentMethodRepository,
            UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
            _vendorDeliveryMethodRepository = vendorDeliveryMethodRepository;
            _vendorPaymentMethodRepository = vendorPaymentMethodRepository;
            _deliveryMethodRepository = deliveryMethodRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<VendorModel>> GetAllByFilterAsync(VendorFilterModel vendorFilterModel)
        {
            var vendors = await _vendorRepository.GetByFilterAsync(vendorFilterModel);

            return _mapper.Map<IEnumerable<VendorModel>>(vendors);
        }

        public async Task<VendorModel> GetByIdAsync(Guid id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            if (vendor is null)
            {
                throw new VendorNotFoundException(id);
            }

            return _mapper.Map<VendorModel>(vendor);
        }

        public async Task<VendorModel> CreateAsync(CreateVendorModel createVendorModel)
        {
            var currentUser = await GetCurrentUser();

            var vendor = _mapper.Map<Vendor>(createVendorModel);
            vendor.UserId = currentUser.Id;

            await _vendorRepository.AddAsync(vendor);
            await InsertDeliveryMethodsAsync(vendor.Id, createVendorModel.DeliveryMethods);
            await InsertPaymentMethodsAsync(vendor.Id, createVendorModel.PaymentMethods);

            await _userManager.AddToRoleAsync(currentUser, VendorRole);
            await _vendorRepository.SaveChangesAsync();

            return _mapper.Map<VendorModel>(vendor);
         }

        private async Task<User> GetCurrentUser()
        {
            var currentUserId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser is null)
            {
                throw new UserNotFoundException();
            }

            return currentUser;
        }

        private async Task InsertDeliveryMethodsAsync(Guid vendorId, IEnumerable<DeliveryInformationModel> deliveryMethods)
        {
            var nonExistentIds = _deliveryMethodRepository
                .GetExceptIdsAsync(deliveryMethods.Select(dm => dm.DeliveryMethodId)).ToList();

            if (nonExistentIds.Any())
            {
                throw new DeliveryMethodNotFoundException(nonExistentIds.FirstOrDefault());
            }

            var vendorDeliveryMethods = _mapper.Map<IEnumerable<VendorDeliveryMethod>>(deliveryMethods).ToList();
            vendorDeliveryMethods.ForEach(vdm => vdm.VendorId = vendorId);
            
            await _vendorDeliveryMethodRepository.AddRangeAsync(vendorDeliveryMethods);
        }

        private async Task InsertPaymentMethodsAsync(Guid vendorId, IEnumerable<PaymentInformationModel> paymentMethods)
        {
            var nonExistentIds = _paymentMethodRepository
                .GetExceptIdsAsync(paymentMethods.Select(pm => pm.PaymentMethodId)).ToList();

            if (nonExistentIds.Any())
            {
                throw new PaymentMethodNotFoundException(nonExistentIds.FirstOrDefault());
            }

            var vendorPaymentMethods = _mapper.Map<IEnumerable<VendorPaymentMethod>>(paymentMethods).ToList();
            vendorPaymentMethods.ForEach(vpm => vpm.VendorId = vendorId);
            
            await _vendorPaymentMethodRepository.AddRangeAsync(vendorPaymentMethods);
        }
    }
}
