using LocalGoods.BLL.Models.DeliveryMethod;
using LocalGoods.BLL.Models.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocalGoods.BLL.Models.Vendor
{
    public class CreateVendorModel
    {
        public string Name { get; set; }
        public string ViberNumber { get; set; }
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public IEnumerable<PaymentInformationModel> PaymentMethods { get; set; }
        public IEnumerable<DeliveryInformationModel> DeliveryMethods { get; set; }
    }
}