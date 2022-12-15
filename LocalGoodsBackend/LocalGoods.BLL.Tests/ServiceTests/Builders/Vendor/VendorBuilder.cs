using System;
using System.Collections.Generic;
using Bogus;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;

public class VendorBuilder
{
    private readonly Faker<DAL.Entities.Vendor> _faker;

    public VendorBuilder()
    {
        _faker = new Faker<DAL.Entities.Vendor>()
            .CustomInstantiator(_ => new DAL.Entities.Vendor())
            .RuleFor(v => v.Name, faker => faker.Commerce.ProductName())
            .RuleFor(v => v.ViberNumber, faker => faker.Phone.PhoneNumber())
            .RuleFor(v => v.UserId, faker => Guid.NewGuid());
    }

    public DAL.Entities.Vendor Build()
    {
        return _faker
            .Generate();
    }
    
    public IEnumerable<DAL.Entities.Vendor> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}