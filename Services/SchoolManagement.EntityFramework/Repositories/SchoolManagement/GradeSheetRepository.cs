using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts;
using System.Collections.ObjectModel;

namespace SchoolManagement.EntityFramework.Repositories.SchoolManagement
{
    public class GradeSheetRepository : GenerateRepository<GradeSheet>, IGradeSheetRepository<GradeSheet>
    {
        private readonly ObservableCollection<GradeSheet> _grades;

        public GradeSheetRepository(SchoolManagementContext context) : base(context)
        {
            _grades = new();
        }

        public bool Delete(int subjectID, int classID)
        {
            var gradeSheet = GetById(subjectID, classID);
            if (gradeSheet == null)
            {
                return false;
            }
            _context.Remove(gradeSheet);
            _context.SaveChanges();
            return true;
        }

        public ObservableCollection<GradeSheet> GetAllGradeSheet(int subjectID, int classID)
        {
            try
            {
                if (_context.GradeSheets.Any() == false)
                {
                    return _grades;
                }
                _grades.Clear();
                var grades = _context.GradeSheets.Where(item => item.ClassId == classID && item.SubjectId == subjectID).ToList() ;
                if (grades == null)
                {
                    return _grades;
                }
                _grades.AddRange(grades);
                return _grades;
            }
            catch (Exception)
            {
                return _grades;
            }
        }

        public GradeSheet? GetById(int subjectID, int classID)
        {
            return FirstOrDefault(item => item.ClassId == classID && item.SubjectId == subjectID);
        }

        public bool Update(GradeSheet entity)
        {
            var gradeSheet = FirstOrDefault(item => item.GradeSheetId == entity.GradeSheetId);
            if (gradeSheet == null)
            {
                return false;
            }
            gradeSheet.FirstRegularScore = entity.FirstRegularScore;
            gradeSheet.SecondRegularScore = entity.SecondRegularScore;
            gradeSheet.ThirdRegularScore = entity.ThirdRegularScore;
            gradeSheet.FourRegularScore = entity.FourRegularScore;
            gradeSheet.MidtermScore = entity.MidtermScore;
            gradeSheet.FinalScore = entity.FinalScore;
            _context.SaveChanges();
            return true;
        }
    }
}