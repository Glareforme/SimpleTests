using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using SimpleTests.Support.Models;

namespace SimpleTests.Support.Controller
{
    public class EmployeeController
    {
        ApiRequestHelper requestHelper;

        public EmployeeController()
        {
            requestHelper = new ApiRequestHelper(ConfiguratorHelper.GetAPISection().ConnectionUrl);
        }

        public async Task<ResponseModel> GetEmployeesAsync()
        {
            var response = await requestHelper.GetAsync(APITestendpoints.GetEmployeeUrl);

            return await ReturnResponseContent(response);
        }

        public async Task<ResponseModel> GetEmployeeByIdAsync(string employeeId)
        {
            var response = await requestHelper.GetAsync(string.Format(APITestendpoints.GetEmployeeByIdUrl, employeeId));

            return await ReturnResponseContent(response); 
        }

        public async Task<ResponseModel> AddEmployeeAsync(EmployeeModel employee)
        {
            var response = await requestHelper.PostAsync(APITestendpoints.PostCreateEmployeeUrl, employee);

            return await ReturnResponseContent(response);
        }

        public async Task<ResponseModel> UpdateEmployeeById(string employeeId, EmployeeModel newEmployeeData)
        {
            var response = await requestHelper.PutAsync(string.Join(APITestendpoints.PutUpdateEmployeeByIdUrl, employeeId), newEmployeeData);

            return await ReturnResponseContent(response);
        }

        public async Task<ResponseModel> DeleteEmployeeById(string employeeId)
        {
            var response = await requestHelper.DeleteAsync(string.Join(APITestendpoints.DeleteEmployeeUrl, employeeId));

            return await ReturnResponseContent(response);
        }

        private async Task<ResponseModel> ReturnResponseContent(HttpResponseMessage response)
        {
            var responsedData = new ResponseModel()
            {
                StatusCode = ((int)response.StatusCode),
                ResponseContent = await response.Content.ReadAsStringAsync()
            };

            return responsedData;
        }
    }
}
