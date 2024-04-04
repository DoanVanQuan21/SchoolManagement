using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class Course
{
    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int? NumberOfLessons { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int TeacherId { get; set; }
}
