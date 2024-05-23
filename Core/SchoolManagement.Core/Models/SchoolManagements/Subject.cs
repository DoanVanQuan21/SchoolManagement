using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Subject : BindableBase
{
    private int subjectId;
    private string? subjectCode;
    private string? subjectName;
    private string? image;

    [Browsable(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    [Browsable(false)]
    [DisplayName("SubjectCode_Label")]
    public string? SubjectCode
    { get => subjectCode; set { SetProperty(ref subjectCode, value); } }

    [Browsable(false)]
    [DisplayName("SubjectName_Label")]
    public string? SubjectName
    { get => subjectName; set { SetProperty(ref subjectName, value); } }

    [Browsable(false)]
    [DisplayName("Image_Label")]
    public string? Image
    { get => image; set { SetProperty(ref image, value); } }

    [Browsable(false)]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [Browsable(false)]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}