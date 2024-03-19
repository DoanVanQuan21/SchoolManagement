using Prism.Ioc;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.PrismAvalonia;

namespace SchoolManagement.Database
{
    public class DatabaseModule : BasePrismModule
    {
        public override string ModuleName => DllName.DatabaseModule;

        public override void Dispose()
        {
        }

        public override void Init()
        {
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public override void Register()
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}