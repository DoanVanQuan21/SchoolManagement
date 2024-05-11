using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Schedule : BindableBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int ScheduleId { get; set; }

    public string? ScheduleCode { get; set; }

    public DateTime? Day { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public int CourseId { get; set; }
}