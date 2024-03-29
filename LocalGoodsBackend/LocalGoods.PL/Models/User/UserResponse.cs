﻿using System;

namespace LocalGoods.PL.Models.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressInformation { get; set; }
        public Guid CityId { get; set; }
    }
}