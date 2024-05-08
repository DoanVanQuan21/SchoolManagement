﻿using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class GradeSheetService : BaseService, IGradeSheetService
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly ISubjectService _subjectService;
        private readonly ICourseService _courseService;

        public GradeSheetService() : base()
        {
            _studentService = Ioc.Resolve<IStudentService>();
            _classService = Ioc.Resolve<IClassService>();
            _subjectService = Ioc.Resolve<ISubjectService>();
            _courseService = Ioc.Resolve<ICourseService>();
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

        public async Task<ObservableCollection<GradeSheet>> GetGradeSheetsByStudentID(int studentID, int year)
        {
            var gradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetsByStudentID(studentID);
            if (gradeSheets == null)
            {
                return new();
            }
            var gradesInYear = new ObservableCollection<GradeSheet>();

            foreach (var gradeSheet in gradeSheets)
            {
                var course = await _courseService.GetCourseByClassAndSubjectID(gradeSheet.ClassId, gradeSheet.SubjectId, year);
                if (course == null)
                {
                    continue;
                }
                gradesInYear.Add(gradeSheet);
            }
            foreach (var grade in gradesInYear)
            {
                grade.Class = _classService.GetClassByID(grade.ClassId);
                grade.Ranked = GradeSheet.GetRanked(grade);
                grade.Student = _studentService.GetStudent(grade.StudentId);
                grade.Subject = await _subjectService.GetSubjectByID(grade.SubjectId);
                await Task.Delay(10);
            }
            return gradesInYear;
        }

        public async Task<ObservableCollection<GradeSheet>> FinishEditGradeSheet(ObservableCollection<GradeSheet> gradeSheets)
        {
            return await _schoolManagementSevice.GradeSheetRepository.FinishEditGradeSheet(gradeSheets);
        }

        public async Task<GradeSheet?> GetGradeSheetByGradeSheetID(int gradeSheetID)
        {
            var gradeSheet = await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetByGradeSheetID(gradeSheetID);
            gradeSheet.Class = await _classService.GetClassByIDAsync(gradeSheet.ClassId);
            gradeSheet.Subject = await _subjectService.GetSubjectByID(gradeSheet.SubjectId);
            gradeSheet.Student = await _studentService.GetStudentByStudentIDAsync(gradeSheet.StudentId);
            return gradeSheet;
        }
    }
}