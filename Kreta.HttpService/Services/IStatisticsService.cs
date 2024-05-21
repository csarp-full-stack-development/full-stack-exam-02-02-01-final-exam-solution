using Kreta.Shared.Models;

namespace Kreta.HttpService.Services
{
    public interface IStatisticsService
    {
        public Task<int> GetNumberOfParents();
        public Task<GenderNumberOfParent> GetGenderNumberOfParent();
        public Task<List<NumberOfStudentByClass>> GetNumberOfStudentByClasses();
    }
}
