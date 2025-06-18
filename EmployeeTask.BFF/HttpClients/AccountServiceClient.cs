using SharedModels.DTO.AddressDTO;
using SharedModels.DTO.AreaDTO;
using SharedModels.DTO.DepartmentDTO;
using SharedModels.DTO.DistrictDTO;
using SharedModels.DTO.EmployeeDTO;
using SharedModels.DTO.GovernorateDTO;
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
        #region Employee Client
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

        #endregion


        #region Address Client
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
        #endregion




        #region Governorate Client
        public async Task<GovernorateResponse?> AddGovernorate(GovernorateAddRequest governorateDTO)
        {

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Governorates", governorateDTO);
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
        public async Task<GovernorateResponse?> UpdateGovernorate(GovernorateUpdateRequest governorateDTO)
        {

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Governorates", governorateDTO);
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
        public async Task<bool> DeleteGovernorate(int governorateID)
        {

                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Governorates/{governorateID}");
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
        #endregion


        #region Area Client
        public async Task<AreaResponse?> AddArea(AreaAddRequest areaDTO)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Areas", areaDTO);
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

            AreaResponse? areaResponse = await response.Content.ReadFromJsonAsync<AreaResponse>();
            if (areaResponse is null)
                return null;
            return areaResponse;

        }
        public async Task<AreaResponse?> UpdateArea(AreaUpdateRequest areaDTO)
        {

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Areas", areaDTO);
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

            AreaResponse? areaResponse = await response.Content.ReadFromJsonAsync<AreaResponse>();
            if (areaResponse is null)
                return null;
            return areaResponse;

        }
        public async Task<bool> DeleteArea(int areaID)
        {

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Areas/{areaID}");
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
        #endregion

        #region District Client
        public async Task<DistrictResponse?> AddDistrict(DistrictAddRequest districtDTO)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Districts", districtDTO);
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

            DistrictResponse? districtResponse = await response.Content.ReadFromJsonAsync<DistrictResponse>();
            if (districtResponse is null)
                return null;
            return districtResponse;

        }
        public async Task<DistrictResponse?> UpdateDistrict(DistrictUpdateRequest districtDTO)
        {

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Districts", districtDTO);
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

            DistrictResponse? districtResponse = await response.Content.ReadFromJsonAsync<DistrictResponse>();
            if (districtResponse is null)
                return null;
            return districtResponse;

        }
        public async Task<bool> DeleteDistrict(int districtID)
        {

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Districts/{districtID}");
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
        #endregion

        #region Department Client
        public async Task<DepartmentResponse?> AddDepartment(DepartmentAddRequest departmentDTO)
        {

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Departments", departmentDTO);
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

            DepartmentResponse? departmentResponse = await response.Content.ReadFromJsonAsync<DepartmentResponse>();
            if (departmentResponse is null)
                return null;
            return departmentResponse;

        }
        public async Task<DepartmentResponse?> UpdateDepartment(DepartmentUpdateRequest departmentDTO)
        {

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("api/Departments", departmentDTO);
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

            DepartmentResponse? departmentResponse = await response.Content.ReadFromJsonAsync<DepartmentResponse>();
            if (departmentResponse is null)
                return null;
            return departmentResponse;

        }
        public async Task<bool> DeleteDepartment(int departmentID)
        {

            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Departments/{departmentID}");
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
        #endregion


    }
}
