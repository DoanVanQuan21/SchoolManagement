﻿using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class TeacherRepository : GenerateRepository<Teacher>, ITeacherRepository<Teacher>
    {
        public TeacherRepository(SchoolManagementContext context) : base(context)
        {
        }

        public Teacher? GetTeacherInfo(int userID)
        {
            return FirstOrDefault(item => item.UserId == userID);
        }
    }
}