using ClosedXML.Excel;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Helpers;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SchoolManagement.Core.Services
{
    public class ExcelService : IExcelService
    {
        private readonly string _defaultNameWorkSheet = "Sheet1";
        private XLWorkbook? workbook;
        private IXLWorksheet? worksheet;

        public async Task<bool> ExportGradeSheetAsync<T>(ObservableCollection<T> datas, string filePath, string nameSheet, Func<int, Task<string>> getStudentName = null)
        {
            if (datas == null || datas.Count <= 0)
            {
                return false;
            }
            workbook = new XLWorkbook();
            workbook.AddWorksheet(nameSheet);
            worksheet = workbook.Worksheets.Worksheet(nameSheet);
            var col = BuildHeader<T>(datas, worksheet);
            var row = 2;
            foreach (var data in datas)
            {
                await BuildRowAsync(data, row++, worksheet, getStudentName);
            }
            workbook.SaveAs(filePath);
            return true;
        }

        private async Task BuildRowAsync<T>(T obj, int row, IXLWorksheet ws, Func<int, Task<string>> getStudentName = null)
        {
            var props = GetPropertyInfos(obj);
            var col = 1;
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
                    value = await getStudentName(id);
                }
                ws.Cell(row, col).Value = value;
                col++;
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
            var col = 1;
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

        private List<PropertyInfo> GetPropertyInfos(object obj)
        {
            return obj?.GetType().GetProperties().Where(p => PropertyHelper.IsHeaderExcel(p)).ToList();
        }
    }
}