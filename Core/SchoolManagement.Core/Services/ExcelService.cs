using ClosedXML.Excel;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SchoolManagement.Core.Services
{
    public class ExcelService : IExcelService
    {
        private readonly string _defaultNameWorkSheet = "Sheet1";
        private readonly int defaultColumn = 1;
        private readonly int defaultRow = 1;
        private XLWorkbook? workbook;
        private IXLWorksheet? worksheet;

        public async Task<bool> ExportGradeSheetsAsync<T>(ObservableCollection<T> datas, string filePath, string nameSheet, Func<int, Task<string>> getStudentName = null, Func<int, Task<string?>> getStudentCode = null)
        {
            if (datas == null || datas.Count <= 0)
            {
                return false;
            }
            workbook = new XLWorkbook();
            workbook.AddWorksheet(nameSheet);
            worksheet = workbook.Worksheets.Worksheet(nameSheet);
            var col = BuildHeader<T>(datas, worksheet);
            await Task.Delay(1000);
            var row = 2;
            foreach (var data in datas)
            {
                await BuildRowAsync(data, row++, worksheet, getStudentName, getStudentCode);
                await Task.Delay(100);
            }
            workbook.SaveAs(filePath);
            return true;
        }

        public async Task<ObservableCollection<GradeSheet>> ImportGradeSheetsAsync(string filePath, int classID, Func<string, Task<int>> getStudentID)
        {
            try
            {
                var gradeSheets = new ObservableCollection<GradeSheet>();
                workbook = new XLWorkbook(filePath);
                worksheet = workbook.Worksheet(1);
                var totalRow = worksheet.LastRowUsed().RowNumber();
                var totalCol = worksheet.LastColumnUsed().ColumnNumber();
                int row = defaultRow;
                int col = 3;
                var isHeaderOK = ValidateHeader(totalCol);
                if (!isHeaderOK)
                {
                    return new();
                }
                while (row < totalRow)
                {
                    worksheet.Cell(row, defaultColumn).Value.TryGetText(out var studentCode);
                    int studentID = await getStudentID(studentCode);
                    if (studentID == 0)
                    {
                        row++;
                        col = 3;
                        continue;
                    }
                    GradeSheet gradeSheet = new GradeSheet();
                    gradeSheet = (GradeSheet)GetRow<GradeSheet>(row, col, totalCol);

                    gradeSheet.StudentId = studentID;
                    gradeSheet.ClassId = classID;
                    gradeSheets.Add(gradeSheet);
                    row++;
                    col = 3;
                }
                return gradeSheets;
            }
            catch (Exception ex)
            {
                //TODO
                return new();
            }
        }

        private int BuildHeader<T>(ObservableCollection<T> datas, IXLWorksheet ws)
        {
            if (datas == null || datas.Count <= 0)
            {
                return 0;
            }
            var obj = datas.First();
            var props = GetPropertyInfos(obj);
            var row = 1;

            ws.Cell(row, 1).Value = "Mã sinh viên";
            var col = 2;
            if (props == null || props.Count <= 0)
            {
                return 0;
            }
            foreach (var prop in props)
            {
                ws.Cell(row, col).Value = PropertyHelper.GetDisplayName(prop);
                col++;
            }
            return col;
        }

        private async Task BuildRowAsync<T>(T obj, int row, IXLWorksheet ws, Func<int, Task<string>> getStudentName = null, Func<int, Task<string?>> getStudentCode = null)
        {
            var props = GetPropertyInfos(obj);
            int studentID = 0;
            var col = 2;
            if (props == null)
            {
                return;
            }
            foreach (var prop in props)
            {
                var isID = PropertyHelper.IsID(prop);
                var value = "";
                value = prop.GetValue(obj).ToString();
                if (isID)
                {
                    int.TryParse(prop.GetValue(obj).ToString(), out var id);
                    studentID = id;
                    value = await getStudentName(id);
                }
                ws.Cell(row, col).Value = value;
                col++;
            }
            ws.Cell(row, 1).Value = await getStudentCode(studentID);
        }

        private List<PropertyInfo> GetPropertyInfos(object obj)
        {
            return obj?.GetType().GetProperties().Where(p => PropertyHelper.IsHeaderExcel(p)).ToList();
        }

        private object GetRow<T>(int row, int col, int totalCol)
        {
            var obj = Activator.CreateInstance(typeof(T));
            var properties = obj.GetType()
                .GetProperties()
                .Where(p => PropertyHelper.IsHeaderExcel(p))
                .Where(p => !PropertyHelper.IsID(p)).ToList();
            int index = 0;
            while (col < totalCol)
            {
                worksheet.Cell(row, col).Value.TryGetText(out string value);
                _ = float.TryParse(value, out var result);

                properties[index++].SetValue(obj, result);
                col++;
            }
            return obj;
        }

        private bool ValidateHeader(int totalCol)
        {
            GradeSheet gradeSheet = new();
            var displayName = gradeSheet.GetType()
                .GetProperties()
                .Where(p => PropertyHelper.IsHeaderExcel(p))
                .Select(p => PropertyHelper.GetDisplayName(p)).ToList();
            int row = defaultRow;
            int col = 2;
            int index = 0;
            while (col < totalCol)
            {
                worksheet.Cell(row, col).Value.TryGetText(out var header);
                if (header != displayName[index])
                {
                    return false;
                }
                col++;
                index++;
            }
            return true;
        }
    }
}