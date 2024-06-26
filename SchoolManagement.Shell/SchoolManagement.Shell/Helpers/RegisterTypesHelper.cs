﻿using Prism.Ioc;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Managers;
using SchoolManagement.Core.Models;
using SchoolManagement.Core.Services;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.EntityFramework.Services;
using SchoolManagement.GradeSheetManagement.Views.Dialogs;
using SchoolManagement.Shell.Services;
using SchoolManagement.Shell.Services.Contracts;
using SchoolManagement.Shell.ViewModels;

namespace SchoolManagement.Shell.Helpers
{
    public class RegisterTypesHelper
    {
        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterTypesCommon(containerRegistry);
            RegisterTypesModuleEntityFramework(containerRegistry);
            RegisterTypesModuleMainProject(containerRegistry);
            RegisterTypesModuleAuth(containerRegistry);
            RegisterTypesModuleDatabase(containerRegistry);
            RegisterDialog(containerRegistry);
        }

        public static void RegisterTypesCommon(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStartUp, StartUp>();
            containerRegistry.RegisterSingleton<IAppManager, AppManager>();
            containerRegistry.RegisterSingleton<IExcelService, ExcelService>();
            containerRegistry.RegisterSingleton<IDatabaseInfoProvider, DatabaseInfoProvider>();
            containerRegistry.RegisterSingleton<INotificationManager, NotificationManager>();
            containerRegistry.RegisterSingleton<IBlobContainerService, BlobContainerService>();
            containerRegistry.RegisterSingleton<MainViewModel>();
            containerRegistry.RegisterSingleton<MainContentViewModel>();
            containerRegistry.RegisterSingleton<CommonMenuViewModel>();
        }

        public static void RegisterTypesModuleAuth(IContainerRegistry containerRegistry)
        {
        }

        public static void RegisterTypesModuleDatabase(IContainerRegistry containerRegistry)
        {
        }

        public static void RegisterTypesModuleEntityFramework(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISchoolManagementSevice, SchoolManagementService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IGradeSheetService, GradeSheetService>();
            containerRegistry.RegisterSingleton<IDepartmentService, DepartmentService>();
            containerRegistry.RegisterSingleton<IEducationProgramService, EducationProgramService>();
            containerRegistry.RegisterSingleton<ISubjectService, SubjectService>();
            containerRegistry.RegisterSingleton<ICourseService, CourseService>();
            containerRegistry.RegisterSingleton<IClassService, ClassService>();
            containerRegistry.RegisterSingleton<ITeacherService, TeacherService>();
            containerRegistry.RegisterSingleton<IStudentService, StudentService>();
            containerRegistry.RegisterSingleton<IEditGradeSheetFormService, EditGradeSheetFormService>();
        }

        public static void RegisterTypesModuleMainProject(IContainerRegistry containerRegistry)
        {
        }

        public static void RegisterDialog(IContainerRegistry containerRegistry)
        { 
            containerRegistry.RegisterDialog<EditGradeSheetView>();
        }
    }
}