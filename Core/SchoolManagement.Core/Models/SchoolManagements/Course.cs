using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Course : BindableBase
{
    private int classId;
    private int courseId;
    private int teacherId;
    private int subjectId;
    private DateTime startDate = DateTime.Now;
    private DateTime? endDate = DateTime.Now;
    private string? semester;
    private int educationProgramId;
    private string? status;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int CourseId { get => courseId; set => SetProperty(ref courseId, value); }

    [Browsable(false)]
    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    [Browsable(false)]
    public int TeacherId
    { get => teacherId; set { SetProperty(ref teacherId, value); } }

    [Browsable(false)]
    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    [Browsable(false)]
    public int EducationProgramId { get => educationProgramId; set => SetProperty(ref educationProgramId, value); }

    [Browsable(false)]
    public string? Semester { get => semester; set => SetProperty(ref semester, value); }

    [DisplayName("StartDate_Label")]
    public DateTime StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    [DisplayName("EndDate_Label")]
    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    [Browsable(false)]
    [DisplayName("Status_Label")]
    public string? Status { get => status; set => SetProperty(ref status, value); }

    [Browsable(false)]
    public virtual Class Class { get; set; } = null!;

    [Browsable(false)]
    public virtual EducationProgram EducationProgram { get; set; } = null!;

    [Browsable(false)]
    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    [Browsable(false)]
    public virtual Subject Subject { get; set; } = null!;

    [Browsable(false)]
    public virtual Teacher Teacher { get; set; } = null!;
}