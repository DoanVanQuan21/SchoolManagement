using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Course : BindableBase
{
    private int classId;
    private int teacherId;
    private int subjectId;
    private int? numberOfLessons;
    private DateTime? startDate;
    private DateTime? endDate;

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public int TeacherId
    { get => teacherId; set { SetProperty(ref teacherId, value); } }

    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public int? NumberOfLessons
    { get => numberOfLessons; set { SetProperty(ref numberOfLessons, value); } }

    public DateTime? StartDate
    { get => startDate; set { SetProperty(ref startDate, value); } }

    public DateTime? EndDate
    { get => endDate; set { SetProperty(ref endDate, value); } }

    public virtual Teacher Teacher { get; set; } = null!;
}