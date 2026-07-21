using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBooking.API.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        [MaxLength(512)]
        public string? PasswordHash { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "Customer";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
