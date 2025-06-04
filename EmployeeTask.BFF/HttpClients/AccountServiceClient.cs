using SharedModels.DTO.EmployeeDTO;
using System.Net;
using System.Net.Http;
namespace EmployeeTask.BFF.HttpClients
{
    public class AccountServiceClient
    {
        private readonly HttpClient _httpClient;

        public AccountServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmployeeResponse?> AddEmployee(EmployeeAddRequest employeeDTO)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Employees", employeeDTO);
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
                }
                else
                {
                    throw new HttpRequestException("invalid response", null, response.StatusCode);
                }
            }

            EmployeeResponse? employeeResponse = await response.Content.ReadFromJsonAsync<EmployeeResponse>();
            if (employeeResponse is null)
                return null;
            return employeeResponse;
        }
    }
}
