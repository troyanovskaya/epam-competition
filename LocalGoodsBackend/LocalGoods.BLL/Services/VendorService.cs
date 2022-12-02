using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorDeliveryMethodRepository _vendorDeliveryMethodRepository;
        private readonly IVendorPaymentMethodRepository _vendorPaymentMethodRepository;
        private readonly UserManager<User> _userManager;

        public VendorService(IMapper mapper, IVendorRepository vendorRepository,
            IVendorDeliveryMethodRepository vendorDeliveryMethodRepository,
            IVendorPaymentMethodRepository vendorPaymentMethodRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _vendorRepository = vendorRepository;
            _vendorDeliveryMethodRepository = vendorDeliveryMethodRepository;
            _vendorPaymentMethodRepository = vendorPaymentMethodRepository;
            _userManager = userManager;
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
            if (await _userManager.FindByIdAsync(createVendorModel.UserId.ToString()) is null)
            {
                throw new UserNotFoundException(createVendorModel.UserId);
            }

            var vendor = _mapper.Map<Vendor>(createVendorModel);

            await _vendorRepository.AddAsync(vendor);
            await InsertDeliveryMethodsAsync(vendor.Id, createVendorModel.DeliveryMethods);
            await InsertPaymentMethodsAsync(vendor.Id, createVendorModel.PaymentMethods);

            await _vendorRepository.SaveChangesAsync();

            return _mapper.Map<VendorModel>(vendor);
        }

        private async Task InsertDeliveryMethodsAsync(Guid vendorId, IEnumerable<DeliveryInformationModel> deliveryMethods)
        {
            foreach (var deliveryMethod in deliveryMethods)
            {
                if (await _vendorDeliveryMethodRepository.CheckIfEntityExistsByIdAsync(deliveryMethod.DeliveryMethodId))
                {
                    throw new DeliveryMethodNotFoundException(deliveryMethod.DeliveryMethodId);
                }

                var vendorDeliveryMethod = _mapper.Map<VendorDeliveryMethod>(deliveryMethod);
                vendorDeliveryMethod.VendorId = vendorId;

                await _vendorDeliveryMethodRepository.AddAsync(vendorDeliveryMethod);
            }
        }

        private async Task InsertPaymentMethodsAsync(Guid vendorId, IEnumerable<PaymentInformationModel> paymentMethods)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                if (await _vendorPaymentMethodRepository.CheckIfEntityExistsByIdAsync(paymentMethod.PaymentMethodId))
                {
                    throw new PaymentMethodNotFoundException(paymentMethod.PaymentMethodId);
                }

                var vendorPaymentMethod = _mapper.Map<VendorPaymentMethod>(paymentMethod);
                vendorPaymentMethod.VendorId = vendorId;

                await _vendorPaymentMethodRepository.AddAsync(vendorPaymentMethod);
            }
        }
    }
}
