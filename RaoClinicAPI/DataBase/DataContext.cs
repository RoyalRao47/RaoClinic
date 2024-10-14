using Microsoft.EntityFrameworkCore;
using RaoClinicAPI.DbTable;

namespace RaoClinicAPI.Database
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
     : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorDocument> DoctorDocuments { get; set; }
        public DbSet<DoctorRating> DoctorRatings { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.13;Database=RaoClinicDB;User=usr_journeycrm;Password=usr_journeycrm#123;TrustServerCertificate=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
                        {
                            entity.ToTable("User");
                            entity.HasKey(e => e.UserID)
                                  .HasName("PK_User")
                                  .IsClustered(false);
                            entity.Property(e => e.UserID)
                                  .ValueGeneratedOnAdd(); // Identity column configuration
                        });

            modelBuilder.Entity<User>()
                .HasOne(u => u.DoctorProfile)
                .WithOne(d => d.User)
                .HasForeignKey<DoctorProfile>(d => d.DoctorID);

            modelBuilder.Entity<User>()
                .HasOne(u => u.PatientProfile)
                .WithOne(p => p.User)
                .HasForeignKey<PatientProfile>(p => p.PatientID);

            modelBuilder.Entity<DoctorProfile>()
                .HasMany(d => d.DoctorDocuments)
                .WithOne(doc => doc.DoctorProfile)
                .HasForeignKey(doc => doc.DoctorID);

            modelBuilder.Entity<DoctorProfile>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.DoctorProfile)
                .HasForeignKey(a => a.DoctorID);

            modelBuilder.Entity<PatientProfile>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.PatientProfile)
                .HasForeignKey(a => a.PatientID);

            modelBuilder.Entity<DoctorProfile>()
                .HasMany(d => d.DoctorRatings)
                .WithOne(r => r.DoctorProfile)
                .HasForeignKey(r => r.DoctorID);

            modelBuilder.Entity<DoctorProfile>()
                .HasMany(d => d.DoctorAvailabilities)
                .WithOne(a => a.DoctorProfile)
                .HasForeignKey(a => a.DoctorID);

            modelBuilder.Entity<Appointment>(entity =>
                   {
                       entity.ToTable("Appointment");
                       entity.HasKey(e => e.AppointmentID)
                             .HasName("PK_Appointment")
                             .IsClustered(false);
                       entity.Property(e => e.AppointmentID)
                             .ValueGeneratedOnAdd(); // Identity column configuration
                   });

            modelBuilder.Entity<DoctorRating>(entity =>
           {
               entity.ToTable("DoctorRating");
               entity.HasKey(e => e.RatingID)
                     .HasName("PK_DoctorRating")
                     .IsClustered(false);
               entity.Property(e => e.RatingID)
                     .ValueGeneratedOnAdd(); // Identity column configuration
           });
            modelBuilder.Entity<DoctorAvailability>(entity =>
          {
              entity.ToTable("DoctorAvailability");
              entity.HasKey(e => e.AvailabilityID)
                    .HasName("PK_DoctorAvailability")
                    .IsClustered(false);
              entity.Property(e => e.AvailabilityID)
                    .ValueGeneratedOnAdd(); // Identity column configuration
          });

            modelBuilder.Entity<OTP>(entity =>
                                   {
                                       entity.ToTable("OTP");
                                       entity.HasKey(e => e.OTPID)
                                             .HasName("PK_OTP")
                                             .IsClustered(false);
                                       entity.Property(e => e.OTPID)
                                             .ValueGeneratedOnAdd(); // Identity column configuration
                                   });

                                    modelBuilder.Entity<DoctorDocument>(entity =>
                                   {
                                       entity.ToTable("DoctorDocument");
                                       entity.HasKey(e => e.DocumentID)
                                             .HasName("PK_DoctorDocument")
                                             .IsClustered(false);
                                       entity.Property(e => e.DocumentID)
                                             .ValueGeneratedOnAdd(); // Identity column configuration
                                   });


 modelBuilder.Entity<DoctorProfile>(entity =>
                                   {
                                       entity.ToTable("DoctorProfile");
                                       entity.HasKey(e => e.DoctorProfileID)
                                             .HasName("PK_DoctorProfile")
                                             .IsClustered(false);
                                       entity.Property(e => e.DoctorProfileID)
                                             .ValueGeneratedOnAdd(); // Identity column configuration
                                   });

 modelBuilder.Entity<PatientProfile>(entity =>
                                   {
                                       entity.ToTable("PatientProfile");
                                       entity.HasKey(e => e.PatientProfileID)
                                             .HasName("PK_PatientProfile")
                                             .IsClustered(false);
                                       entity.Property(e => e.PatientProfileID)
                                             .ValueGeneratedOnAdd(); // Identity column configuration
                                   });

                                   modelBuilder.Entity<DoctorRating>()
    .HasOne(dr => dr.Patient)
    .WithMany(p => p.Ratings)
    .HasForeignKey(dr => dr.PatientID)
    .OnDelete(DeleteBehavior.NoAction);
    
    modelBuilder.Entity<Appointment>()
    .HasOne(a => a.PatientProfile)
    .WithMany(p => p.Appointments)
    .HasForeignKey(a => a.PatientID)
    .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete on PatientID


        }

    }

}
