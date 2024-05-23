using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class ClassService : BaseService, IClassService
    {
        public ClassService() : base()
        {
        }

        public Task<bool> AddClass(Class _class)
        {
            return Task.Factory.StartNew(() =>
            {
                if (_class == null)
                {
                    return false;
                }
                _class.ClassCode = $"CL{_class.ClassName}{DateTime.Now.Year}";
                _schoolManagementSevice.ClassRepository.Add(_class);
                return true;
            });
        }

        public async Task<bool> DeleteClass(int classID)
        {
            return await _schoolManagementSevice.ClassRepository.DeleteRecord(await GetClassByID(classID));
        }

        public async Task<bool> EditClass(Class _class)
        {
            return await _schoolManagementSevice.ClassRepository.EditClass(_class);
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
                var t = _schoolManagementSevice.ClassRepository.GetClassByID(classID);
                return _schoolManagementSevice.ClassRepository.GetClassByID(classID);
            });
        }

        public async Task<ObservableCollection<Class>> GetClasses()
        {
            return await _schoolManagementSevice.ClassRepository.GetAllAsync();
        }

        public async Task<ObservableCollection<Class>> GetClassesBySize(int size, int page)
        {
            return await _schoolManagementSevice.ClassRepository.GetRecordBySize(size, page);
        }
    }
}