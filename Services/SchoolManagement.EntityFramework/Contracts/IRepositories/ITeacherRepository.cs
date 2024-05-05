namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ITeacherRepository<T> : IGenerateRepository<T> where T : class
    {
        T? GetTeacherInfo(int userID);
        Task<T?> GetTeacherByTeacherID(int teacherID);
    }
}