using Microsoft.IdentityModel.Tokens;
using Shop.Common.Application_Layer.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.UserService.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;
    private readonly SigningCredentials _signingCredentials;

    public JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider, 
        JwtSettings jwtSettings,
        SigningCredentials signingCredentials)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings;
        _signingCredentials = signingCredentials;
    }

    public string GenerateToken(string id, string email, string firstName)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.GivenName, firstName),
        };

        //var signingCredentials = new SigningCredentials(
        //    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
        //    SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddSeconds(_jwtSettings.Expires),
            claims: claims,
            signingCredentials: _signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
