using Prism.Ioc;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.PrismAvalonia;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Services;

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