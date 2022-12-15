using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.Product;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Product;

public class ProductModelBuilder
{
    private readonly Faker<ProductModel> _faker;

    public ProductModelBuilder()
    {
        _faker = new Faker<ProductModel>()
            .CustomInstantiator(_ => new ProductModel())
            .RuleFor(p => p.Id, faker => Guid.NewGuid())
            .RuleFor(p => p.Name, faker => faker.Commerce.ProductName())
            .RuleFor(p => p.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(p => p.Poster, faker => faker.Random.String())
            .RuleFor(p => p.VendorId, faker => Guid.NewGuid())
            .RuleFor(p => p.Price, faker => faker.Random.Decimal());
    }
    
    public ProductModel Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<ProductModel> Build(int count)
    {
        return _faker
            .Generate(count);
    } 
}