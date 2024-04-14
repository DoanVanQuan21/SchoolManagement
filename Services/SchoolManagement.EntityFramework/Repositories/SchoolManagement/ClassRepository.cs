using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class ClassRepository : GenerateRepository<Class>, IClassRepository<Class>
    {
        ObservableCollection<Class> _classesOfTeacher;
        public ClassRepository(SchoolManagementContext context) : base(context)
        {
            _classesOfTeacher = new();
        }

        public ObservableCollection<Class> GetAllClassesByID(IList<int> ids)
        {
            if(ids == null || ids.Count == 0) { return _classesOfTeacher; }
            _classesOfTeacher.Clear();
            var classes = new ObservableCollection<Class>();
            foreach (var id in ids)
            {
                var c = GetClassByID(id);
                if(c == null)
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