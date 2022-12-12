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
using System.Threading.Tasks;

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

        public ProductService(IMapper mapper, IProductRepository productRepository,
            IVendorRepository vendorRepository, IUnitTypeRepository unitTypeRepository,
            IImageRepository imageRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _vendorRepository = vendorRepository;
            _unitTypeRepository = unitTypeRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;
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
            await AddProductImages(product, product.Id, createProductModel.Images);
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

        private async Task AddProductImages(
            Product product, 
            Guid productId, 
            IEnumerable<string> images)
        {
            foreach (var imageLink in images)
            {
                var createImageModel = new CreateImageModel() { Link = imageLink, ProductId = productId };

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
    }
}
