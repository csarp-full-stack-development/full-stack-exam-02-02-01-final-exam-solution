using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Parameters;

namespace Kreta.HttpService.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        public Task<int> GetNumberOfGender(bool isWoman);
        public Task<List<Student>> GetStudentsByEducationId(Guid id);
        Task<List<Student>> GetStudentsWithoutEducationLevel();
        public Task<List<Student>> SelectAllIncludedAsync();
        public Task<List<Student>> SearchAndFilterStudents(StudentQueryParameters studentQueryParameters);
    }
}
