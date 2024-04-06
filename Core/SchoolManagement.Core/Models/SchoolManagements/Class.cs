namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Class
{
    public int ClassId { get; set; }

    public int TeacherId { get; set; }

    public DateTime? ClassCode { get; set; }

    public string? ClassName { get; set; }

    public int? NumberOfStudent { get; set; }

    public virtual ICollection<EducationProgram> EducationPrograms { get; set; } = new List<EducationProgram>();

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}