﻿using Prism.Ioc;
using SchoolManagement.Core.Contants;
using SchoolManagement.Core.PrismAvalonia;

namespace SchoolManagement.Database
{
    public class DatabaseModule : BasePrismModule
    {
        public override string ModuleName => DllName.DatabaseModule;

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