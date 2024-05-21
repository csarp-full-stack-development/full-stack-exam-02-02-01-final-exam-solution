using Kreta.Shared.Models;
using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class HeadTeacherRepo<TDbContext> : RepositoryBase<TDbContext, HeadTeacher>, IHeadTeacherRepo
                where TDbContext : DbContext
    {
        public HeadTeacherRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public int GetNumberOfHeadTeacher(bool isAssistant)
        {
            return FindByCondition(teacher => teacher.IsAssistant==isAssistant).Count();
        }
    }
}
