using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class HomeroomAssignment : BindableBase
{
    private int classId;
    private int teacherId;
    private DateTime startDate;
    private DateTime endDate;

    public int ClassId { get => classId; set => SetProperty(ref classId, value); }

    public int TeacherId { get => teacherId; set => SetProperty(ref teacherId, value); }

    public DateTime StartDate { get => startDate; set => SetProperty(ref startDate, value); }

    public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value); }
}