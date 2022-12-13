using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Repositories.Interfaces;

namespace LocalGoods.BLL.Services
{
    public class DeliveryMethodService: IDeliveryMethodService
    {
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;
        private readonly IMapper _mapper;

        public DeliveryMethodService(
            IDeliveryMethodRepository deliveryMethodRepository, 
            IMapper mapper)
        {
            _deliveryMethodRepository = deliveryMethodRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryMethodModel>> GetAllDeliveryMethodsAsync()
        {
            var deliveryMethods = await _deliveryMethodRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryMethodModel>>(deliveryMethods);
        }

        public async Task<DeliveryMethodModel> GetDeliveryMethodByIdAsync(Guid id)
        {
            var deliveryMethod = await _deliveryMethodRepository.GetByIdAsync(id);

            if (deliveryMethod is null)
            {
                throw new DeliveryMethodNotFoundException(id);
            }

            return _mapper.Map<DeliveryMethodModel>(deliveryMethod);
        }
    }
}