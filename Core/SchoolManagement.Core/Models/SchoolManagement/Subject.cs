using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectCode { get; set; }

    public string? SubjectName { get; set; }

    public string? Image { get; set; }
}
