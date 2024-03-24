namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class GradeSheet
{
    public int GradeSheetId { get; set; }

    public string? GradeSheetCode { get; set; }

    public double? FirstScore { get; set; }

    public double? SecondScore { get; set; }

    public double? ThirdScore { get; set; }

    public double? FinalScore { get; set; }

    public double? AverageScore { get; set; }

    public int SubjectId { get; set; }

    public int UserId { get; set; }
}