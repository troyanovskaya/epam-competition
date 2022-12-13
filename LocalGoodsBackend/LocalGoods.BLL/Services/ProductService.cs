using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Image;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using LocalGoods.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LocalGoods.BLL.Exceptions.BadRequestException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitTypeRepository _unitTypeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ProductService(IMapper mapper, IProductRepository productRepository,
            IVendorRepository vendorRepository, IUnitTypeRepository unitTypeRepository,
            IImageRepository imageRepository, ICategoryRepository categoryRepository,
            IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _vendorRepository = vendorRepository;
            _unitTypeRepository = unitTypeRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ProductModel>> GetAllByFilterAsync(ProductFilterModel productFilterModel)
        {
            var products = await _productRepository.GetByFilterAsync(productFilterModel);

            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<IEnumerable<ProductModel>> GetByVendorIdAsync(Guid vendorId)
        {
            var products = await _productRepository.GetByFilterAsync(p => p.VendorId == vendorId);

            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> CreateAsync(CreateProductModel createProductModel)
        {
            await ValidateModel(createProductModel);

            var product = _mapper.Map<Product>(createProductModel);
            await _productRepository.AddAsync(product);
            
            await AddProductImages(product, createProductModel.Images);
            await AddProductCategories(product, createProductModel.CategoryIds);

            await _productRepository.SaveChangesAsync();
            return _mapper.Map<ProductModel>(product);
        }

        private async Task ValidateModel(CreateProductModel createProductModel)
        {
            if (!await _vendorRepository.CheckIfEntityExistsByIdAsync(createProductModel.VendorId))
            {
                throw new VendorNotFoundException(createProductModel.VendorId);
            }

            if (!await _unitTypeRepository.CheckIfEntityExistsByIdAsync(createProductModel.UnitTypeId))
            {
                throw new UnitTypeNotFoundException(createProductModel.UnitTypeId);
            }
        }
        
        public async Task<ProductModel> EditProductAsync(EditProductModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);

            if (product == null)
            {
                throw new ProductNotFoundException(model.Id);
            }
            
            var currentUserId = await GetCurrentUserIdAsync();
            
            if (currentUserId != product.VendorId)
            {
                throw new AuthException("This is not your product, you can not edit it");
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Poster = model.Poster;
            product.Discount = model.Discount;
            product.Amount = model.Amount;

            var unitType = await _unitTypeRepository.GetByIdAsync(model.UnitTypeId);

            if (unitType == null)
            {
                throw new UnitTypeNotFoundException(model.UnitTypeId);
            }

            product.UnitTypeId = model.UnitTypeId;
            product.Categories.Clear();

            await AddProductCategories(product, model.CategoryIds);
            await AddProductImages(product, model.ImageIds);

            return _mapper.Map<ProductModel>(product);
        }

        private async Task AddProductImages(
            Product product,
            IEnumerable<string> images)
        {
            foreach (var imageLink in images)
            {
                var createImageModel = new CreateImageModel() { Link = imageLink, ProductId = product.Id };
                var image = _mapper.Map<Image>(createImageModel);
                
                await _imageRepository.AddAsync(image);
                product.Images.Add(image);
            }
        }

        private async Task AddProductCategories(Product product, IEnumerable<Guid> categoryIds)
        {
            product.Categories = new List<Category>();
            var categoryIdList = categoryIds.ToList();

            var categories = (await _categoryRepository.GetAllByIds(categoryIdList)).ToList();

            if (categories.Count() != categoryIdList.Count)
            {
                throw new CategoryNotFoundException();
            }

            product.Categories = categories;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            
            var currentUserId = await GetCurrentUserIdAsync();
            
            if (currentUserId != product.VendorId)
            {
                throw new AuthException("This is not your product, you can not delete it");
            }

            await _productRepository.DeleteByIdAsync(id);
            await _productRepository.SaveChangesAsync();
        }
        
        private async Task<Guid> GetCurrentUserIdAsync()
        {
            var currentUserId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser is null)
            {
                throw new UserNotFoundException();
            }

            return Guid.Parse(currentUserId);
        }
    }
}
