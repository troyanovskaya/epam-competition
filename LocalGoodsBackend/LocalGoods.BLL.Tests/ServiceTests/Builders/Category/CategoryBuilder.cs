using System;
using System.Collections.Generic;
using Bogus;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Category;

public class CategoryBuilder
{
    private readonly Faker<DAL.Entities.Category> _faker;

    public CategoryBuilder()
    {
        _faker = new Faker<DAL.Entities.Category>()
            .CustomInstantiator(_ => new DAL.Entities.Category())
            .RuleFor(c => c.Id, faker => Guid.NewGuid())
            .RuleFor(c => c.Name, faker => faker.Commerce.ProductName());
    }
    
    public DAL.Entities.Category Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<DAL.Entities.Category> Build(int count)
    {
        return _faker
            .Generate(count);
    } 
}