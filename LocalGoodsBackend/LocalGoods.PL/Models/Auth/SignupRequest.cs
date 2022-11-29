using System;

namespace LocalGoods.PL.Models.Auth
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Guid CityId { get; set; }
    }
}