using SchoolManagement.Core.Models.Common;
using System.Collections.ObjectModel;

namespace SchoolManagement.Core.Helpers
{
    public class DateHelper
    {
        public static Task InitDates(int starYear, int endYear, ObservableCollection<Date> dates)
        {
            return Task.Factory.StartNew(() => {
                dates ??= new();
                dates.Clear();
                for (int i = starYear; i <= endYear; i++)
                {
                    dates.Add(new()
                    {
                        Year = i,
                    });
                }
            });
        }
    }
}