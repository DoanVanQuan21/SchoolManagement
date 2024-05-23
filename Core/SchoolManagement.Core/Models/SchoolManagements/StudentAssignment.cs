using Prism.Mvvm;
using System.ComponentModel;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class StudentAssignment : BindableBase
{
    private int studentId;
    private int classId;
    private DateTime startDate;
    private DateTime endDate;
    private string? status;

    [Browsable(false)]
    public int StudentId { get => studentId; set => SetProperty(ref studentId, value); }

    [Browsable(false)]
    public int ClassId { get => classId; set => SetProperty(ref classId, value); }

    [Browsable(false)]
    [DisplayName("StartDate_Label")]
    public DateTime StartDate { get => startDate; set => SetProperty(ref startDate, value); }

    [Browsable(false)]
    [DisplayName("EndDate_Label")]
    public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value); }

    [Browsable(false)]
    [DisplayName("Status_Label")]
    public string? Status { get => status; set => SetProperty(ref status, value); }
}