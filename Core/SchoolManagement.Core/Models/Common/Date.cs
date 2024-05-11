using Prism.Mvvm;

namespace SchoolManagement.Core.Models.Common
{
    public class Date : BindableBase
    {
        private int day = 1;
        private int month = 1;
        private int year;

        public int Day { get => day; set => SetProperty(ref day, value); }
        public int Month { get => month; set => SetProperty(ref month, value); }
        public int Year { get => year; set => SetProperty(ref year, value); }
    }
}