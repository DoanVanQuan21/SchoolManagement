namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class GradeSheet
{
    public int GradeSheetId { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public float? FirstRegularScore { get; set; }

    public float? SecondRegularScore { get; set; }

    public float? ThirdRegularScore { get; set; }

    public float? FourRegularScore { get; set; }

    public float? MidtermScore { get; set; }

    public float? FinalScore { get; set; }

    public float? SemesterAverage { get; set; }

    public string? Ranked { get; }
    public string? StudentName { get; }
    public string? SubjectName { get; }
    public string? ClassName { get;  }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}