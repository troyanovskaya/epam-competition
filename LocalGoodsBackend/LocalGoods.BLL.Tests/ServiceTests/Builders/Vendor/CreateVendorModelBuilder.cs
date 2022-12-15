using System;
using System.Collections.Generic;
using Bogus;
using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.PaymentMethod;
using LocalGoods.BLL.Models.Vendor;

namespace LocalGoods.BLL.Tests.ServiceTests.Builders.Vendor;

public class CreateVendorModelBuilder
{
    private readonly Faker<CreateVendorModel> _faker;

    public CreateVendorModelBuilder()
    {
        _faker = new Faker<CreateVendorModel>()
            .CustomInstantiator(_ => new CreateVendorModel())
            .RuleFor(v => v.Name, faker => faker.Commerce.ProductName())
            .RuleFor(v => v.ViberNumber, faker => faker.Phone.PhoneNumber())
            .RuleFor(v => v.UserId, faker => Guid.NewGuid())
            .RuleFor(v => v.DeliveryMethods, faker => new List<DeliveryInformationModel>())
            .RuleFor(v => v.PaymentMethods, faker => new List<PaymentInformationModel>());
    }

    public CreateVendorModel Build()
    {
        return _faker
            .Generate();
    }
    
    public IEnumerable<CreateVendorModel> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}