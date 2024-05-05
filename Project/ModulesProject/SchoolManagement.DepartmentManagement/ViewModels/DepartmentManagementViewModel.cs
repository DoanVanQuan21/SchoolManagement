﻿using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.DepartmentManagement.ViewModels
{
    internal class DepartmentManagementViewModel : BaseRegionViewModel
    {
        private Department selectedDepartment;

        public override string Title => "Quản lý phòng ban";

        public override User User { get; protected set; }

        public DepartmentManagementViewModel()
        {
            User = RootContext.CurrentUser;
        }

        public ObservableCollection<Department> Coureses { get; set; }
        public Department SelectedDepartment { get => selectedDepartment; set => SetProperty(ref selectedDepartment, value); }
    }
}