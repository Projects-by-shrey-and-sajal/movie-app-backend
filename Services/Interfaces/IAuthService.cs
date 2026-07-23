using MovieBooking.API.Contracts.Auth;
namespace MovieBooking.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResult> RegisterAsync(RegisterRequest request);
    }
}