using System;

namespace LocalGoods.BLL.Models.User
{
    public class UserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CityId { get; set; }
    }
}