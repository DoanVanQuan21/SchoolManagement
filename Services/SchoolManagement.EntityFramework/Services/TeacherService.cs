using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.EntityFramework.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ISchoolManagementSevice _schoolManagementSevice;
        public TeacherService()
        {
            _schoolManagementSevice = Ioc.Resolve<ISchoolManagementSevice>();
        }
        public Teacher? GetTeacherInfo(int userID)
        {
            
            return _schoolManagementSevice.TeacherRepository.GetTeacherInfo(userID);
        }
    }
}
