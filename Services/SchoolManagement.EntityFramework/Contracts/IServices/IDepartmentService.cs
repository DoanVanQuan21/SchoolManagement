﻿using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts.IServices
{
    public interface IDepartmentService
    {
        Task<ObservableCollection<Department>> GetDepartments();
    }
}