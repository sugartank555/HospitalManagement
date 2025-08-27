namespace HospitalManagement.Models;

public enum AppointmentStatus { Pending = 0, Approved = 1, Done = 2, Cancelled = 3 }

public class AppointmentSchedule
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string TimeFrame { get; set; } = "";
    public AppointmentStatus Status { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
}
