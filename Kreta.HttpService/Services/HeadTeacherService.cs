using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SchoolCitizens;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Kreta.HttpService.Services
{
    public class HeadTeacherService : BaseService<HeadTeacher, HeadTeacherDto>, IHeadTeacherService
    {
        public HeadTeacherService(IHttpClientFactory? httpClientFactory, HeadTeacherAssambler assambler) : base(httpClientFactory, assambler)
        {
        }

        public async Task<int> GetNumberOfHeadTeacher(bool isAssistant)
        {
            if (_httpClient is not null)
            {
                try
                {

                    int resultNumber = await _httpClient.GetFromJsonAsync<int>($"api/HeadTeacher/NumberOfHeadTeacher/{isAssistant}");
                    return resultNumber;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return 0;
        }
    }
}
