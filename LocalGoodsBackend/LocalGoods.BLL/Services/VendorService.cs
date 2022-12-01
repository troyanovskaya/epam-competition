using AutoMapper;
using LocalGoods.BLL.Exceptions;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.Filters;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task CreateAsync(CreateVendorModel createVendorModel)
        {
            if (await _userManager.FindByIdAsync(createVendorModel.UserId.ToString()) is null)
            {
                throw new NotFoundException("The user with the specified id doesn't exist");
            }

            var vendor = _mapper.Map<Vendor>(createVendorModel);

            await _vendorRepository.AddAsync(vendor);
            await InsertDeliveryMethodsAsync(vendor.Id, createVendorModel.DeliveryMethods);
            await InsertPaymentMethodsAsync(vendor.Id, createVendorModel.PaymentMethods);

            await _vendorRepository.SaveChangesAsync();
        }

        // TODO: Fix incorrect applying filters
        public async Task<IEnumerable<VendorModel>> GetAllByFilterAsync(VendorFilterModel vendorFilterModel)
        {
            var vendors = await GetVendorsByFilterAsync(vendorFilterModel);

            return _mapper.Map<IEnumerable<VendorModel>>(vendors);
        }

        public async Task<VendorModel> GetByIdAsync(Guid id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            if (vendor is null)
            {
                throw new NotFoundException("The vendor with the specified id doesn't exist");
            }

            return _mapper.Map<VendorModel>(vendor);
        }

        private async Task InsertDeliveryMethodsAsync(Guid vendorId, IEnumerable<DeliveryInformationModel> deliveryMethods)
        {
            foreach (var deliveryMethod in deliveryMethods)
            {
                if (await _vendorDeliveryMethodRepository.CheckIfEntityExistsByIdAsync(deliveryMethod.DeliveryMethodId))
                {
                    throw new NotFoundException("The delivery method with the specified id doesn't exist");
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
                    throw new NotFoundException("The delivery method with the specified id doesn't exist");
                }

                var vendorPaymentMethod = _mapper.Map<VendorPaymentMethod>(paymentMethod);
                vendorPaymentMethod.VendorId = vendorId;

                await _vendorPaymentMethodRepository.AddAsync(vendorPaymentMethod);
            }
        }

        private async Task<IEnumerable<Vendor>> GetVendorsByFilterAsync(VendorFilterModel vendorFilterModel)
        {
            Expression<Func<Vendor, bool>> filterExpression = v => true;

            if (vendorFilterModel.CityId != null)
            {
                ApplyFilter(filterExpression, v => v.User.CityId == vendorFilterModel.CityId);
            }

            var vendors = await _vendorRepository.GetByFilterAsync(filterExpression);

            return vendors;
        }

        private void ApplyFilter(Expression<Func<Vendor, bool>> expression, Expression<Func<Vendor, bool>> filter)
        {
            var body = Expression.Or(expression.Body, filter.Body);
            expression = Expression.Lambda<Func<Vendor, bool>>(body, expression.Parameters[0]);
        }
    }
}
