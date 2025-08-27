using HospitalManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Data
{
    // LƯU Ý: dùng ApplicationUser để mở rộng IdentityUser
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSet
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Staff> Staffs => Set<Staff>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Nursing> Nursings => Set<Nursing>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Expertise> Expertises => Set<Expertise>();
        public DbSet<AppointmentSchedule> AppointmentSchedules => Set<AppointmentSchedule>();
        public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
        public DbSet<MedicalRecordInformation> MedicalRecordInformations => Set<MedicalRecordInformation>();
        public DbSet<MedicalTest> MedicalTests => Set<MedicalTest>();
        public DbSet<ServiceOfMedicalTest> ServiceOfMedicalTests => Set<ServiceOfMedicalTest>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<MedicalDepartment> MedicalDepartments => Set<MedicalDepartment>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<MedicineOfPrescription> MedicineOfPrescriptions => Set<MedicineOfPrescription>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            // === Kế thừa TPT cho Staff ===
            b.Entity<Staff>().ToTable("Staffs");
            b.Entity<Doctor>().ToTable("Doctors");
            b.Entity<Nursing>().ToTable("Nursings");

            // === Mapping tiền tệ ===
            b.Entity<Service>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            b.Entity<MedicalTest>().Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
            b.Entity<Medicine>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            b.Entity<Payment>().Property(x => x.Amount).HasColumnType("decimal(18,2)");

            // === Tránh multiple cascade paths: KHÔNG cascade lên Patient/Doctor/User ===
            b.Entity<AppointmentSchedule>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            b.Entity<AppointmentSchedule>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            b.Entity<MedicalRecord>()
                .HasOne(m => m.Doctor)
                .WithMany()
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            b.Entity<MedicalRecord>()
                .HasOne(m => m.Patient)
                .WithMany()
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            b.Entity<Staff>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            b.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // === Cascade trong nội bộ hồ sơ khám ===
            b.Entity<MedicalRecordInformation>()
                .HasOne(i => i.MedicalRecord)
                .WithMany(m => m.Informations)
                .HasForeignKey(i => i.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<MedicalTest>()
                .HasOne(t => t.MedicalRecord)
                .WithMany(m => m.MedicalTests)
                .HasForeignKey(t => t.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<ServiceOfMedicalTest>()
                .HasOne(smt => smt.MedicalTest)
                .WithMany(t => t.Services)
                .HasForeignKey(smt => smt.MedicalTestId)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<ServiceOfMedicalTest>()
                .HasOne(smt => smt.Service)
                .WithMany()
                .HasForeignKey(smt => smt.ServiceId)
                .OnDelete(DeleteBehavior.NoAction); // không cần cascade ngược về Service

            b.Entity<Prescription>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(m => m.Prescription!)
                .HasForeignKey<Prescription>(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<MedicineOfPrescription>()
                .HasOne(mp => mp.Prescription)
                .WithMany(p => p.Medicines)
                .HasForeignKey(mp => mp.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<MedicineOfPrescription>()
                .HasOne(mp => mp.Medicine)
                .WithMany()
                .HasForeignKey(mp => mp.MedicineId)
                .OnDelete(DeleteBehavior.NoAction); // không cascade ngược về kho thuốc

            b.Entity<Payment>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(m => m.Payment!)
                .HasForeignKey<Payment>(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Unique index chống trùng lịch 1 bác sĩ trong 1 khung giờ ===
            b.Entity<AppointmentSchedule>()
                .HasIndex(a => new { a.Date, a.TimeFrame, a.DoctorId })
                .IsUnique();
        }
    }
}
