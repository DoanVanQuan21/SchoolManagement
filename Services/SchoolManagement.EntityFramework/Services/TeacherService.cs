using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using SchoolManagement.EntityFramework.Contracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.EntityFramework.Services
{
    public class TeacherService :BaseService, ITeacherService
    {
        public TeacherService() : base()
        {
        }
        public Teacher? GetTeacherInfo(int userID)
        {
            
            return _schoolManagementSevice.TeacherRepository.GetTeacherInfo(userID);
        }
    }
}
