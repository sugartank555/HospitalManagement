namespace HospitalManagement.Models;

public class MedicineOfPrescription
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;

    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = null!;
}
