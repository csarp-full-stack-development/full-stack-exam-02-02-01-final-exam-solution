using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.HttpService.Services
{
    public interface IHeadTeacherService : IBaseService<HeadTeacher>
    {

        public Task<int> GetNumberOfHeadTeacher(bool isAssistant);
    }
}
