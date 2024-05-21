using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class StudentRepo<TDbContext> : RepositoryBase<TDbContext, Student>, IStudentRepo
        where TDbContext : DbContext
    {
        public StudentRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<Student> SelectAllIncluded()
        {
            return FindAll().Include(student => student.EducationLevel);
        }

        public IQueryable<Student> SelectStudentsByEducationId(Guid educationID)
        {
            return FindAll().Where(student => student.EducationLevelId == educationID);
        }

        public IQueryable<Student> SelectStudentsWithoutEducationLevel()
        {
            return FindAll().Where(student =>
                student.EducationLevelId == null ||
                student.EducationLevelId == Guid.Empty);
        }

        public int GetNumberOfGener(bool isWoman)
        {
            return FindByCondition(teacher => teacher.IsWoman == isWoman).Count();
        }

        public IQueryable<Student> GetStudents(StudentQueryParameters parameters)
        {
            IQueryable<Student> filteredStudent = FindByCondition(student => student.BirthDay.Year >= parameters.MinYearOfBirth
                                           && student.BirthDay.Year <= parameters.MaxYearOfBirth
                                  )
                                  .OrderBy(student => student.LastName)
                                  .ThenBy(student =>student.FirstName);

            SearchByStudentName(ref filteredStudent, parameters.Name);
            if (parameters.HaveGender)
            {
                FilteringByGender(ref filteredStudent, parameters.IsWooman);
            }
            return filteredStudent;

        }

        private void SearchByStudentName(ref IQueryable<Student> students, string studentName)
        {
            if (!students.Any() || string.IsNullOrEmpty(studentName))
            {
                return;
            }
            students = students.Where(student => student.LastName.ToLower().Contains(studentName.Trim().ToLower()) ||
                                                 student.FirstName.ToLower().Contains(studentName.Trim().ToLower()));
        }

        private void FilteringByGender(ref IQueryable<Student> students, bool isWooman)
        {
            students = students.Where(student => student.IsWoman == isWooman);
        }

    }
}
