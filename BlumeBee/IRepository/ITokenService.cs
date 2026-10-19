
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace BlumeBee.IRepository
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string userName, string[] roles);
    }
}
