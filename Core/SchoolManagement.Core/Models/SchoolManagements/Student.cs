using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Student : BindableBase
{
    private int studentId;
    private int userId;
    private string? studentCode;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Browsable(false)]
    public int StudentId
    { get => studentId; set { SetProperty(ref studentId, value); } }

    [Browsable(false)]
    public int UserId
    { get => userId; set { SetProperty(ref userId, value); } }

    [Browsable(false)]
    [DisplayName("StudentCode_Label")]
    public string? StudentCode
    { get => studentCode; set { SetProperty(ref studentCode, value); } }

    [Browsable(false)]
    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    [Browsable(false)]
    public virtual User User { get; set; } = null!;
}