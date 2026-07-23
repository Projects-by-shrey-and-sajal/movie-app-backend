using MovieBooking.API.Contracts.Auth;
using MovieBooking.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MovieBooking.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (result.Succeeded)
            {
                return Ok(result.RegisterResponse);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}