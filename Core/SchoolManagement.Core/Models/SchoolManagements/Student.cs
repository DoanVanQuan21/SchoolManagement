using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Student : BindableBase
{
    private int studentId;
    private int userId;
    private string? studentCode;
    private int classId;

    public int StudentId
    { get => studentId; set { SetProperty(ref studentId, value); } }

    public int UserId
    { get => userId; set { SetProperty(ref userId, value); } }

    public string? StudentCode
    { get => studentCode; set { SetProperty(ref studentCode, value); } }

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual User User { get; set; } = null!;
}