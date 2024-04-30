using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Department : BindableBase
{
    private int departmentId;
    private string? departmentCode;
    private string? departmentName;
    private DateTime? foundingDate;
    private string? image;

    public int DepartmentId
    { get => departmentId; set { SetProperty(ref departmentId, value); } }

    public string? DepartmentCode
    { get => departmentCode; set { SetProperty(ref departmentCode, value); } }

    public string? DepartmentName
    { get => departmentName; set { SetProperty(ref departmentName, value); } }

    public DateTime? FoundingDate
    { get => foundingDate; set { SetProperty(ref foundingDate, value); } }

    public string? Image
    { get => image; set { SetProperty(ref image, value); } }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}