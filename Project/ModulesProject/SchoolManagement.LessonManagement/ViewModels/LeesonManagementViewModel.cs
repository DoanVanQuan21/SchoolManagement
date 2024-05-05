using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.LessonManagement.ViewModels
{
    internal class LessonManagementViewModel : BaseRegionViewModel
    {
        private Lesson selectedLesson;

        public override string Title => "Quản lý bài học";

        public override User User { get; protected set; }

        public LessonManagementViewModel()
        {
            User = RootContext.CurrentUser;
            Lessons = new();
        }

        public ObservableCollection<Lesson> Lessons { get; set; }
        public Lesson SelectedLesson { get => selectedLesson; set => SetProperty(ref selectedLesson, value); }
    }
}