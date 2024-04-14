using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ICourseService
    {
        ObservableCollection<Course> GetCourseByTeacherID(int TeacherID);
    }
}