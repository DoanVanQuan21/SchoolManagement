using Prism.Mvvm;

namespace SchoolManagement.Core.Models.Common
{
    public class SemesterAverage : BindableBase
    {
        private string semester;
        private int totalSubject;
        private double average;
        private string rank;

        public string Semester { get => semester; set => SetProperty(ref semester, value); }
        public int TotalSubject { get => totalSubject; set => SetProperty(ref totalSubject, value); }
        public double Average { get => average; set { SetProperty(ref average, value); SetRanked(); } }
        public string Rank { get => rank; set => SetProperty(ref rank, value); }
        public SemesterAverage()
        {
            
        }
        public SemesterAverage(int totalSubject, double aver)
        {
            TotalSubject = totalSubject;
            Average = aver;
            SetRanked();
        }
        
        public static List<SemesterAverage> SemesterAverages = new() { 
            new() { Semester = "Kỳ 1" }, 
            new() { Semester = "Kỳ 2" },
            new() { Semester = "Cuối năm" }
        };
        private void SetRanked()
        {
            Rank = GetRanked();
        }
        private string GetRanked()
        {
            try
            {
                if (Average >= 8.5)
                {
                    return Constants.Ranked.Excellent;
                }
                if (Average >= 7)
                {
                    return Constants.Ranked.Good;
                }
                if (Average >= 5.5)
                {
                    return Constants.Ranked.Average;
                }
                if (Average >= 4.0)
                {
                    return Constants.Ranked.BelowAverage;
                }
                return Constants.Ranked.Bad;
            }
            catch (Exception)
            {
                return Constants.Ranked.Bad;
            }
        }
    }
}