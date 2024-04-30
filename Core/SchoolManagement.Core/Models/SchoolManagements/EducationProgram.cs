using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class EducationProgram : BindableBase
{
    private int educationProgramId;
    private int classId;
    private int subjectId;
    private string? educationProgramCode;
    private string? educationName;
    private string? status;

    public int EducationProgramId
    { get => educationProgramId; set { SetProperty(ref educationProgramId, value); } }

    public int ClassId
    { get => classId; set { SetProperty(ref classId, value); } }

    public int SubjectId
    { get => subjectId; set { SetProperty(ref subjectId, value); } }

    public string? EducationProgramCode
    { get => educationProgramCode; set { SetProperty(ref educationProgramCode, value); } }

    public string? EducationName
    { get => educationName; set { SetProperty(ref educationName, value); } }

    public string? Status
    { get => status; set { SetProperty(ref status, value); } }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Subject Subject { get; set; } = null!;
}