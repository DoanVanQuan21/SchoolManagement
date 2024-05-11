using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Subject : BindableBase
{
    private int subjectId;
    private string? subjectCode;
    private string? subjectName;
    private string? image;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public string? SubjectCode
    { get => subjectCode; set { SetProperty(ref subjectCode, value); } }

    public string? SubjectName
    { get => subjectName; set { SetProperty(ref subjectName, value); } }

    public string? Image
    { get => image; set { SetProperty(ref image, value); } }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}