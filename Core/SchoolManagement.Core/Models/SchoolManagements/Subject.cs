using Prism.Mvvm;
using System.Reactive.Concurrency;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Subject : BindableBase
{
    private int subjectId;
    private string? subjectCode;
    private string? subjectName;
    private string? image;

    public int SubjectId { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public string? SubjectCode { get => subjectCode; set { SetProperty(ref subjectCode, value); } }

    public string? SubjectName { get => subjectName; set { SetProperty(ref subjectName, value); } }

    public string? Image { get => image; set { SetProperty(ref image, value); } }

    public virtual ICollection<EducationProgram> EducationPrograms { get; set; } = new List<EducationProgram>();

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}