using System;

namespace LocalGoods.BLL.Models.Auth.JWT
{
    public class JwtResponse
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}