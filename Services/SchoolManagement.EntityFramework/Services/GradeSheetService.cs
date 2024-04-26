using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService : BaseService, IGradeSheetService
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        public GradeSheetService() : base()
        {
            _studentService = Ioc.Resolve<IStudentService>();  
            _classService = Ioc.Resolve<IClassService>();
        }

        public ObservableCollection<GradeSheet> GetGradeSheets(int subjectID, int classID)
        {
            var gradeSheets = _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheet(subjectID, classID);
            foreach (var gradeSheet in gradeSheets)
            {
                gradeSheet.Class = _classService.GetClassByID(gradeSheet.ClassId);
                gradeSheet.Student = _studentService.GetStudent(gradeSheet.StudentId);
            }
            return gradeSheets;
        }

        public Task<ObservableCollection<GradeSheet>> GetGradeSheetsAsync(int subjectID, int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetGradeSheets(subjectID, classID);
            });
        }
    }
}