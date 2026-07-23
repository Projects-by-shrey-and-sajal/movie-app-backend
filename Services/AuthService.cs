using MovieBooking.API.Models;
using Microsoft.AspNetCore.Identity;
using MovieBooking.API.Services.Interfaces;
using MovieBooking.API.Contracts.Auth;
namespace MovieBooking.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new RegisterResult
                {
                    Succeeded = false,
                    EmailAlreadyExists = true,
                    Errors = new List<string> { "Email already exists." }
                };
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new RegisterResult
                {
                    Succeeded = true,
                    RegisterResponse = new RegisterResponse
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        FullName = user.FullName
                    }
                };
            }
            else
            {
                return new RegisterResult
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
        }
    }
}