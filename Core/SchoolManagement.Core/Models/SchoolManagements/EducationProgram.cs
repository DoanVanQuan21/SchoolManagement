using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class EducationProgram
{
    public int EducationProgramId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public string? EducationProgramCode { get; set; }

    public string? EducationName { get; set; }

    public string? Status { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Subject Subject { get; set; } = null!;
}
