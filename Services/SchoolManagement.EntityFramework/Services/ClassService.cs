using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class ClassService : BaseService, IClassService
    {
        public ClassService() : base()
        {
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