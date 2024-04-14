using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class ClassService : IClassService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;

        public ClassService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }

        public ObservableCollection<Class> GetAllClassesByID(IList<int> ids)
        {
            return _schoolManagementSevice.ClassRepository.GetAllClassesByID(ids);
        }

        public Class GetClassByID(int classID)
        {
            return _schoolManagementSevice.ClassRepository.GetClassByID(classID);
        }
    }
}