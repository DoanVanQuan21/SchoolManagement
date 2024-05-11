namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ICourseRepository<T> : IGenerateRepository<T> where T : class
    {
    }
}