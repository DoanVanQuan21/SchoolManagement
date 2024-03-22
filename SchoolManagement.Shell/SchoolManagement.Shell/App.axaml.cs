using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Models;
using SchoolManagement.Shell.Services;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.Views;
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
                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    return Ioc.Resolve<MainWindow>();
                }
                return Ioc.Resolve<MainView>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStartUp, StartUp>();
            containerRegistry.RegisterSingleton<IAppManager, AppManager>();
            containerRegistry.Register<MainWindow>();
            Ioc.AppContainer = containerRegistry.GetContainer();
            Ioc.ContainerRegistry = containerRegistry;
            Ioc.ContainerProvider = Container;
        }
    }
}