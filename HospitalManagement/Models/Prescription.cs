namespace HospitalManagement.Models;

public class Prescription
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; } = null!;

    public ICollection<MedicineOfPrescription> Medicines { get; set; } = new List<MedicineOfPrescription>();
}
