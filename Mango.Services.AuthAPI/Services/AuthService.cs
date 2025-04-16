using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                var userToAdd = new ApplicationUser
                {
                    Name = registerRequestDto.Name,
                    Email = registerRequestDto.Email,
                    NormalizedEmail = registerRequestDto.Email.ToUpper(),
                    UserName = registerRequestDto.Username,
                    PhoneNumber = registerRequestDto.Phone,
                };

                var result = await _userManager.CreateAsync(userToAdd, registerRequestDto.Password);

                if (!result.Succeeded)
                {
                    return result.Errors.First().Description;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return string.Empty;
        }
    }
}
