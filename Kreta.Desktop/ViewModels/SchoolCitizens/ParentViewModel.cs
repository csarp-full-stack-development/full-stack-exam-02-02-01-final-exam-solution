using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Services;
using Kreta.Shared.Responses;
using Kreta.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class ParentViewModel : BaseViewModel
    {
        private readonly IParentService? _parentService;

        public ParentViewModel()
        {
        }

        public ParentViewModel(IParentService? parentService)
        {
            _parentService = parentService;
        }

        public async override Task InitializeAsync()
        {
            await base.InitializeAsync();
        }       
    }
}
