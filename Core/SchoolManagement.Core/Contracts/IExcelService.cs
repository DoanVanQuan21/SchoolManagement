using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Contracts
{
    public interface IExcelService
    {
        Task<bool> ExportGradeSheetAsync<T>(ObservableCollection<T> datas, string filePath, string nameSheet, Func<int, Task<string>> getStudentName = null);
    }
}