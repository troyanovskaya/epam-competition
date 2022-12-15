using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.Product;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Product;

public class CreateProductModelBuilder
{
    private readonly Faker<CreateProductModel> _faker;

    public CreateProductModelBuilder()
    {
        _faker = new Faker<CreateProductModel>()
            .CustomInstantiator(_ => new CreateProductModel())
            .RuleFor(p => p.Name, faker => faker.Commerce.ProductName())
            .RuleFor(p => p.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(p => p.Poster, faker => faker.Random.String())
            .RuleFor(p => p.VendorId, faker => Guid.NewGuid())
            .RuleFor(p => p.UnitTypeId, faker => Guid.NewGuid())
            .RuleFor(p => p.Discount, faker => 0.0)
            .RuleFor(p => p.Images, faker => new List<string>())
            .RuleFor(p => p.CategoryIds, faker => new List<Guid>())
            .RuleFor(p => p.Price, faker => faker.Random.Decimal());
    }
    
    public CreateProductModel Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<CreateProductModel> Build(int count)
    {
        return _faker
            .Generate(count);
    } 
}