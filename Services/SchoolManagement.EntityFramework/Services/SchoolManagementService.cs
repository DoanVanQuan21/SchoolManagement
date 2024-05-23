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
        private CancellationTokenSource _cancellationTokenSource;

        public SchoolManagementService()
        {
            _databaseInfoProvider = Ioc.Resolve<IDatabaseInfoProvider>();
            _cancellationTokenSource = new();
            InitConnectionDatabase();
        }

        public UserRepository UserRepository { get; private set; }

        public GradeSheetRepository GradeSheetRepository { get; private set; }

        public CourseRepository CourseRepository { get; private set; }

        public ClassRepository ClassRepository { get; private set; }
        public TeacherRepository TeacherRepository { get; private set; }

        public StudentRepository StudentRepository { get; private set; }
        public SubjectRepository SubjectRepository { get; private set; }
        public EditGradeSheetFormRepository EditGradeSheetFormRepository { get; private set; }
        public StudentAssignmentRepository StudentAssignmentRepository { get; private set; }
        public DepartmentRepository DepartmentRepository { get; private set; }
        public EducationProgramRepository EducationProgramRepository { get; private set; }

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
            SubjectRepository = new SubjectRepository(schoolManagementContext);
            EditGradeSheetFormRepository = new EditGradeSheetFormRepository(schoolManagementContext);
            StudentAssignmentRepository = new StudentAssignmentRepository(schoolManagementContext);
            DepartmentRepository = new DepartmentRepository(schoolManagementContext);
            EducationProgramRepository = new EducationProgramRepository(schoolManagementContext);
        }

        public void Refresh()
        {
            if (string.IsNullOrEmpty(_databaseInfoProvider.ServerInfor.ConnectionString))
            {
                //TODO
                return;
            }
            schoolManagementContext = new SchoolManagementContext(_databaseInfoProvider.ServerInfor.ConnectionString);
            UserRepository.RefreshContext(schoolManagementContext);
            GradeSheetRepository.RefreshContext(schoolManagementContext);
            CourseRepository.RefreshContext(schoolManagementContext);
            ClassRepository.RefreshContext(schoolManagementContext);
            TeacherRepository.RefreshContext(schoolManagementContext);
            StudentRepository.RefreshContext(schoolManagementContext);
            SubjectRepository.RefreshContext(schoolManagementContext);
            EditGradeSheetFormRepository.RefreshContext(schoolManagementContext);
            StudentAssignmentRepository.RefreshContext(schoolManagementContext);
            DepartmentRepository.RefreshContext(schoolManagementContext);
            EducationProgramRepository.RefreshContext(schoolManagementContext);
        }

        private void InitConnection()
        {
            Task.Factory.StartNew(async () =>
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Refresh();
                    await Task.Delay(3000);
                }
            }, _cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}