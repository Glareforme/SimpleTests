using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Support.Controller
{
    struct

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
            var response = await apiRequestHelper.GetAsync(BaseConstants.GetEmployeeUrl);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ToString();
            }
            else throw new Exception($"Request failed with status code {response.StatusCode}");
        }

        public async Task<string> GetEmployeeByIdAsync(string employeeId)
        {
            var response = await apiRequestHelper.GetAsync(string.Join(BaseConstants.GetEmployeeByIdUrl, employeeId));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ToString();
            }
            else throw new Exception($"Request failed with status code {response.StatusCode}");
        }
    }
}
