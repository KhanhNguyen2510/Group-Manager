using GM.Data.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GM.API.Services;

    public interface IJwtService
{
    string GenerateJwtToken(IEnumerable<Claim> claims, int expiresIn);
    string GenerateRefreshToken(int count = 64);
    public int? ValidateToken(string token);
}

public class JwtService : IJwtService
{
    private readonly string _issuer;
    private readonly string _secret;

    public JwtService()
    {
        _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? string.Empty;
        _secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? string.Empty;
    }

    public string GenerateJwtToken(IEnumerable<Claim> claims, int expiresIn)
    {
        var key = Encoding.ASCII.GetBytes(_secret);
        SymmetricSecurityKey securityKey = new(key);
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
        JwtHeader header = new(signingCredentials);
        var nowSeconds = TimeHelper.NowSeconds();
        JwtPayload payload = new()
            {
                {JwtRegisteredClaimNames.Iss, _issuer},
                {JwtRegisteredClaimNames.Aud, _issuer},
                {JwtRegisteredClaimNames.Iat, nowSeconds},
                {JwtRegisteredClaimNames.Exp, nowSeconds + expiresIn}
            };
        payload.AddClaims(claims);
        JwtSecurityToken token = new(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken(int count = 64)
    {
        var bytes = RandomNumberGenerator.GetBytes(count);
        return Convert.ToBase64String(bytes);
    }

    public int? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = _issuer,
                ValidateIssuer = true,
                ValidAudience = _issuer,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return userId;
        }
        catch
        {
            return null;
        }
    }
}

