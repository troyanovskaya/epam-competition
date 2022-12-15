using System;
using System.Collections.Generic;
using Bogus;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Product;

public class ProductBuilder
{
    private readonly Faker<DAL.Entities.Product> _faker;

    public ProductBuilder()
    {
        _faker = new Faker<DAL.Entities.Product>()
            .CustomInstantiator(_ => new DAL.Entities.Product())
            .RuleFor(p => p.Id, faker => Guid.NewGuid())
            .RuleFor(p => p.Name, faker => faker.Commerce.ProductName())
            .RuleFor(p => p.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(p => p.Poster, faker => faker.Random.String())
            .RuleFor(p => p.VendorId, faker => Guid.NewGuid())
            .RuleFor(p => p.Price, faker => faker.Random.Decimal());
    }
    
    public DAL.Entities.Product Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<DAL.Entities.Product> Build(int count)
    {
        return _faker
            .Generate(count);
    } 
}