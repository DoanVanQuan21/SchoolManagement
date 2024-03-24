namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class ClassUser
{
    public int ClassId { get; set; }

    public int UserId { get; set; }

    public string? Position { get; set; }

    public string? Status { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}