using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Repositories.Interfaces;

namespace LocalGoods.BLL.Services
{
    public class PaymentMethodService: IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        
        public PaymentMethodService(
            IPaymentMethodRepository paymentMethodRepository, 
            IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentMethodModel>> GetAllPaymentMethodsAsync()
        {
            var paymentMethods = await _paymentMethodRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentMethodModel>>(paymentMethods);
        }

        public async Task<PaymentMethodModel> GetPaymentMethodByIdAsync(Guid id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentMethodModel>(paymentMethod);
        }
    }
}