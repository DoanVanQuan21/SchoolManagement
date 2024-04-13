using Prism.Ioc;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.Core.PrismAvalonia;
using SchoolManagement.MainProject.Views;
using SchoolManagement.SettingAccount.Views;
using SchoolManagement.UI.Geometry;

namespace SchoolManagement.MainProject
{
    public class MainProjectModule : BasePrismModule
    {
        public override string ModuleName => DllName.MainProjectModule;

        public override void Dispose()
        {
            //TODO
        }

        public override void Init()
        {
            //TODO
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            //TODO
            Init();
        }

        public override void Register()
        {
            //TODO
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //TODO
        }
    }
}