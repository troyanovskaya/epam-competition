using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using LocalGoods.DAL.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LocalGoods.BLL.Interfaces
{
    public interface IJwtHandler
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(User user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
    }
}