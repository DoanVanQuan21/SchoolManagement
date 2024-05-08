using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Schedule : BindableBase
{
    private int scheduleId;
    private int classId;
    private int subjectId;
    private string? scheduleCode;
    private DateTime? day;
    private DateTime? start;
    private DateTime? end;
    private int studentId;

    public int ScheduleId
    { get => scheduleId; set { SetProperty(ref scheduleId, value); } }

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public int StudentId { get => studentId; set => SetProperty(ref studentId, value); }

    public string? ScheduleCode
    { get => scheduleCode; set { SetProperty(ref scheduleCode, value); } }

    public DateTime? Day
    { get => day; set { SetProperty(ref day, value); } }

    public DateTime? Start
    { get => start; set { SetProperty(ref start, value); } }

    public DateTime? End
    { get => end; set { SetProperty(ref end, value); } }

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}