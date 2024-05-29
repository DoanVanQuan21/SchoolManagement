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
    private int? teacherId;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    [Browsable(false)]
    public int? TeacherId { get => teacherId; set => teacherId = value; }

    [DisplayName("ClassCode_Label")]
    [Browsable(false)]
    public string? ClassCode
    { get => classCode; set { SetProperty(ref classCode, value); } }

    [DisplayName("ClassName_Label")]
    public string? ClassName
    { get => className; set { SetProperty(ref className, value); } }

    [DisplayName("NumberOfStudent_Label")]
    public int? NumberOfStudent
    { get => numberOfStudent; set { SetProperty(ref numberOfStudent, value); } }

    [Browsable(false)]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}