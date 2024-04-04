using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagement;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Repositories.SchoolManagement;

namespace SchoolManagement.Core.Services
{
    public class SchoolManagementService : ISchoolManagementSevice
    {
        private readonly IAppManager _appManager;
        private SchoolManagementContext schoolManagementContext;

        public SchoolManagementService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            InitConnectionDatabase();
        }

        public UserRepository UserRepository { get; private set; }

        private void InitConnectionDatabase()
        {
            if (string.IsNullOrEmpty(_appManager.BootSetting.CurrentServerInfor.ConnectionString))
            {
                //TODO
                return;
            }
            schoolManagementContext = new SchoolManagementContext(_appManager.BootSetting.CurrentServerInfor.ConnectionString);
            UserRepository = new UserRepository(schoolManagementContext);
        }
    }
}