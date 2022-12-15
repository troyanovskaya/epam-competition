using System;
using System.Collections.Generic;
using Bogus;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Country;

public class CountryBuilder
{
    private readonly Faker<DAL.Entities.Country> _faker;

    public CountryBuilder()
    {
        _faker = new Faker<DAL.Entities.Country>()
            .CustomInstantiator(_ => new DAL.Entities.Country())
            .RuleFor(c => c.Id, faker => Guid.NewGuid())
            .RuleFor(c => c.Name, faker => faker.Commerce.ProductName());
    }

    public DAL.Entities.Country Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<DAL.Entities.Country> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}