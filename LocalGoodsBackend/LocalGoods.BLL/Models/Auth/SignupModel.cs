using System;

namespace LocalGoods.BLL.Models.Auth
{
    public class SignupModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string AddressInformation { get; set; }
        public Guid CityId { get; set; }
    }
}