using Avalonia.Controls;
using Prism.DryIoc;
using Prism.Ioc;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Shell.Services;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.Views;
using System;
using System.Diagnostics;

namespace SchoolManagement.Shell
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            try
            {
                var startup = Ioc.Resolve<IStartUp>();
                startup.UseProject().StartUp();
                return Ioc.ContainerProvider.Resolve<MainWindow>();
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

            Ioc.AppContainer = containerRegistry.GetContainer();
            Ioc.ContainerRegistry = containerRegistry;
            Ioc.ContainerProvider = Container;
        }
    }
}