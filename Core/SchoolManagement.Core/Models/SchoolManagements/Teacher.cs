using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements
{
    public partial class Teacher : BindableBase
    {
        private int teacherId;
        private int departmentId;
        private int userId;
        private string? teacherCode;
        private string? degree;
        private string? expertise;
        private string? university;
        private DateTime? graduationYear;
        private string? major;
        private string? otherCertifications;
        private string? position;
        private decimal? salary;
        private string? additionalBenifits;
        private string? currentHealthStatus;
        private string? healthInsuranceInfo;
        private string? selfIntroduction;
        private int subjectId;
        private bool? isLeader;

        public int TeacherId { get => teacherId; set => SetProperty(ref teacherId, value); }

        public int DepartmentId { get => departmentId; set => SetProperty(ref departmentId, value); }

        public int UserId { get => userId; set => SetProperty(ref userId, value); }

        public string? TeacherCode { get => teacherCode; set => SetProperty(ref teacherCode, value); }

        public string? Degree { get => degree; set => SetProperty(ref degree, value); }

        public string? Expertise { get => expertise; set => SetProperty(ref expertise, value); }

        public string? University { get => university; set => SetProperty(ref university, value); }

        public DateTime? GraduationYear { get => graduationYear; set => SetProperty(ref graduationYear, value); }

        public string? Major { get => major; set => SetProperty(ref major, value); }

        public string? OtherCertifications { get => otherCertifications; set => SetProperty(ref otherCertifications, value); }

        public string? Position { get => position; set => SetProperty(ref position, value); }

        public decimal? Salary { get => salary; set => SetProperty(ref salary, value); }

        public string? AdditionalBenifits { get => additionalBenifits; set => SetProperty(ref additionalBenifits, value); }

        public string? CurrentHealthStatus { get => currentHealthStatus; set => SetProperty(ref currentHealthStatus, value); }

        public string? HealthInsuranceInfo { get => healthInsuranceInfo; set => SetProperty(ref healthInsuranceInfo, value); }

        public string? SelfIntroduction { get => selfIntroduction; set => SetProperty(ref selfIntroduction, value); }

        public int SubjectId { get => subjectId; set => SetProperty(ref subjectId, value); }
        public bool? IsLeader { get => isLeader; set => SetProperty(ref isLeader, value); }

        // Navigation properties
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public virtual Department Department { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}