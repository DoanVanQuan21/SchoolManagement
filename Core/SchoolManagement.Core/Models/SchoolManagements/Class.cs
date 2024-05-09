using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Class : BindableBase
{
    private int classId;
    private string? classCode;
    private string? className;
    private int? numberOfStudent;
    private int teacherId;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }
    public int TeacherId { get => teacherId; set => SetProperty(ref teacherId, value); }

    [DisplayName("Mã lớp")]
    public string? ClassCode
    { get => classCode; set { SetProperty(ref classCode, value); } }

    [DisplayName("Tên lớp")]
    public string? ClassName
    { get => className; set { SetProperty(ref className, value); } }

    [DisplayName("Số lượng học sinh")]
    public int? NumberOfStudent
    { get => numberOfStudent; set { SetProperty(ref numberOfStudent, value); } }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Teacher Teacher { get; set; } = null!;
}