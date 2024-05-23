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
        [DisplayName("TeacherCode_Label")]
        public string? TeacherCode { get => teacherCode; set => SetProperty(ref teacherCode, value); }

        [Browsable(false)]
        [DisplayName("Degree_Label")]
        public string? Degree { get => degree; set => SetProperty(ref degree, value); }

        [Browsable(false)]
        [DisplayName("Expertise_Label")]
        public string? Expertise { get => expertise; set => SetProperty(ref expertise, value); }

        [Browsable(false)]
        [DisplayName("University_Label")]
        public string? University { get => university; set => SetProperty(ref university, value); }

        [Browsable(false)]
        [DisplayName("GraduationYear_Label")]
        public DateTime? GraduationYear { get => graduationYear; set => SetProperty(ref graduationYear, value); }

        [Browsable(false)]
        [DisplayName("Major_Label")]
        public string? Major { get => major; set => SetProperty(ref major, value); }

        [Browsable(false)]
        [DisplayName("OtherCertifications_Label")]
        public string? OtherCertifications { get => otherCertifications; set => SetProperty(ref otherCertifications, value); }

        [Browsable(false)]
        [DisplayName("Position_Label")]
        public string? Position { get => position; set => SetProperty(ref position, value); }

        [Browsable(false)]
        [DisplayName("Salary_Label")]
        public decimal? Salary { get => salary; set => SetProperty(ref salary, value); }

        [Browsable(false)]
        [DisplayName("AdditionalBenifits_Label")]
        public string? AdditionalBenifits { get => additionalBenifits; set => SetProperty(ref additionalBenifits, value); }

        [Browsable(false)]
        [DisplayName("CurrentHealthStatus_Label")]
        public string? CurrentHealthStatus { get => currentHealthStatus; set => SetProperty(ref currentHealthStatus, value); }

        [Browsable(false)]
        [DisplayName("HealthInsuranceInfo_Label")]
        public string? HealthInsuranceInfo { get => healthInsuranceInfo; set => SetProperty(ref healthInsuranceInfo, value); }

        [Browsable(false)]
        [DisplayName("SelfIntroduction_Label")]
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