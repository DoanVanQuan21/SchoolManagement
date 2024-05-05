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

        public Task<ObservableCollection<Class>> GetAllClassesByIDAsync(IList<int> ids)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetAllClassesByID(ids);
            });
        }

        public Class GetClassByID(int classID)
        {
            return _schoolManagementSevice.ClassRepository.GetClassByID(classID);
        }

        public Task<Class> GetClassByIDAsync(int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetClassByID(classID);
            });
        }

        public async Task<ObservableCollection<Class>> GetClassesBySize(int size, int page)
        {
            return await _schoolManagementSevice.ClassRepository.GetRecordBySize(size, page);
        }
    }
}