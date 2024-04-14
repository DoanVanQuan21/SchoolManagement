using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int DepartmentId { get; set; }

    public int LeaderId { get; set; }

    public int UserId { get; set; }

    public string? TeacherCode { get; set; }

    public string? Degree { get; set; }

    public string? Expertise { get; set; }

    public string? University { get; set; }

    public DateTime? GraduationYear { get; set; }

    public string? Major { get; set; }

    public string? OtherCertifications { get; set; }

    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public string? AdditionalBenifits { get; set; }

    public string? CurrentHealthStatus { get; set; }

    public string? HealthInsuranceInfo { get; set; }

    public string? SelfIntroduction { get; set; }

    public int SubjectId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department Department { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
