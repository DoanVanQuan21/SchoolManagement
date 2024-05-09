namespace SchoolManagement.EntityFramework.Contracts.IRepositories
{
    public interface IGradeSheetRepository<T> : IGenerateRepository<T> where T : class
    {
        Task<bool> UnLock(int gradeSheetID);
    }
}