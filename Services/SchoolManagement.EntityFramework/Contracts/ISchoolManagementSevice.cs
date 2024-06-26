﻿using SchoolManagement.EntityFramework.Repositories.SchoolManagement;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ISchoolManagementSevice : IDisposable
    {
        UserRepository UserRepository { get; }
        GradeSheetRepository GradeSheetRepository { get; }
        CourseRepository CourseRepository { get; }
        ClassRepository ClassRepository { get; }
        TeacherRepository TeacherRepository { get; }
        StudentRepository StudentRepository { get; }
        SubjectRepository SubjectRepository { get; }
        EditGradeSheetFormRepository EditGradeSheetFormRepository { get; }
        StudentAssignmentRepository StudentAssignmentRepository { get; }
        DepartmentRepository DepartmentRepository { get; }
        EducationProgramRepository EducationProgramRepository { get; }
        void Refresh();
        Task<string> Connect();
    }
}