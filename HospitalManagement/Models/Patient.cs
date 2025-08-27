namespace HospitalManagement.Models;

public class Patient
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    public string? Ethnic { get; set; }
}
