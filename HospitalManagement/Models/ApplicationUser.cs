using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = "";
    public string? Address { get; set; }
    public DateOnly? DateOfBirth { get; set; }
}
