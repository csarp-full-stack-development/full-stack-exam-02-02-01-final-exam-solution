using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.ControlPanel
{
    public partial class ControlPanelViewModel: BaseViewModel
    {
        private readonly IStatisticsService? _statisticsService;

        public ControlPanelViewModel() { }
        public ControlPanelViewModel(IStatisticsService? statisticsService )
        {                     
            _statisticsService = statisticsService;
        }

        [ObservableProperty] public string _numberOfParentString = string.Empty;

        [ObservableProperty] private string _genderNumberOfParentString = string.Empty;
        [ObservableProperty] private string _numberOfStudentOfSchoolClassString = string.Empty;

        [RelayCommand]
        public async Task DoGetData()
        {
            await GetNumberOfParent();
            await GetGenderNumberOfParent();
            await GetNumberOfStudentOfSchoolClass();
        }

        private async Task GetGenderNumberOfParent()
        {
            if (_statisticsService is null)
                GenderNumberOfParentString = "A szülők nemenkénti száma meghatározhatatlan...";
            else
            {
                GenderNumberOfParent genderNumberOfParent = await _statisticsService.GetGenderNumberOfParent();
                GenderNumberOfParentString = $"A női szülők száma: {genderNumberOfParent.FemaleNumber} fő, a férfi szülők száma {genderNumberOfParent.MaleNumber} fő";
            }
        }

        private async Task GetNumberOfParent()
        {
            int numberOfParent = 0;
            if (_statisticsService is not null)
                numberOfParent = await _statisticsService.GetNumberOfParents();
            NumberOfParentString =  _statisticsService is not null ? $" {numberOfParent} szülő van a rendszerben." : "Szülők száma nem meghatározható...";
        }

        private async Task GetNumberOfStudentOfSchoolClass()
        {
            if (_statisticsService is null)
                NumberOfStudentOfSchoolClassString = "A diákok száma osztályonként meghatározhatatlan...";
            else
            {
                List<NumberOfStudentByClass> numberOfStudentByClasses= await _statisticsService.GetNumberOfStudentByClasses();
                string result = "";

                if (numberOfStudentByClasses.Count == 0)
                    NumberOfStudentOfSchoolClassString = "Nincs iskolai osztály az adatbázisban!";
                else
                {
                    foreach (var numberOfStudent in numberOfStudentByClasses)
                    {
                        string type = string.Empty;
                        switch(numberOfStudent.Type)
                        {
                            case SchoolClassType.ClassA: type = "a";break;
                            case SchoolClassType.ClassB: type = "b";break;
                            case SchoolClassType.ClassC: type = "c";break;

                        }
                        result = $"{result}\n {numberOfStudent.Grade}.{type} osztályba {numberOfStudent.NumberOfStudent} fő jár.\n";
                    }
                    NumberOfStudentOfSchoolClassString = result;
                }
            }
        }


    }
}
