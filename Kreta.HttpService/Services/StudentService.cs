using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Parameters;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Kreta.HttpService.Services
{
    public class StudentService : BaseService<Student, StudentDto>, IStudentService
    {
        public StudentService(IHttpClientFactory? httpClientFactory, StudentAssambler studentAssambler) : base(httpClientFactory, studentAssambler)
        {
        }

        public async Task<List<Student>> SelectAllIncludedAsync()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<StudentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<StudentDto>>($"api/Student/included");
                    if (resultDto is not null)
                    {
                        List<Student> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Student>();
        }

        public async Task<List<Student>> GetStudentsByEducationId(Guid educationId)
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<StudentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<StudentDto>>($"api/Student/byeducationid/{educationId}");
                    if (resultDto is not null)
                    {
                        List<Student> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Student>();
        }

        public async Task<List<Student>> GetStudentsWithoutEducationLevel()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<StudentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<StudentDto>>($"api/Student/withouteducationlevel");
                    if (resultDto is not null)
                    {
                        List<Student> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Student>();
        }

        public async Task<int> GetNumberOfGender(bool isWoman)
        {
            if (_httpClient is not null)
            {
                try
                {

                    int resultNumber = await _httpClient.GetFromJsonAsync<int>($"api/Student/NumberOfGender/{isWoman}");
                    return resultNumber;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return 0;
        }

        public async Task<List<Student>> SearchAndFilterStudents(StudentQueryParameters studentQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    StudentQueryParametersDto proba = studentQueryParameters.ToDto();
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Student/queryparameters", studentQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<StudentDto>? students = JsonConvert.DeserializeObject<List<StudentDto>>(content);
                        if (students is not null)
                        {
                            return students.Select(studentDto => studentDto.ToModel()).ToList();
                        }
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<Student>();
        }
    }
}
