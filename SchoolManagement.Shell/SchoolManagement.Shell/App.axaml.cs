using ActiproSoftware.UI.Avalonia.Themes;
using ActiproSoftware.UI.Avalonia.Themes.Generation;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;
using SchoolManagement.AccountManagement.Views;
using SchoolManagement.ClassManagement.Views;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.Common;
using SchoolManagement.CourseManagement.Views;
using SchoolManagement.GradeSheetManagement.Views;
using SchoolManagement.MainProject.Views;
using SchoolManagement.SettingAccount.Views;
using SchoolManagement.Shell.Helpers;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.Views;
using SchoolManagement.StudentManagement.Views;
using SchoolManagement.TeacherManagement.Views;
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
            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("Home_Label"), Geometry = GeometryString.HomeGeometry, Type = typeof(DashboardView), Roles = "admin,teacher,student" });
            RootContext.MenuLabels.Add(typeof(DashboardView), "Home_Label");
            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("AccountSettings_Label"), Geometry = GeometryString.UserGeometry, Type = typeof(SettingAccountView), Roles = "admin,teacher,student" });
            RootContext.MenuLabels.Add(typeof(SettingAccountView), "AccountSettings_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("GradeManagement_Label"), Geometry = GeometryString.ClipboardTextEditorGeometry, Type = typeof(GradeSheetManagementView), Roles = "teacher" });
            RootContext.MenuLabels.Add(typeof(GradeSheetManagementView), "GradeManagement_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("ViewComponentGrades_Label"), Geometry = GeometryString.ClipboardDataBarGeometry, Type = typeof(ComponentGradeSheetView), Roles = "student" });
            RootContext.MenuLabels.Add(typeof(ComponentGradeSheetView), "ViewComponentGrades_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("ViewFinalGrades_Label"), Geometry = GeometryString.DataBarVerticalAscendingGeometry, Type = typeof(SemesterAverageView), Roles = "student" });
            RootContext.MenuLabels.Add(typeof(SemesterAverageView), "ViewFinalGrades_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("AccountManagement_Label"), Geometry = GeometryString.PeopleTeamGeometry, Type = typeof(AccountManagementView), Roles = "admin" });
            RootContext.MenuLabels.Add(typeof(AccountManagementView), "AccountManagement_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("ClassManagement_Label"), Geometry = GeometryString.BuildingPeopleGeometry, Type = typeof(ClassManagementView), Roles = "admin" });
            RootContext.MenuLabels.Add(typeof(ClassManagementView), "ClassManagement_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("CourseManagement_Label"), Geometry = GeometryString.BookOpenGeometry, Type = typeof(CourseManagementView), Roles = "admin" });
            RootContext.MenuLabels.Add(typeof(CourseManagementView), "CourseManagement_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("StudentManagement_Label"), Geometry = GeometryString.AccountsManagerGeometry, Type = typeof(StudentManagementView), Roles = "admin" });
            RootContext.MenuLabels.Add(typeof(StudentManagementView), "StudentManagement_Label");

            RootContext.DesktopAppMenus.Add(new AppMenu() { Label = Util.GetResourseString("TeacherManagement_Label"), Geometry = GeometryString.TeacherGeometry, Type = typeof(TeacherManagementView), Roles = "admin" });
            RootContext.MenuLabels.Add(typeof(TeacherManagementView), "TeacherManagement_Label");
        }
    }
}