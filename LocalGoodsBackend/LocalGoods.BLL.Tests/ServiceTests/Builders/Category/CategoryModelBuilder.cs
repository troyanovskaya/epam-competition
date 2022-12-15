using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.Category;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Category;

public class CategoryModelBuilder
{
    private readonly Faker<CategoryModel> _faker;

    public CategoryModelBuilder()
    {
        _faker = new Faker<CategoryModel>()
            .CustomInstantiator(_ => new CategoryModel())
            .RuleFor(c => c.Id, faker => Guid.NewGuid())
            .RuleFor(c => c.Name, faker => faker.Commerce.ProductName());
    }
    
    public CategoryModel Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<CategoryModel> Build(int count)
    {
        return _faker
            .Generate(count);
    } 
}