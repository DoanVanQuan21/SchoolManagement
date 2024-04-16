using SchoolManagement.Core.Constants;
using System.ComponentModel;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class GradeSheet
{
    [Browsable(false)]
    public int GradeSheetId { get; set; }

    [Browsable(false)]
    public int ClassId { get; set; }

    [Browsable(false)]
    public int StudentId { get; set; }

    [Browsable(false)]
    public int SubjectId { get; set; }

    [DisplayName("Thường xuyên 1")]
    public float? FirstRegularScore { get; set; }

    [DisplayName("Thường xuyên 2")]
    public float? SecondRegularScore { get; set; }

    [DisplayName("Thường xuyên 3")]
    public float? ThirdRegularScore { get; set; }

    [DisplayName("Thường xuyên 4")]
    public float? FourRegularScore { get; set; }

    [DisplayName("Giữa kỳ")]
    public float? MidtermScore { get; set; }

    [DisplayName("Cuối kỳ")]
    public float? FinalScore { get; set; }

    [Browsable(false)]
    public float? SemesterAverage { get; set; }

    [Browsable(false)]
    public string? Ranked => GetRanked();

    [Browsable(false)]
    public string? StudentName { get; }

    [Browsable(false)]
    public string? SubjectName { get; }

    [Browsable(false)]
    public string? ClassName { get; }

    [Browsable(false)]
    public virtual Class Class { get; set; } = null!;

    [Browsable(false)]
    public virtual Student Student { get; set; } = null!;

    [Browsable(false)]
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