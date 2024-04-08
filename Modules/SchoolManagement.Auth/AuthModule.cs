using Prism.Ioc;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.PrismAvalonia;

namespace SchoolManagement.Auth
{
    public class AuthModule : BasePrismModule
    {
        public override string ModuleName => DllName.AuthModule;

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
            var t= 0;
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