using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Notification;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Shell.Services;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.ViewModels;
using SchoolManagement.Shell.Views;
using SchoolManagement.Shell.Views.SplashScreen;
using System;
using System.Diagnostics;
using System.Linq;

namespace SchoolManagement.Shell
{
    public partial class App : PrismApplication
    {
        public static bool IsSingleViewLifetime =>
       Environment.GetCommandLineArgs()
           .Any(a => a == "--fbdev" || a == "--drm");

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder
                .Configure<App>();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        protected override AvaloniaObject CreateShell()
        {
            try
            {
                var startup = Ioc.Resolve<IStartUp>();
                startup.UseProject().StartUp();

                return InitViewFollowPlatformAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        private AvaloniaObject InitViewFollowPlatformAsync()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                RootContext.ApplicationLifetime = ApplicationLifetime;
                
                return Ioc.Resolve<MainDesktopView>();
            }
            return Ioc.Resolve<MainMobileView>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStartUp, StartUp>();
            containerRegistry.RegisterSingleton<IAppManager, AppManager>();
            containerRegistry.RegisterSingleton<INotificationMessageManager, NotificationMessageManager>();
            containerRegistry.RegisterDialog<SplashScreen,SplashScreenViewModel>();
            Ioc.AppContainer = containerRegistry.GetContainer();
            Ioc.ContainerRegistry = containerRegistry;
            Ioc.ContainerProvider = Container;
        }
    }
}