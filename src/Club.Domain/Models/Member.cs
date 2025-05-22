using System.ComponentModel.DataAnnotations;

namespace Club.Domain.Models;

public class Member
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [MaxLength(100)]
    public string Email { get; set; }
    // [Phone(ErrorMessage = "Invalid phone number format")]
    // public string Phone { get; set; } = string.Empty;
}
