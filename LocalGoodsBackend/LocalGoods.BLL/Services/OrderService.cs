﻿using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using LocalGoods.DAL.Repositories.Interfaces;
using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using LocalGoods.BLL.Models.OrderDetails;
using LocalGoods.BLL.Exceptions.BadRequestException;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using LocalGoods.Shared;
using LocalGoods.BLL.Models.OrderStatus;

namespace LocalGoods.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IMapper mapper, 
            IOrderRepository orderRepository,
            IOrderDetailsRepository orderDetailsRepository, 
            IProductRepository productRepository,
            IVendorRepository vendorRepository,
            IPaymentMethodRepository paymentMethodRepository, 
            IDeliveryMethodRepository deliveryMethodRepository,
            IOrderStatusRepository orderStatusRepository,
            UserManager<User> userManager, 
            IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _productRepository = productRepository;
            _vendorRepository = vendorRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _deliveryMethodRepository = deliveryMethodRepository;
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<IEnumerable<OrderModel>> GetByUserIdAsync(Guid userId)
        {
            var orders = await _orderRepository.GetByFilterAsync(o => o.UserId == userId);

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<IEnumerable<OrderModel>> GetByVendorIdAsync(Guid vendorId)
        {
            var orders = await _orderRepository.GetByFilterAsync(o => o.OrderDetails.Select(od => od.Product.VendorId).Contains(vendorId));

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task<OrderModel> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order is null)
            {
                throw new OrderNotFoundException(id);
            }

            return _mapper.Map<OrderModel>(order);
        }

        public async Task<IEnumerable<OrderStatusModel>> GetAllOrderStatusesAsync()
        {
            var orderStatuses = await _orderStatusRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderStatusModel>>(orderStatuses);
        }

        public async Task<OrderModel> CreateAsync(CreateOrderModel createOrderModel)
        {
            var currentUserId = await GetCurrentUserId();

            await ValidateOrderAsync(createOrderModel);

            var order = new Order
            {
                UserId = currentUserId,
                PaymentMethodId = createOrderModel.PaymentMethodId,
                DeliveryMethodId = createOrderModel.DeliveryMethodId,
                DeliveryInformation = createOrderModel.DeliveryInformation
            };

            await _orderRepository.AddAsync(order);

            await CreateOrderDetailsAsync(createOrderModel.OrderDetails, currentUserId, order.Id);

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return _mapper.Map<OrderModel>(order);
        }

        public async Task ChangeStatusAsync(Guid orderId, Guid orderStatusId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (orderStatusId == GlobalValues.NewOrderStatusId)
            {
                throw new OrderBadRequestException("Order status can't be changed to New");
            }

            if (order.OrderStatus.Id == GlobalValues.CompletedOrderStatusId)
            {
                throw new OrderBadRequestException("Order status can't be changed from Completed");
            }

            var orderStatus = await _orderStatusRepository.GetByIdAsync(orderStatusId);

            if (orderStatus is null)
            {
                throw new OrderStatusNotFoundException(orderStatusId);
            }

            order.OrderStatus = orderStatus;
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        private async Task<Guid> GetCurrentUserId()
        {
            var currentUserId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser is null)
            {
                throw new UserNotFoundException();
            }

            return Guid.Parse(currentUserId);
        }

        private async Task ValidateOrderAsync(CreateOrderModel createOrderModel)
        {
            if (await _deliveryMethodRepository.GetByIdAsync(createOrderModel.DeliveryMethodId) is null)
            {
                throw new DeliveryMethodNotFoundException(createOrderModel.DeliveryMethodId);
            }

            if (await _paymentMethodRepository.GetByIdAsync(createOrderModel.PaymentMethodId) is null)
            {
                throw new PaymentMethodNotFoundException(createOrderModel.PaymentMethodId);
            }
        }

        private async Task CreateOrderDetailsAsync(
            IEnumerable<CreateOrderDetailsModel> orderDetails, 
            Guid currentUserId,
            Guid orderId)
        {
            var orderDetailsList = _mapper.Map<IEnumerable<OrderDetails>>(orderDetails).ToList();
            
            if (orderDetails is null || !orderDetailsList.Any())
            {
                throw new OrderBadRequestException("Order has no products");
            }

            var productIds = orderDetailsList.Select(od => od.ProductId).ToList();
            var products = (await _productRepository.GetAllByIds(productIds)).ToList();

            if (productIds.Count != products.Count)
            {
                throw new ProductNotFoundException();
            }

            var vendorId = products.First().VendorId;
            var vendor = await _vendorRepository.GetByIdAsync(vendorId);

            if (vendor == null)
            {
                throw new VendorNotFoundException(vendorId);
            }

            if (vendor.User.Id == currentUserId)
            {
                throw new OrderBadRequestException("Vendor can't buy their own products");
            }

            var vendors = products.Select(p => p.VendorId).Distinct();

            if (vendors.Count() > 1)
            {
                throw new OrderBadRequestException("Order has different vendors");
            }
            
            foreach (var currentOrderDetails in orderDetailsList)
            {
                await CheckAndDecreaseProductAmount(currentOrderDetails, currentOrderDetails.Amount, orderId);
            }
        }

        private async Task CheckAndDecreaseProductAmount(
            OrderDetails orderDetails, 
            double amount, 
            Guid orderId)
        {
            var productId = orderDetails.ProductId;
            var currentProduct = await _productRepository.GetByIdAsync(productId);

            if (currentProduct.Amount == 0.0)
            {
                throw new OrderBadRequestException($"Product with id {productId} is out of stock");
            }

            if (currentProduct.Amount - amount < 0.0)
            {
                throw new OrderBadRequestException($"Product with id {productId} doesn't have as many units");
            }
            
            currentProduct.Amount -= amount;
            await _productRepository.UpdateAsync(currentProduct);
            
            orderDetails.OrderId = orderId;
            orderDetails.Price = currentProduct.Price;
            orderDetails.Discount = currentProduct.Discount;
            orderDetails.UnitTypeId = currentProduct.UnitTypeId;
            await _orderDetailsRepository.AddAsync(orderDetails);
        }
    }
}
