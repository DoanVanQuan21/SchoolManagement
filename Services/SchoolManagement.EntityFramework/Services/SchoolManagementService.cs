using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Repositories.SchoolManagement;

namespace SchoolManagement.EntityFramework.Services
{
    public class SchoolManagementService : ISchoolManagementSevice
    {
        private readonly IDatabaseInfoProvider _databaseInfoProvider;
        private SchoolManagementContext schoolManagementContext;

        public SchoolManagementService()
        {
            _databaseInfoProvider = Ioc.Resolve<IDatabaseInfoProvider>();
            InitConnectionDatabase();
        }

        public UserRepository UserRepository { get; private set; }

        public GradeSheetRepository GradeSheetRepository { get; private set; }

        public CourseRepository CourseRepository { get; private set; }

        public ClassRepository ClassRepository { get; private set; }
        public TeacherRepository TeacherRepository { get; private set; }

        public StudentRepository StudentRepository { get; private set; }

        private void InitConnectionDatabase()
        {
            if (string.IsNullOrEmpty(_databaseInfoProvider.ServerInfor.ConnectionString))
            {
                //TODO
                return;
            }
            schoolManagementContext = new SchoolManagementContext(_databaseInfoProvider.ServerInfor.ConnectionString);
            UserRepository = new UserRepository(schoolManagementContext);
            GradeSheetRepository = new GradeSheetRepository(schoolManagementContext);
            CourseRepository = new CourseRepository(schoolManagementContext);
            ClassRepository = new ClassRepository(schoolManagementContext);
            TeacherRepository = new TeacherRepository(schoolManagementContext);
            StudentRepository = new StudentRepository(schoolManagementContext);

        }
    }
}