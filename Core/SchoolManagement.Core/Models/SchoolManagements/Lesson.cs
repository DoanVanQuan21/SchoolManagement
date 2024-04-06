using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int EducationProgramId { get; set; }

    public string? LessonCode { get; set; }

    public string? LessonName { get; set; }

    public string? VideoUrl { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public virtual EducationProgram EducationProgram { get; set; } = null!;
}
