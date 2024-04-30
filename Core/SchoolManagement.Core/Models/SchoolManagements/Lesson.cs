using Prism.Mvvm;

namespace SchoolManagement.Core.Models.SchoolManagements;

public partial class Lesson : BindableBase
{
    private int lessonId;
    private int educationProgramId;
    private string? lessonCode;
    private string? lessonName;
    private string? videoUrl;
    private string? imageUrl;
    private string? status;

    public int LessonId
    { get => lessonId; set { SetProperty(ref lessonId, value); } }

    public int EducationProgramId
    { get => educationProgramId; set { SetProperty(ref educationProgramId, value); } }

    public string? LessonCode
    { get => lessonCode; set { SetProperty(ref lessonCode, value); } }

    public string? LessonName
    { get => lessonName; set { SetProperty(ref lessonName, value); } }

    public string? VideoUrl
    { get => videoUrl; set { SetProperty(ref videoUrl, value); } }

    public string? ImageUrl
    { get => imageUrl; set { SetProperty(ref imageUrl, value); } }

    public string? Status
    { get => status; set { SetProperty(ref status, value); } }

    public virtual EducationProgram EducationProgram { get; set; } = null!;
}