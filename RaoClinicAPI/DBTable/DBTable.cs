namespace RaoClinicAPI.DbTable
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public int UserTypeId { get; set; } // 'Doctor' or 'Patient'
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public DoctorProfile DoctorProfile { get; set; }
        public PatientProfile PatientProfile { get; set; }
    }
    public class DoctorProfile
    {
        public int DoctorProfileID { get; set; }
        public int DoctorID { get; set; }
        public int ExperienceYears { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public string RegistrationDetails { get; set; }
        public string Availability { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<DoctorDocument> DoctorDocuments { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorRating> DoctorRatings { get; set; }
        public ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }
    }
    public class DoctorDocument
    {
        public int DocumentID { get; set; }
        public int DoctorID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public DoctorProfile DoctorProfile { get; set; }
    }
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // 'Upcoming', 'Completed', 'Cancelled'
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public PatientProfile PatientProfile { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
    }
    public class PatientProfile
    {
        public int PatientProfileID { get; set; }
        public int PatientID { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorRating> Ratings { get; set; }
    }
    public class DoctorRating
    {
        public int RatingID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public DoctorProfile DoctorProfile { get; set; }
        public PatientProfile Patient { get; set; }
    }
    public class DoctorAvailability
    {
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public string DayOfWeek { get; set; }
        public string TimeSlot { get; set; }

        // Navigation Properties
        public DoctorProfile DoctorProfile { get; set; }
    }
    public class OTP
    {
        public int OTPID { get; set; }
        public int PatientID { get; set; }
        public string OTPCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiresAt { get; set; }
        public bool IsValid { get; set; } = true;

        // Navigation Properties
        public PatientProfile Patient { get; set; }
    }


}