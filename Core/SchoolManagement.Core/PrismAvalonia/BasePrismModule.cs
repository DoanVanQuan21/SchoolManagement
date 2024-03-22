using Prism.Events;
using Prism.Ioc;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;

namespace SchoolManagement.Core.PrismAvalonia
{
    public abstract class BasePrismModule : ICustomModule
    {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly IAppManager _appManager;
        public BasePrismModule()
        {
            _eventAggregator = Ioc.Resolve<IEventAggregator>();
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public abstract string ModuleName { get; }

        public abstract void Dispose();

        public abstract void Init();

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void Register();

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        private void OnExit()
        {
            Dispose();
        }
    }
}