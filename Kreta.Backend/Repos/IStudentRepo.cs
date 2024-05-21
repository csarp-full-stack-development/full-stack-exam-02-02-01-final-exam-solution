using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Parameters;

namespace Kreta.Backend.Repos
{
    public interface IStudentRepo : IRepositoryBase<Student>
    {
        public IQueryable<Student> SelectAllIncluded();

        public IQueryable<Student> SelectStudentsByEducationId(Guid educationID);

        public IQueryable<Student> SelectStudentsWithoutEducationLevel();
        public int GetNumberOfGener(bool isWoman);
        public IQueryable<Student> GetStudents(StudentQueryParameters parameters);
    }
}
