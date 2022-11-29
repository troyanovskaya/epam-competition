using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LocalGoods.BLL.Interfaces;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LocalGoods.BLL.Services
{
    public class JwtHandler: IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        
        public JwtHandler(
            IOptions<JwtSettings> jwtSettings,
            UserManager<User> userManager)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
        }
        
        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaimsAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }
        
        public JwtSecurityToken GenerateToken(SigningCredentials signingCredentials,
            IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials);

            return token;
        }
    }
}