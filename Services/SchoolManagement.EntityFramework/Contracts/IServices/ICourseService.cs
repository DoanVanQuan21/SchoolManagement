using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface ICourseService
    {
        ObservableCollection<Course> GetCourseByTeacherID(int TeacherID);
        Task<ObservableCollection<Course>> GetCourseByTeacherIDAsync(int TeacherID);
        List<int> GetClassIDs(int teacherID);
        Task<List<int>> GetClassIDsAsync(int teacherID);
    }
}