using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.DTO.GovernorateDTO;
using System.Net;
namespace EmployeeTask.BFF.HttpClients
{
    public class AggregatorServiceClient
    {
        private readonly HttpClient _httpClient;

        public AggregatorServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #region Employee Client
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
        public async Task<EmployeeResponseGet?> GetEmployeeByID(int employeeID)
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

                EmployeeResponseGet? employeeResponse = await response.Content.ReadFromJsonAsync<EmployeeResponseGet>();
                if (employeeResponse is null)
                    return null;
                return employeeResponse;
            
        }

        #endregion

        #region Address Client
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
        #endregion



        #region Governorate Client
        public async Task<IEnumerable<GovernorateResponse>?> GetAllGovernorates()
        {
           
                HttpResponseMessage response = await _httpClient.GetAsync("api/Governorates");
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

                IEnumerable<GovernorateResponse>? governorateResponse = await response.Content.ReadFromJsonAsync<IEnumerable<GovernorateResponse>>();
                if (governorateResponse is null)
                    return new List<GovernorateResponse>();
                return governorateResponse;
            

        }
        public async Task<GovernorateResponse?> GetGovernorateByID(int governorateID)
        {

                HttpResponseMessage response = await _httpClient.GetAsync($"api/Governorates/{governorateID}");
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

                GovernorateResponse? governorateResponse = await response.Content.ReadFromJsonAsync<GovernorateResponse>();
                if (governorateResponse is null)
                    return null;
                return governorateResponse;
        }
        #endregion
    }
}
