using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class Class
{
    public int ClassId { get; set; }

    public DateTime? ClassCode { get; set; }

    public string? ClassName { get; set; }

    public int TeacherId { get; set; }

    public string? Image { get; set; }
}
