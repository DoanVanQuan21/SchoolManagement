using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class EditGradeSheetForm : BindableBase
{
    private int editGradeSheetFormId;
    private int gradeSheetId;
    private DateTime? time;
    private string? status;
    private string reason = null!;
    private GradeSheet? gradeSheet;
    private int teacherId;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EditGradeSheetFormId { get => editGradeSheetFormId; set => SetProperty(ref editGradeSheetFormId, value); }

    public int GradeSheetId { get => gradeSheetId; set => SetProperty(ref gradeSheetId, value); }
    public int TeacherId { get => teacherId; set => SetProperty(ref teacherId, value); }

    public DateTime? Time { get => time; set => SetProperty(ref time, value); }

    public string? Status { get => status; set => SetProperty(ref status, value); }

    public string Reason { get => reason; set => SetProperty(ref reason, value); }
    public virtual GradeSheet? GradeSheet { get => gradeSheet; set => SetProperty(ref gradeSheet, value); }
    public virtual Teacher Teacher { get; set; } = null!;
}