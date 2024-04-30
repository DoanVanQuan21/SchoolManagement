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

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetsAsync(int subjectID, int classID)
        {
            var gradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheetAsync(subjectID, classID);
            foreach (var gradeSheet in gradeSheets)
            {
                gradeSheet.Class = _classService.GetClassByID(gradeSheet.ClassId);
                gradeSheet.Ranked = GradeSheet.GetRanked(gradeSheet);
                gradeSheet.Student = _studentService.GetStudent(gradeSheet.StudentId);
                await Task.Delay(100);
            }
            return gradeSheets;
        }

        public async Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets)
        {
            return await _schoolManagementSevice.GradeSheetRepository.UpdateOrAddRange(gradeSheets);
        }

        public async Task<bool> UpdateGradeSheetAsync(GradeSheet gradeSheet)
        {
            return await _schoolManagementSevice.GradeSheetRepository.Update(gradeSheet);
        }
    }
}