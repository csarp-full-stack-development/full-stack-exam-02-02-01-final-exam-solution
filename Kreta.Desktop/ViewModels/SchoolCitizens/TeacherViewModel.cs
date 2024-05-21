using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class TeacherViewModel : BaseViewModel
    {
        private readonly ITeacherService? _teacherService;
       
        public TeacherViewModel()
        {
        }

        public TeacherViewModel(ITeacherService? teacherService)
        {
            _teacherService = teacherService;
        }

        public async override Task InitializeAsync()
        {
            await base.InitializeAsync();
        }   
    }
}
