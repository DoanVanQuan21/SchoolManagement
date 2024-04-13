using ActiproSoftware.UI.Avalonia.Themes;
using ActiproSoftware.UI.Avalonia.Themes.Generation;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.MainProject.Views;
using SchoolManagement.SettingAccount.Views;
using SchoolManagement.Shell.Helpers;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.ViewModels;
using SchoolManagement.Shell.Views;
using SchoolManagement.Shell.Views.SplashScreen;
using SchoolManagement.UI.Geometry;
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

            // Customize the theme definition
            if (ModernTheme.TryGetCurrent(out var modernTheme) && (modernTheme.Definition is not null))
            {
                modernTheme.Definition.UseAccentedSwitches = true;
                modernTheme.Definition.AccentColorRampName = Hue.Sky.ToString();
                modernTheme.RefreshResources();
            }
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            InitMenu();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterTypesHelper.RegisterTypes(containerRegistry);
            containerRegistry.RegisterDialog<SplashScreen, SplashScreenViewModel>();
            Ioc.AppContainer = containerRegistry.GetContainer();
            Ioc.ContainerRegistry = containerRegistry;
            Ioc.ContainerProvider = Container;
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

        private void InitMenu()
        {
            RootContext.AppMenus.Add(new AppMenu() { Label = "Trang chủ", Geometry = GeometryString.HomeGeometry, Type = typeof(DashboardView) });
            RootContext.AppMenus.Add(new AppMenu() { Label = "Cài đặt tài khoản", Geometry = GeometryString.UserSettingGeometry, Type = typeof(SettingAccountView) });
        }
    }
}