namespace SchoolManagement.EntityFramework.Contracts
{
    public interface ITeacherRepository <T> : IGenerateRepository<T> where T : class
    {
        T? GetTeacherInfo(int userID);
    }
}