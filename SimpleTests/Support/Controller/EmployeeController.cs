using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using SimpleTests.Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Support.Controller
{
    public class EmployeeController
    {
        private string _url = ConfiguratorHelper.GetAPISection().ConnectionUrl;
        ApiRequestHelper apiRequestHelper;

        public EmployeeController()
        {
          apiRequestHelper  = new ApiRequestHelper(_url);
        }

        public async Task<string> GetEmployeesAsync()
        {
            var response = await apiRequestHelper.GetAsync(APITestendpoints.GetEmployeeUrl);

            return ReturnResponseContent(response);
        }

        public async Task<string> GetEmployeeByIdAsync(string employeeId)
        {
            var response = await apiRequestHelper.GetAsync(string.Join(APITestendpoints.GetEmployeeByIdUrl, employeeId));

            return ReturnResponseContent(response);
        }

        public async Task<string> AddEmployeeAsync(EmployeeModel employee)
        {
            var response = await apiRequestHelper.PostAsync(APITestendpoints.PostCreateEmployeeUrl, employee);

            return ReturnResponseContent(response);
        }

        public async Task<string> UpdateEmployeeById(string employeeId, EmployeeModel newEmployeeData)
        {
            var response = await apiRequestHelper.PutAsync(string.Join(APITestendpoints.PutUpdateEmployeeByIdUrl, employeeId), newEmployeeData);

            return ReturnResponseContent(response);
        }

        public async Task<string> DeleteEmployeeById(string employeeId)
        {
            var response = await apiRequestHelper.DeleteAsync(string.Join(APITestendpoints.DeleteEmployeeUrl, employeeId));

            return ReturnResponseContent(response);
        }

        private static string ReturnResponseContent(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? response.Content.ToString() : throw new Exception($"Request failed with status code {response.StatusCode}");
        }
    }
}
