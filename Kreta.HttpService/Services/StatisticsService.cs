using Kreta.Shared.Assamblers;
using Kreta.Shared.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace Kreta.HttpService.Services
{
    public class StatisticsService : IStatisticsService
    {
        protected readonly HttpClient? _httpClient;

        public StatisticsService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("KretaApi");
            }
        }

        public async Task<GenderNumberOfParent> GetGenderNumberOfParent()
        {
            if (_httpClient is not null)
            {
                try
                {

                    GenderNumberOfParent? result = await _httpClient.GetFromJsonAsync<GenderNumberOfParent>($"api/Statistic/GenderNumberOfParent");
                    if (result is not null)
                    {
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new GenderNumberOfParent();
        }

        public async Task<int> GetNumberOfParents()
        {
            if (_httpClient is not null)
            {
                try
                {
                    int result = await _httpClient.GetFromJsonAsync<int>($"api/Statistic/NumberOfParent");
                    return result;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return -1;
        }

        public async Task<List<NumberOfStudentByClass>> GetNumberOfStudentByClasses()
        {
            if (_httpClient is not null)
            {
                try
                {

                    List<NumberOfStudentByClass>? result = await _httpClient.GetFromJsonAsync<List<NumberOfStudentByClass>>($"api/Statistic/NumberOfStudentByClasses");
                    if (result is not null)
                    {
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<NumberOfStudentByClass>()  ;
        }
    }
}
