using SchoolManagement.Core.Constants;

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

    public string? Ranked => GetRanked();
    public string? StudentName { get; }
    public string? SubjectName { get; }
    public string? ClassName { get;  }
    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
    private string GetRanked()
    {
        try
        {
            var finalScore = (FirstRegularScore + SecondRegularScore + ThirdRegularScore
            + FourRegularScore + MidtermScore * 2 + FinalScore * 3) / 9;
            if (finalScore >= 8.5 || finalScore <= 10)
            {
                return Constants.Ranked.Excellent;
            }
            if (finalScore >= 7 || finalScore <= 8.4)
            {
                return Constants.Ranked.Good;
            }
            if (finalScore >= 5.5 || finalScore <= 6.9)
            {
                return Constants.Ranked.Average;
            }
            if (finalScore >= 4.0 || finalScore <= 5.4)
            {
                return Constants.Ranked.BelowAverage;
            }
            return Constants.Ranked.Bad;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}