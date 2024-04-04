using System;
using System.Collections.Generic;

namespace SchoolManagement.Core.Models.SchoolManagement;

public partial class GradeSheet
{
    public int GradeSheetId { get; set; }

    public decimal? FirstRegularScore { get; set; }

    public decimal? SecondRegularScore { get; set; }

    public decimal? ThirdRegularScore { get; set; }

    public decimal? FourRegularScore { get; set; }

    public decimal? MidtermScore { get; set; }

    public decimal? FinalScore { get; set; }

    public decimal? SemesterAverage { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int StudentId { get; set; }
}
