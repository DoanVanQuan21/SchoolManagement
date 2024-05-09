using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class ClassService : IClassService
    {
        private ISchoolManagementSevice _schoolManagementSevice;
        public ClassService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }

        public Task<bool> AddClass(Class _class)
        {
            return Task.Factory.StartNew(() =>
            {
                if (_class == null)
                {
                    return false;
                }
                _schoolManagementSevice.ClassRepository.Add(_class);
                return true;
            });
        }

        public async Task<bool> DeleteClass(int classID)
        {
            return await _schoolManagementSevice.ClassRepository.DeleteRecord(await GetClassByID(classID));
        }

        public Task<ObservableCollection<Class>> GetAllClassesByID(IList<int> ids)
        {
            return Task.Factory.StartNew(() =>
            {
                return _schoolManagementSevice.ClassRepository.GetAllClassesByID(ids);
            });
        }

        public Task<Class> GetClassByID(int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                return _schoolManagementSevice.ClassRepository.GetClassByID(classID);
            });
        }

        public async Task<ObservableCollection<Class>> GetClassesBySize(int size, int page)
        {
            return await _schoolManagementSevice.ClassRepository.GetRecordBySize(size, page);
        }
    }
}