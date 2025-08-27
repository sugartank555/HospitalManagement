namespace HospitalManagement.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public int? MedicalDepartmentId { get; set; }
    public MedicalDepartment? MedicalDepartment { get; set; }
}
