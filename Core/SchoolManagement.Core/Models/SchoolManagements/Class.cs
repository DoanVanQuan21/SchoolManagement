using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Class : BindableBase
{
    private int classId;
    private int teacherId;
    private DateTime? classCode;
    private string? className;
    private int? numberOfStudent;

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public int TeacherId
    { get => teacherId; set { SetProperty(ref teacherId, value); } }

    public DateTime? ClassCode
    { get => classCode; set { SetProperty(ref classCode, value); } }

    public string? ClassName
    { get => className; set { SetProperty(ref className, value); } }

    public int? NumberOfStudent
    { get => numberOfStudent; set { SetProperty(ref numberOfStudent, value); } }

    public virtual ICollection<EducationProgram> EducationPrograms { get; set; } = new List<EducationProgram>();

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher Teacher { get; set; } = null!;
}