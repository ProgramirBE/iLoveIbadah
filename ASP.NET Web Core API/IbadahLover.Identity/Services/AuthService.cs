using IbadahLover.Application.Constants;
using IbadahLover.Application.Contracts.Identity;
using IbadahLover.Application.Models.Identity;
using IbadahLover.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly string _jwtSettingsKey;

        //public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings, SignInManager<ApplicationUser> signInManager)
        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings, string jwtSettingsKey)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _jwtSettingsKey = jwtSettingsKey;
            //_signInManager = signInManager;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var passwordIsValid = await _userManager.CheckPasswordAsync(user, request.PasswordHash);
            //var result = await _signInManager.PasswordSignInAsync(user, request.PasswordHash, isPersistent: true, lockoutOnFailure: false);

            if (!passwordIsValid)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                FullName = user.FullName,
                UniqueId = user.UserName // I changed this from UniqueId to UserName just the name!
            };

            return response;
        }
        private async Task<bool> UniqueIdExists(string uniqueId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == uniqueId);
            return user != null;
        }

        private async Task<string> GenerateUniqueId(string fullName)
        {
            // Sanitize input by removing '@' and other restricted characters
            string sanitizedInput = fullName.Replace("@", "").Trim();

            // Add '@' prefix
            string baseUniqueId = $"@{sanitizedInput}";

            // Check database for conflicts
            Random random = new Random();
            string uniqueId = baseUniqueId;

            for (int i = 0; i < 100; i++) //100 tries to find a unique id
            {
                int suffix = random.Next(1, 10001); // 1 to 10000 for if there are many many users with username Muhammad! the most given name to new borns in the world!
                uniqueId = $"{baseUniqueId}{suffix}";

                if (!await UniqueIdExists(uniqueId))
                {
                    return uniqueId;
                }
            }

            throw new InvalidOperationException("Unable to generate a unique ID after multiple attempts.");
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = await GenerateUniqueId(request.FullName),
                FullName = request.FullName,
                //EmailConfirmed = true // clairement une erreur de trevoir williams...
            };

            if (existingUser == null)
            {
                var result = await _userManager.CreateAsync(user, request.PasswordHash);

                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, "Worshiper"); // J'ai déjà un trigger dans ma base de données qui fait ça!!!
                    return new RegistrationResponse() { Id = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Id.ToString(), user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingsKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddYears(_jwtSettings.DurationInYears),
                claims: claims,
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
