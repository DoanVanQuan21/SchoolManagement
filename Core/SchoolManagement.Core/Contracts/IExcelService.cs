using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Contracts
{
    public interface IExcelService
    {
        Task<bool> ExportGradeSheetsAsync<T>(ObservableCollection<T> datas, string filePath, string nameSheet, Func<int, Task<string>> getStudentName = null, Func<int, Task<string?>> getStudentCode = null);

        Task<ObservableCollection<GradeSheet>> ImportGradeSheetsAsync(string filePath, int classID, Func<string, Task<int>> getStudentID);
    }
}