using Prism.Mvvm;
using SchoolManagement.GlobalShared.CustomAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class GradeSheet : BindableBase
{
    private int gradeSheetId;
    private int studentId;
    private double? firstRegularScore;
    private double? secondRegularScore;
    private double? thirdRegularScore;
    private double? fourRegularScore;
    private double? midtermScore;
    private double? finalScore;
    private double? semesterAverage;
    private string? ranked;
    private bool? promotionDecision;
    private bool? @lock;
    private int courseId;

    public GradeSheet()
    {
    }

    public GradeSheet(GradeSheet other)
    {
        // Copy constructor
        gradeSheetId = other.gradeSheetId;
        studentId = other.studentId;
        firstRegularScore = other.firstRegularScore;
        secondRegularScore = other.secondRegularScore;
        thirdRegularScore = other.thirdRegularScore;
        fourRegularScore = other.fourRegularScore;
        midtermScore = other.midtermScore;
        finalScore = other.finalScore;
        semesterAverage = other.semesterAverage;
        Student = other.Student;
    }

    [IsHeaderExcel(false)]
    [Browsable(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GradeSheetId
    { get => gradeSheetId; set { SetProperty(ref gradeSheetId, value); } }

    [Browsable(false)]
    [DisplayName("Lớp")]
    [IsHeaderExcel(false)]
    public int CourseId { get => courseId; set => SetProperty(ref courseId, value); }

    [Browsable(false)]
    [IsID(true)]
    [DisplayName("Họ và tên")]
    public int StudentId
    { get => studentId; set { SetProperty(ref studentId, value); } }

    [DisplayName("Thường xuyên 1")]
    public double? FirstRegularScore
    { get => firstRegularScore; set { SetProperty(ref firstRegularScore, value); } }

    [DisplayName("Thường xuyên 2")]
    public double? SecondRegularScore
    { get => secondRegularScore; set { SetProperty(ref secondRegularScore, value); } }

    [DisplayName("Thường xuyên 3")]
    public double? ThirdRegularScore
    { get => thirdRegularScore; set { SetProperty(ref thirdRegularScore, value); } }

    [DisplayName("Thường xuyên 4")]
    public double? FourRegularScore
    { get => fourRegularScore; set { SetProperty(ref fourRegularScore, value); } }

    [DisplayName("Giữa kỳ")]
    public double? MidtermScore
    { get => midtermScore; set { SetProperty(ref midtermScore, value); } }

    [DisplayName("Cuối kỳ")]
    public double? FinalScore
    { get => finalScore; set { SetProperty(ref finalScore, value); } }

    [Browsable(false)]
    [DisplayName("Trung bình TL")]
    public double? SemesterAverage
    { get => semesterAverage; set { SetProperty(ref semesterAverage, value); } }

    [IsHeaderExcel(false)]
    [Browsable(false)]
    public bool? PromotionDecision { get => promotionDecision; set => SetProperty(ref promotionDecision, value); }

    [IsHeaderExcel(false)]
    [Browsable(false)]
    public bool? Lock { get => @lock; set => SetProperty(ref @lock, value); }

    [Browsable(false)]
    [NotMapped]
    [DisplayName("Xếp loại")]
    public string? Ranked
    { get => ranked; set { SetProperty(ref ranked, value); } }

    [IsHeaderExcel(false)]
    [Browsable(false)]
    public virtual Course Course { get; set; } = null!;

    [IsHeaderExcel(false)]
    [Browsable(false)]
    public virtual ICollection<EditGradeSheetForm> EditGradeSheetForms { get; set; } = new List<EditGradeSheetForm>();

    [IsHeaderExcel(false)]
    [Browsable(false)]
    public virtual Student Student { get; set; } = null!;

    public static string GetRanked(GradeSheet gradeSheet)
    {
        try
        {
            var finalScore = (gradeSheet.FirstRegularScore + gradeSheet.SecondRegularScore + gradeSheet.ThirdRegularScore
            + gradeSheet.FourRegularScore + gradeSheet.MidtermScore * 2 + gradeSheet.FinalScore * 3) / 9;
            if (finalScore >= 8.5)
            {
                return Constants.Ranked.Excellent;
            }
            if (finalScore >= 7)
            {
                return Constants.Ranked.Good;
            }
            if (finalScore >= 5.5)
            {
                return Constants.Ranked.Average;
            }
            if (finalScore >= 4.0)
            {
                return Constants.Ranked.BelowAverage;
            }
            return Constants.Ranked.Bad;
        }
        catch (Exception)
        {
            return Constants.Ranked.Bad;
        }
    }
}