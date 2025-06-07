using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;
using System.Net;
using System.Net.Http;
namespace EmployeeTask.BFF.HttpClients
{
    public class AggregatorServiceClient
    {
        private readonly HttpClient _httpClient;

        public AggregatorServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EmployeeResponseGet>?> GetAllEmployees()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Employees");
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

            IEnumerable<EmployeeResponseGet>? employeeResponse = await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeResponseGet>>();
            if (employeeResponse is null)
                return new List<EmployeeResponseGet>();
            return employeeResponse;
        }
        public async Task<EmployeeResponse?> GetEmployeeByID(int employeeID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Employees/{employeeID}");
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


        public async Task<IEnumerable<AddressResponse>?> GetAllAddresses()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Addresses");
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

            IEnumerable<AddressResponse>? addressResponse = await response.Content.ReadFromJsonAsync<IEnumerable<AddressResponse>>();
            if (addressResponse is null)
                return new List<AddressResponse>();
            return addressResponse;
        }
        public async Task<AddressResponse?> GetAddressByID(int addressID)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Addresses/{addressID}");
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

            AddressResponse? addressResponse = await response.Content.ReadFromJsonAsync<AddressResponse>();
            if (addressResponse is null)
                return null;
            return addressResponse;
        }
    }
}
