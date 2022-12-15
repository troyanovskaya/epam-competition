using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.City;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.City;

public class CityModelBuilder
{
    private readonly Faker<CityModel> _faker;

    public CityModelBuilder()
    {
        _faker = new Faker<CityModel>()
            .CustomInstantiator(_ => new CityModel())
            .RuleFor(c => c.Id, faker => Guid.NewGuid())
            .RuleFor(c => c.Name, faker => faker.Commerce.ProductName())
            .RuleFor(c => c.CountryId, faker => Guid.NewGuid());
    }

    public CityModel Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<CityModel> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}