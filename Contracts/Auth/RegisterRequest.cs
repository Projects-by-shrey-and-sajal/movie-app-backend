using System.ComponentModel.DataAnnotations;
namespace MovieBooking.API.Contracts.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }=string.Empty;

        [Required]
        public string Password { get; set; }=string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }=string.Empty;
    }
}