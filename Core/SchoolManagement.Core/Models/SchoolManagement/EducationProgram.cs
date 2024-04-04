using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class EducationProgram
{
    public int EducationProgramId { get; set; }

    public string? EducationProgramCode { get; set; }

    public string? EducationName { get; set; }

    public string? Status { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }
}
