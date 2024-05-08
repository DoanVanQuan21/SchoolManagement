namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IStudentRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetStudent(int studentID);

        T? GetStudent(string studentCode);

        Task<T?> GetStudentByUserID(int userID);
    }
}