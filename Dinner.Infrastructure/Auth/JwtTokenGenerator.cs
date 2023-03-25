using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dinner.Application.Common.Authentication;
using Dinner.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dinner.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly JwtSetting _JwtSetting;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSetting> jwtSettingOpt)
        {
            _DateTimeProvider = dateTimeProvider;
            _JwtSetting = jwtSettingOpt.Value;
        }

        public string GenerateToken(Guid userId, string FirstName, string LastName)
        {
            var signingCred = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_JwtSetting.Secret)
                ),
                SecurityAlgorithms.HmacSha256
            );
            var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, FirstName + ' '+ LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new Claim("opt ss","opt val")
           };

            var token = new JwtSecurityToken(
                issuer: _JwtSetting.Issuer,
                audience: _JwtSetting.Audience,
                claims: claims,
                expires: _DateTimeProvider.utcNow.AddDays(_JwtSetting.ExpireIn),
                signingCredentials: signingCred);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}