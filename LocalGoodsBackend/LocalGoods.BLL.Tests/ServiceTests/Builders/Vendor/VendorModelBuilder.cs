using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.Vendor;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;

public class VendorModelBuilder
{
    private readonly Faker<VendorModel> _faker;

    public VendorModelBuilder()
    {
        _faker = new Faker<VendorModel>()
            .CustomInstantiator(_ => new VendorModel())
            .RuleFor(v => v.Name, faker => faker.Commerce.ProductName())
            .RuleFor(v => v.ViberNumber, faker => faker.Phone.PhoneNumber())
            .RuleFor(v => v.UserId, faker => Guid.NewGuid());
    }

    public VendorModel Build()
    {
        return _faker
            .Generate();
    }
    
    public IEnumerable<VendorModel> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}