namespace HospitalManagement.Models;

public enum PaymentStatus { Unpaid = 0, Paid = 1, Refunded = 2 }

public class MedicalRecord
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public string? Diagnose { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
    public Payment? Payment { get; set; }

    public ICollection<MedicalRecordInformation> Informations { get; set; } = new List<MedicalRecordInformation>();
    public ICollection<MedicalTest> MedicalTests { get; set; } = new List<MedicalTest>();
    public Prescription? Prescription { get; set; }
}
