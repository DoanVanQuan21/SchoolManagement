using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagement.GradeSheetManagement.ViewModels
{
    public class ComponentGradeSheetViewModel : BaseRegionViewModel
    {
        private readonly IStudentService _studentService;
        private readonly IGradeSheetService _gradeSheetService;
        private Date currentDate;

        public override string Title => Util.GetResourseString("ViewComponentGrades_Label");

        public override User User { get; protected set; }

        public ComponentGradeSheetViewModel()
        {
            _studentService = Ioc.Resolve<IStudentService>();
            _gradeSheetService = Ioc.Resolve<IGradeSheetService>();
            User = RootContext.CurrentUser;
            GradeSheets = new();
            InitDates();
        }

        public ICommand ClickedSelectedDate { get; set; }

        protected override void RegisterCommand()
        {
            ClickedSelectedDate = new DelegateCommand(OnSelectedDate);
            base.RegisterCommand();
        }

        private void OnSelectedDate()
        {
            throw new NotImplementedException();
        }

        private async void InitDates()
        {
            Dates = new();
            var startYear = User.StartDate.Year;
            var now = DateTime.Now.Year;
            for (int i = startYear; i <= now; i++)
            {
                Dates.Add(new Date()
                {
                    Year = i,
                });
                await Task.Delay(100);
            }
            CurrentDate = Dates.LastOrDefault();
        }

        public ObservableCollection<GradeSheet> GradeSheets { get; set; }
        public ObservableCollection<Date> Dates { get; set; }

        public Date CurrentDate
        { get => currentDate; set { SetProperty(ref currentDate, value); GetGradeSheets(); } }

        private async void GetGradeSheets()
        {
            GradeSheets.Clear();
            var student = await _studentService.GetStudentByUserID(User.UserId);
            var grades = await _gradeSheetService.GetGradeSheetsByStudentID(student.StudentId, CurrentDate.Year);
            if (grades?.Any() == false)
            {   
                NotificationManager.ShowWarning(Util.GetResourseString("GradeSheetEmpty_Message"));
                return;
            }
            GradeSheets.AddRange(grades);
        }
    }
}