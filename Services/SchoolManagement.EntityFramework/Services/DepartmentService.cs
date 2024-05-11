using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;
        public DepartmentService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }
        public async Task<ObservableCollection<Department>> GetDepartments()
        {
            return await _schoolManagementSevice.DepartmentRepository.GetAllAsync();
        }
    }
}