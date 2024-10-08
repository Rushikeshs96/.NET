﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DOTNET_JWT.Services
{
    public class JwtService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;

        public JwtService(string issuer, string audience, string secretKey)
        {
            _issuer = issuer;
            _audience = audience;
            _secretKey = secretKey;
        }

        public string GenerateToken(string userId, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new[] { new Claim(ClaimTypes.NameIdentifier, userId), new Claim(ClaimTypes.Role, role) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}