namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IUserRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetById(int id);
        bool Update(T entity);
        bool Delete(int id);
        bool UpdateStatus(T entity);
        string GetFullname(int id);
    }
}