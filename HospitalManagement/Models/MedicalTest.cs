namespace HospitalManagement.Models;

public class MedicalTest
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime? TestTime { get; set; }
    public decimal TotalPrice { get; set; }

    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; } = null!;

    public ICollection<ServiceOfMedicalTest> Services { get; set; } = new List<ServiceOfMedicalTest>();
}
