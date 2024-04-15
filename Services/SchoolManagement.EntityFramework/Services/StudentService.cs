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
    public class StudentService : BaseService, IStudentService
    {
        public StudentService() : base()
        {
        }
        public Student? GetStudent(int studentID)
        {
            return _schoolManagementSevice.StudentRepository.GetStudent(studentID);
        }
    }
}
