using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;
using System.Reactive.Subjects;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService : BaseService, IGradeSheetService
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly ISubjectService _subjectService;
        public GradeSheetService() : base()
        {
            _studentService = Ioc.Resolve<IStudentService>();
            _classService = Ioc.Resolve<IClassService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
        }

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetsAsync(int subjectID, int classID)
        {
            var gradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheetAsync(subjectID, classID);
            foreach (var gradeSheet in gradeSheets)
            {
                gradeSheet.Class = _classService.GetClassByID(gradeSheet.ClassId);
                gradeSheet.Ranked = GradeSheet.GetRanked(gradeSheet);
                gradeSheet.Student = _studentService.GetStudent(gradeSheet.StudentId);
                await Task.Delay(10);
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

        public async Task<ObservableCollection<GradeSheet>> GetAllGradeSheetByClassAndStudentID(int studentID, int classID)
        {
            var gradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetAllGradeSheetByClassAndStudentID(studentID, classID);
            if (gradeSheets == null)
            {
                return new();
            }
            foreach (var gradeSheet in gradeSheets)
            {
                gradeSheet.Class = _classService.GetClassByID(gradeSheet.ClassId);
                gradeSheet.Ranked = GradeSheet.GetRanked(gradeSheet);
                gradeSheet.Student = _studentService.GetStudent(gradeSheet.StudentId);
                gradeSheet.Subject = await _subjectService.GetSubjectByID(gradeSheet.SubjectId);
                await Task.Delay(10);
            }
            return gradeSheets;
        }
    }
}