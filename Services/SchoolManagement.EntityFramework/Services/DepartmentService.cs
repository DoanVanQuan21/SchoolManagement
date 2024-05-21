using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService() : base()
        {
        }

        public async Task<ObservableCollection<Department>> GetDepartments()
        {
            return await _schoolManagementSevice.DepartmentRepository.GetAllAsync();
        }
    }
}