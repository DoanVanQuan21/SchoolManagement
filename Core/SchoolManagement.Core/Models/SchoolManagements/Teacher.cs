using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public int TeacherId { get => teacherId; set => SetProperty(ref teacherId, value); }

        [Browsable(false)]
        public int DepartmentId { get => departmentId; set => SetProperty(ref departmentId, value); }

        [Browsable(false)]
        public int UserId { get => userId; set => SetProperty(ref userId, value); }

        [Browsable(false)]
        [DisplayName("Mã giáo viên")]
        public string? TeacherCode { get => teacherCode; set => SetProperty(ref teacherCode, value); }
        [Browsable(false)]

        [DisplayName("Bằng cấp")]
        public string? Degree { get => degree; set => SetProperty(ref degree, value); }
        [Browsable(false)]

        [DisplayName("Chuyên môn")]
        public string? Expertise { get => expertise; set => SetProperty(ref expertise, value); }
        [Browsable(false)]

        [DisplayName("Trường đại học")]
        public string? University { get => university; set => SetProperty(ref university, value); }

        [Browsable(false)]
        [DisplayName("Năm tốt nghiệp")]
        public DateTime? GraduationYear { get => graduationYear; set => SetProperty(ref graduationYear, value); }

        [Browsable(false)]
        [DisplayName("Chuyên ngành")]
        public string? Major { get => major; set => SetProperty(ref major, value); }

        [Browsable(false)]
        public string? OtherCertifications { get => otherCertifications; set => SetProperty(ref otherCertifications, value); }

        [Browsable(false)]
        public string? Position { get => position; set => SetProperty(ref position, value); }

        [Browsable(false)]
        public decimal? Salary { get => salary; set => SetProperty(ref salary, value); }

        [Browsable(false)]
        public string? AdditionalBenifits { get => additionalBenifits; set => SetProperty(ref additionalBenifits, value); }

        [Browsable(false)]
        public string? CurrentHealthStatus { get => currentHealthStatus; set => SetProperty(ref currentHealthStatus, value); }

        [Browsable(false)]
        public string? HealthInsuranceInfo { get => healthInsuranceInfo; set => SetProperty(ref healthInsuranceInfo, value); }

        [Browsable(false)]
        public string? SelfIntroduction { get => selfIntroduction; set => SetProperty(ref selfIntroduction, value); }

        [Browsable(false)]
        public int SubjectId { get => subjectId; set => SetProperty(ref subjectId, value); }

        [Browsable(false)]
        public bool? IsLeader { get => isLeader; set => SetProperty(ref isLeader, value); }

        [Browsable(false)]
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

        [Browsable(false)]
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        [Browsable(false)]
        public virtual Department Department { get; set; } = null!;

        [Browsable(false)]
        public virtual ICollection<EditGradeSheetForm> EditGradeSheetForms { get; set; } = new List<EditGradeSheetForm>();

        [Browsable(false)]
        public virtual Subject Subject { get; set; } = null!;

        [Browsable(false)]
        public virtual User User { get; set; } = null!;
    }
}