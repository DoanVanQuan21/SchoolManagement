using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class GradeSheet
{
    public int GradeSheetId { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public decimal? FirstRegularScore { get; set; }

    public decimal? SecondRegularScore { get; set; }

    public decimal? ThirdRegularScore { get; set; }

    public decimal? FourRegularScore { get; set; }

    public decimal? MidtermScore { get; set; }

    public decimal? FinalScore { get; set; }

    public decimal? SemesterAverage { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
