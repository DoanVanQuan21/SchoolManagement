using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class StudentAssignment : BindableBase
{
    private int studentId;
    private int classId;
    private DateTime startDate;
    private DateTime endDate;
    private string? status;

    public int StudentId { get => studentId; set => SetProperty(ref studentId, value); }

    public int ClassId { get => classId; set => SetProperty(ref classId, value); }

    public DateTime StartDate { get => startDate; set => SetProperty(ref startDate, value); }

    public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value); }

    public string? Status { get => status; set => SetProperty(ref status, value); }
}