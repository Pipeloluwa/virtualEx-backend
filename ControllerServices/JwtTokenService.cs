using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using virtual_ex.Models;

namespace virtual_ex.ControllerServices
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(UserModel _user);
        Task<ClaimsPrincipal?> GetJWTPrincipal(string token);
        Task<string> GenerateRefreshToken();


    }
    public class JwtTokenService(UserManager<UserModel> _userManager, IConfiguration _configuration): IJwtTokenService
    {

        private readonly UserManager<UserModel> userManager = _userManager;
        private readonly IConfiguration configuration = _configuration;




        public async Task<string> GenerateToken(UserModel _user)
        {
            var userRoles = await userManager.GetRolesAsync(_user);

            var claims = new List<Claim>
           {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", _user.Id.ToString()),
                new Claim("Email", _user.Email.ToString()),
            };

            //ADDING ROLE CLAIMS
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(40),
                    signingCredentials: signIn
                );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;

        }





        public async Task<ClaimsPrincipal?> GetJWTPrincipal(string token)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var validation = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);

        }




        public async Task<string> GenerateRefreshToken()
        {
            var randomNo = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNo);
            }

            return Convert.ToBase64String(randomNo);

        }


    }
}
