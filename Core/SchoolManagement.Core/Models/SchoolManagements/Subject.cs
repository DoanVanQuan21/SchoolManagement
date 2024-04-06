using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectCode { get; set; }

    public string? SubjectName { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<EducationProgram> EducationPrograms { get; set; } = new List<EducationProgram>();

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
