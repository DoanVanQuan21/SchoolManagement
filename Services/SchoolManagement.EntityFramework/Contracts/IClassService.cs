﻿using SchoolManagement.Core.Models.SchoolManagements;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IClassService
    {
        Class GetClassByID(int classID);

        ObservableCollection<Class> GetAllClassesByID(IList<int> ids);
    }
}