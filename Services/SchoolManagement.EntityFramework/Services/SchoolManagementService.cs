using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Repositories.SchoolManagement;

namespace SchoolManagement.EntityFramework.Services
{
    public class SchoolManagementService : ISchoolManagementSevice
    {
        private readonly IAppManager _appManager;
        private readonly IDatabaseInfoProvider _databaseInfoProvider;
        private SchoolManagementContext schoolManagementContext;

        public SchoolManagementService()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            _databaseInfoProvider = Ioc.Resolve<IDatabaseInfoProvider>();
            InitConnectionDatabase();
        }

        public UserRepository UserRepository { get; private set; }

        private void InitConnectionDatabase()
        {
            if (string.IsNullOrEmpty(_databaseInfoProvider.ServerInfor.ConnectionString))
            {
                //TODO
                return;
            }
            schoolManagementContext = new SchoolManagementContext(_databaseInfoProvider.ServerInfor.ConnectionString);
            UserRepository = new UserRepository(schoolManagementContext);
        }
    }
}