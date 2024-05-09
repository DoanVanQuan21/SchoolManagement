namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface ITeacherRepository<T> : IGenerateRepository<T> where T : class
    {
        Task<T?> GetTeacherByTeacherID(int teacherID);
        Task<T?> GetTeacherByUserID(int userID);
    }
}