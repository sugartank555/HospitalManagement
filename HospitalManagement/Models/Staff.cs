namespace HospitalManagement.Models;

public class Staff
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    public int? PositionId { get; set; }
    public Position? Position { get; set; }

    public int? ExpertiseId { get; set; }
    public Expertise? Expertise { get; set; }
}
