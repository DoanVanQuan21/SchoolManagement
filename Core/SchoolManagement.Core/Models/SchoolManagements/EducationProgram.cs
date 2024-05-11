using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class EducationProgram : BindableBase
{
    private int educationProgramId;
    private string? educationProgramCode;
    private string? educationName;
    private string? status;
    private int? numberOfLesson;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EducationProgramId
    { get => educationProgramId; set { SetProperty(ref educationProgramId, value); } }

    public string? EducationProgramCode
    { get => educationProgramCode; set { SetProperty(ref educationProgramCode, value); } }

    public string? EducationName
    { get => educationName; set { SetProperty(ref educationName, value); } }

    public string? Status
    { get => status; set { SetProperty(ref status, value); } }

    public int? NumberOfLesson { get => numberOfLesson; set => SetProperty(ref numberOfLesson, value); }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}