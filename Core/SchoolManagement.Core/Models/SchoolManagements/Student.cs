using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Student
{
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public string? StudentCode { get; set; }

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual User User { get; set; } = null!;
}
