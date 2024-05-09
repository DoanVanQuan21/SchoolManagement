using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Course : BindableBase
{
    private int classId;
    private int courseId;
    private int teacherId;
    private int subjectId;
    private DateTime startDate;
    private DateTime? endDate;
    private string? semester;
    private int educationProgramId;
    private string? status;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseId { get => courseId; set => SetProperty(ref courseId, value); }

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public int TeacherId
    { get => teacherId; set { SetProperty(ref teacherId, value); } }

    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public int EducationProgramId { get => educationProgramId; set => SetProperty(ref educationProgramId, value); }

    public string? Semester { get => semester; set => SetProperty(ref semester, value); }

    public DateTime StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    public string? Status { get => status; set => SetProperty(ref status, value); }

    public virtual Class Class { get; set; } = null!;

    public virtual EducationProgram EducationProgram { get; set; } = null!;

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}