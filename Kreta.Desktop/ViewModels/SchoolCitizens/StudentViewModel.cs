using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Services;
using Kreta.Shared.Responses;
using Kreta.Desktop.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kreta.Shared.Models.SchoolCitizens;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class StudentViewModel : BaseViewModel
    {
        private readonly IStudentService? _studentService;
        private readonly IEducationLavelService? _educationLevelService;

        [ObservableProperty] private ObservableCollection<Student> _students = new();
        [ObservableProperty] private Student _selectedStudent = new();
        [ObservableProperty] private string _womanStudentNumber = string.Empty;
        [ObservableProperty] private string _manStudentNumber = string.Empty;


        public StudentViewModel()
        {
        }

        public StudentViewModel(IStudentService? studentService,
                                IEducationLavelService? educationLevelService
                               )
        {

            _studentService = studentService;
            _educationLevelService = educationLevelService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
            await base.InitializeAsync();
        }

        [RelayCommand]
        private async Task DoSave(Student newStudentTeacher)
        {
            if (_studentService is not null && newStudentTeacher is not null)
            {
                Guid tmpId = newStudentTeacher.Id;
                ControllerResponse result;
                if (newStudentTeacher.HasId)
                    result = await _studentService.UpdateAsync(newStudentTeacher);
                else
                    result = await _studentService.InsertAsync(newStudentTeacher);
                if (!result.HasError)
                {
                    await UpdateView();
                    if (tmpId != Guid.Empty)
                    {
                        Student? newOrChanged = Students.FirstOrDefault(x => x.Id == tmpId);
                        if (newOrChanged != null)
                            SelectedStudent = newOrChanged;
                    }

                }
            }
        }

        [RelayCommand]
        private async Task DoGetStatisticData()
        {
            if (_studentService is not null)
            {
                int notAssistantNumber = await _studentService.GetNumberOfGender(false);
                int assistantNumber = await _studentService.GetNumberOfGender(true);
                WomanStudentNumber = $"Diáklányok száma: {assistantNumber} fő.";
                ManStudentNumber = $"Diák fiúk száma: {notAssistantNumber} fő.";
            }
        }

        private async Task UpdateView()
        {
            if (_studentService is not null)
            {
                List<Student> students = await _studentService.SelectAllAsync();
                Students = new ObservableCollection<Student>(students);
            }

        }
    }
}
