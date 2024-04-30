using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IRepositories;
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

        public Task<ObservableCollection<GradeSheet>> GetAllGradeSheetAsync(int subjectID, int classID)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    if (_context.GradeSheets.Any() == false)
                    {
                        return _grades;
                    }
                    _grades.Clear();
                    var grades = _context.GradeSheets.Where(item => item.ClassId == classID && item.SubjectId == subjectID).ToList();
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
            });
        }

        public GradeSheet? GetById(int subjectID, int classID)
        {
            return FirstOrDefault(item => item.ClassId == classID && item.SubjectId == subjectID);
        }

        public Task<bool> Update(GradeSheet entity)
        {
            return Task.Factory.StartNew(() =>
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
                gradeSheet.SemesterAverage = ComputeSemesterAverage(gradeSheet);
                _context.SaveChanges();
                return true;
            });
        }

        public Task<bool> UpdateByClassIDAndSubjectID(GradeSheet entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var gradeSheet = FirstOrDefault(item => item.ClassId == entity.ClassId && item.SubjectId == entity.SubjectId);
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
                gradeSheet.SemesterAverage = ComputeSemesterAverage(gradeSheet);
                _context.SaveChanges();
                return true;
            });
        }

        public Task<bool> UpdateOrAddRange(ObservableCollection<GradeSheet> gradeSheets)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    foreach (var grade in gradeSheets)
                    {
                        var gs = FirstOrDefault(g => g.ClassId == grade.ClassId && g.StudentId == grade.StudentId);
                        if (gs == null)
                        {
                            Add(grade);
                            Task.Delay(100);
                            continue;
                        }
                        UpdateByClassIDAndSubjectID(grade);
                        Task.Delay(100);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        private float? ComputeSemesterAverage(GradeSheet gradeSheet)
        {
            return (gradeSheet.FirstRegularScore + gradeSheet.SecondRegularScore + gradeSheet.ThirdRegularScore
            + gradeSheet.FourRegularScore + gradeSheet.MidtermScore * 2 + gradeSheet.FinalScore * 3) / 9;
        }
    }
}