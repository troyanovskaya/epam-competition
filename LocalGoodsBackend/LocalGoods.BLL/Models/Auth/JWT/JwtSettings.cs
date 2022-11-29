namespace LocalGoods.BLL.Models.Auth.JWT
{
    public class JwtSettings: IJwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}