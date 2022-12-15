using System;
using System.Collections.Generic;
using Bogus;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.City;

public class CityBuilder
{
    private readonly Faker<DAL.Entities.City> _faker;

    public CityBuilder()
    {
        _faker = new Faker<DAL.Entities.City>()
            .CustomInstantiator(_ => new DAL.Entities.City())
            .RuleFor(c => c.Id, faker => Guid.NewGuid())
            .RuleFor(c => c.Name, faker => faker.Commerce.ProductName())
            .RuleFor(c => c.CountryId, faker => Guid.NewGuid());
    }

    public DAL.Entities.City Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<DAL.Entities.City> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}