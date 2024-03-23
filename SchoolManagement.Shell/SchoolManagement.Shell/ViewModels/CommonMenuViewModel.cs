using Prism.Commands;
using SchoolManagement.Core.avalonia;
using System;
using System.Windows.Input;

namespace SchoolManagement.Shell.ViewModels
{
    internal class CommonMenuViewModel : BaseRegionViewModel
    {
        public override string Title => throw new System.NotImplementedException();
        public ICommand SearchTextCommand { get; set; }
        public CommonMenuViewModel()
        {
            
        }
        protected override void RegisterCommand()
        {
            SearchTextCommand = new DelegateCommand<object>(OnSearch);
            base.RegisterCommand();
        }

        private void OnSearch(object obj)
        {
            var t = "";
        }
    }
}