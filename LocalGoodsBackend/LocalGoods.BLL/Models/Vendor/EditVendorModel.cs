using System;
using System.Collections.Generic;

namespace LocalGoods.BLL.Models.Vendor
{
    public class EditVendorModel
    {
        public string ViberNumber { get; set; }
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }

        public IEnumerable<Guid> PaymentMethods { get; set; }
        public IEnumerable<Guid> DeliveryMethods { get; set; }
    }
}