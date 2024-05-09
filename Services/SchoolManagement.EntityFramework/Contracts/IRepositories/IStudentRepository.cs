namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IStudentRepository<T> : IGenerateRepository<T> where T : class
    {
        
    }
}