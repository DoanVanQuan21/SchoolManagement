using SchoolManagement.EntityFramework.Repositories.SchoolManagement;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ISchoolManagementSevice
    {
        UserRepository UserRepository { get; }
        GradeSheetRepository GradeSheetRepository { get; }
        CourseRepository CourseRepository { get; }
        ClassRepository ClassRepository { get; }
        TeacherRepository TeacherRepository { get; }
    }
}