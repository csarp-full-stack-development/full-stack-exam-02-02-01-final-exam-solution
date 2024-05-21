using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public class HeadTeacherViewModel : BaseViewModel
    {
        private readonly IHeadTeacherService? _headTeacherService;

        public HeadTeacherViewModel()
        {            
        }
        public HeadTeacherViewModel(IHeadTeacherService headTeacherService)
        {
            _headTeacherService = headTeacherService;
        }

        public async override Task InitializeAsync()
        {
            await base.InitializeAsync();
        }
    }
}
