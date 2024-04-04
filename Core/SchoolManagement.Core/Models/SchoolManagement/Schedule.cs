using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public string? ScheduleCode { get; set; }

    public DateTime? Day { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }
}
