﻿using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IStudentService
    {
        Task<Student?> GetStudentByStudentID(int studentID);
        Task<Student?> GetStudentAndGradeSheets(int userID);
        Task<Student?> GetStudentByUserID(int userID);
        Task<int> GetStudentByStudentCode(string studentCode);
        Task<ObservableCollection<Student>> GetStudentOfClassByYear(int classID,int year);
    }
}