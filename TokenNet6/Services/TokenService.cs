using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenNet6.Interfaces;
using TokenNet6.Models;

namespace TokenNet6.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(LoginModel admin)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, admin.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var securityTokens = new JwtSecurityToken(
                                            claims: claims,
                                            expires: DateTime.Now.AddMinutes(60),
                                            signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityTokens);
            return token;
        }
    }
}
