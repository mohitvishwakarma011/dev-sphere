using DS.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DS.Core;

namespace DS.Infrastructure.Repositories
{
    public class AuthRepository(AppDbContext context, IPasswordHasher<User> hasher) : IAuthRepository
    {
        public async Task<string> UserLogin(LoginModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.UserEmail == model.UserEmail);

            if (user == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed) throw new InvalidOperationException("Invalid credentials");

            var token = await this.GenerateJwtTokenAsync(user);
            return token;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            var roles = await context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.Name)
                .ToListAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)

            };

            // add role claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.Jwt.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(720);

            var token = new JwtSecurityToken(
                issuer: AppSetting.Jwt.Issuer,
                audience: AppSetting.Jwt.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
