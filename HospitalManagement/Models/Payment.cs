namespace HospitalManagement.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = "Cash";
    public PaymentStatus Status { get; set; } = PaymentStatus.Unpaid;
    public DateTime? PaidAt { get; set; }

    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; } = null!;
}
