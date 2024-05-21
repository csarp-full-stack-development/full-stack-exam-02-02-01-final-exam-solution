using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Backend.Repos
{
    public interface IHeadTeacherRepo : IRepositoryBase<HeadTeacher>
    {
        public int GetNumberOfHeadTeacher(bool isAssistant);
    }
}
