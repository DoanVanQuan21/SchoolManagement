using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ICourseService
    {
        Task<ObservableCollection<Course>> GetCourseOfTeacherByYear(int teacherID, int year,string semester);
        Task<Course?> GetCourseByID(int courseID);
        Task<ObservableCollection<Course>> GetCourses(int teacherID,int subjectID,int classID, int year);
        Task<Course?> GetCourse(int teacherID,int classID,int year,string semester);
    }
}