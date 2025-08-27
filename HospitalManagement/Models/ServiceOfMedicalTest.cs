namespace HospitalManagement.Models;

public class ServiceOfMedicalTest
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    public int MedicalTestId { get; set; }
    public MedicalTest MedicalTest { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
