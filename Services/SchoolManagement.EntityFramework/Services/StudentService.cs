﻿using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class StudentService : IStudentService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;
        private readonly IUserService _userService;
        public StudentService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
            _userService = Ioc.Resolve<IUserService>();
        }

        public async Task<Student?> GetStudentAndGradeSheets(int userID)
        {
            var student = await GetStudentByUserID(userID);
            if(student == null)
            {
                return student;
            }
            student.GradeSheets = await _schoolManagementSevice.GradeSheetRepository.GetGradeSheetsByStudentID(student.StudentId);
            return student;
        }

        public Task<int> GetStudentByStudentCode(string studentCode)
        {
            return Task.Factory.StartNew(() =>
            {
                var student = _schoolManagementSevice.StudentRepository.FirstOrDefault(s => s.StudentCode == studentCode);
                if(student == null)
                {
                    return 0;
                }
                return student.StudentId;
            });
        }

        public async Task<Student?> GetStudentByStudentID(int studentID)
        {
            var student = _schoolManagementSevice.StudentRepository.FirstOrDefault(s => s.StudentId == studentID);
            student.User = await _userService.GetUserAsync(student.UserId);
            return student;
        }

        public Task<Student?> GetStudentByUserID(int userID)
        {
            return Task.Factory.StartNew(() =>
            {
                return _schoolManagementSevice.StudentRepository.FirstOrDefault(s => s.UserId == userID);
            });
        }

        public async Task<ObservableCollection<Student>> GetStudentOfClassByYear(int classID, int year)
        {
            var students = new ObservableCollection<Student>();
            var studentAssigns = await _schoolManagementSevice.StudentAssignmentRepository.GetStudentAssignsOfClassByYear(classID, year);
            foreach (var studentAssign in studentAssigns)
            {
                var student = await GetStudentByStudentID(studentAssign.StudentId);
                if (student == null)
                {
                    continue;
                }
                students.Add(student);
            }
            return students;
        }
    }
}