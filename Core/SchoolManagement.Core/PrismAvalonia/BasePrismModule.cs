using Prism.Events;
using Prism.Ioc;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Events;

namespace SchoolManagement.Core.PrismAvalonia
{
    public abstract class BasePrismModule : ICustomModule
    {
        protected readonly IAppManager _appManager;
        protected readonly IEventAggregator _eventAggregator;

        public BasePrismModule()
        {
            _eventAggregator = Ioc.Resolve<IEventAggregator>();
            _appManager = Ioc.Resolve<IAppManager>();
            _eventAggregator.GetEvent<LogoutSuccessEvent>().Subscribe(OnLogoutSuccess);
        }

        public abstract string ModuleName { get; }

        public abstract void Dispose();

        public abstract void Init();

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void Register();

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        private void OnLogoutSuccess()
        {
            Dispose();

        }
    }
}