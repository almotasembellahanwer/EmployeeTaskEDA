using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;
using System.Net;
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
        public async Task<EmployeeResponse?> UpdateEmployee(EmployeeUpdateRequest employeeDTO)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Employees", employeeDTO);
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
        public async Task<bool> DeleteEmployee(int employeeID)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Employees/{employeeID}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
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
            return response.IsSuccessStatusCode;
        }




        public async Task<AddressResponse?> AddAddress(AddressAddRequest addressDTO)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Addresses", addressDTO);
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
        public async Task<AddressResponse?> UpdateAddress(AddressUpdateRequest addressDTO)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Addresses", addressDTO);
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
        public async Task<bool> DeleteAddress(int addressID)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Addresses/{addressID}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
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
            return response.IsSuccessStatusCode;
        }
    }
}
