namespace HospitalManagement.Models;

public class MedicalRecordInformation
{
    public int Id { get; set; }
    public float? BloodPressure { get; set; }
    public float? BodyTemperature { get; set; }
    public float? HeartBeat { get; set; }
    public float? Height { get; set; }
    public float? Weight { get; set; }
    public string? Detail { get; set; }
    public string? Solution { get; set; }

    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; } = null!;
}
