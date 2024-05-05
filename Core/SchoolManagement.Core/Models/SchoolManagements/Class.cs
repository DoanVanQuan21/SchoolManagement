using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Class : BindableBase
{
    private int classId;
    private int teacherId;
    private string? classCode;
    private string? className;
    private int? numberOfStudent;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    [Browsable(false)]
    public int TeacherId
    { get => teacherId; set { SetProperty(ref teacherId, value); } }

    [DisplayName("Mã lớp")]
    public string? ClassCode
    { get => classCode; set { SetProperty(ref classCode, value); } }

    [DisplayName("Tên lớp")]
    public string? ClassName
    { get => className; set { SetProperty(ref className, value); } }

    [DisplayName("Số lượng học sinh")]
    public int? NumberOfStudent
    { get => numberOfStudent; set { SetProperty(ref numberOfStudent, value); } }

    [Browsable(false)]
    public virtual ICollection<EducationProgram> EducationPrograms { get; set; } = new List<EducationProgram>();

    [Browsable(false)]
    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    [Browsable(false)]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [Browsable(false)]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [Browsable(false)]
    public virtual Teacher Teacher { get; set; } = null!;
}