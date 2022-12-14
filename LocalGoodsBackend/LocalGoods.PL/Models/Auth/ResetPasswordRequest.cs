namespace LocalGoods.PL.Models.Auth
{
    public class ResetPasswordRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}