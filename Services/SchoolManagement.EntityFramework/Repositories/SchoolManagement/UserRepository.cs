using SchoolManagement.Core.Models.SchoolManagement;
using SchoolManagement.EntityFramework.Contracts;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class UserRepository : GenerateRepository<User>, IUserRepository<User>
    {
        public UserRepository(SchoolManagementContext context) : base(context)
        {
        }

        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(item => item.UserId == id);
        }

        public bool Update(User entity)
        {
            var user = GetById(entity.UserId);
            if (user == null)
            {
                return false;
            }
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.PhoneNumber = entity.PhoneNumber;
            user.DateOfBirth = entity.DateOfBirth;
            user.Address = entity.Address;
            _context.SaveChanges();
            return true;
        }
    }
}