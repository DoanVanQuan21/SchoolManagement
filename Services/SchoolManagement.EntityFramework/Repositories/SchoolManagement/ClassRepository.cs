using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class ClassRepository : GenerateRepository<Class>, IClassRepository<Class>
    {
        private ObservableCollection<Class> _classesOfTeacher;

        public ClassRepository(SchoolManagementContext context) : base(context)
        {
            _classesOfTeacher = new();
        }

        public Task<bool> EditClass(Class _class)
        {
            return Task.Factory.StartNew(() =>
            {
                var c = _context.Classes.FirstOrDefault(i => i.ClassId == _class.ClassId);
                if (c == null)
                {
                    return false;
                }
                c.ClassName = _class.ClassName;
                c.NumberOfStudent = _class.NumberOfStudent;
                return UpdateEntity(c);
            });
        }

        public Task<bool> DeleteClass(int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                var _class = FirstOrDefault(c => c.ClassId == classID);
                if (_class == null)
                {
                    return false;
                }
                _context.Classes.Remove(_class);
                _context.SaveChanges();
                return true;
            });
        }

        public ObservableCollection<Class> GetAllClassesByID(IList<int> ids)
        {
            _classesOfTeacher.Clear();
            if (ids == null || ids.Count == 0) { return _classesOfTeacher; }
            var classes = new ObservableCollection<Class>();
            foreach (var id in ids)
            {
                var c = GetClassByID(id);
                if (c == null)
                {
                    continue;
                }
                classes.Add(c);
            }
            _classesOfTeacher.AddRange(classes);
            return _classesOfTeacher;
        }

        public Class GetClassByID(int classID)
        {
            return FirstOrDefault(item => item.ClassId == classID);
        }
    }
}