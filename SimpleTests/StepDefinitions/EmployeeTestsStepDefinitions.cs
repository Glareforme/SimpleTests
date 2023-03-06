using SimpleTests.Support.Constants;
using SimpleTests.Support.Controller;
using SimpleTests.Support.Models;
using System;
using System.Text.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SimpleTests.StepDefinitions
{
    public class ResponceInfo
    {
        public int statusCode;
        public int EmployeeId;
        public string? Responce;
    }

    [Binding]
    public class EmployeeTestsStepDefinitions 
    {
        EmployeeController employeeController = new EmployeeController();
        private readonly ResponceInfo responceInfo;

        public EmployeeTestsStepDefinitions(ResponceInfo responceInfo)
        {
            this.responceInfo = responceInfo;
        }

        #region Given
        [Given(@"employees created in database")]
        public void GivenEmployeesCreatedInDatabase()
        {
            
        }

        #endregion

        #region When 

        [When(@"user send request to get user without id")]
        public async Task WhenUserSendRequestToGetUserWithoutId()
        {
            var response = await employeeController.GetEmployeeByIdAsync(String.Empty);

            responceInfo.statusCode = response.StatusCode;
            responceInfo.Responce = response.ResponseContent;
        }

        [When(@"user send GET request with valid data")]
        public async Task WhenUserSendGETRequestWithValidData()
        {
            var response = await employeeController.GetEmployeesAsync();

            responceInfo.statusCode = response.StatusCode;
            responceInfo.Responce = response.ResponseContent;
        }

        [When(@"user send request to get user by (.*)")]
        public async Task WhenUserSendRequestToGetUserBy(int employeeId)
        {
            var response = await employeeController.GetEmployeeByIdAsync(employeeId.ToString());

            responceInfo.statusCode = response.StatusCode;
            responceInfo.Responce = response.ResponseContent;
            responceInfo.EmployeeId = employeeId;
        }
        #endregion

        #region Then
        [Then(@"response with status code (.*) is received")]
        public void ThenResponseWithStatusCodeIsReceived(int expStatusCode)
        {
            responceInfo.statusCode.Should().Be(expStatusCode);
        }

        [Then(@"response contained all expected data")]
        public void ThenResponseContainedAllExpectedData()
        {
            var expectedResponse = new ListOfEmployeeModel()
            {
                status = BaseConstants.SuccessStatus,
                data = null,
                message = BaseConstants.SuccessGetAllUserMessage
            };
            var actualResponse = JsonSerializer.Deserialize<ListOfEmployeeModel>(responceInfo.Responce);

            actualResponse.status.Should().BeEquivalentTo(expectedResponse.status);
            actualResponse.message.Should().BeEquivalentTo(expectedResponse.message);
        }

        [Then(@"responsed error massages is received")]
        public void ThenResponsedErrorMassagesIsReceived(Table table)
        {
            var expectedResponse = table.CreateInstance<ZeroIdResponseModel>();
            var actualResponse = JsonSerializer.Deserialize<ZeroIdResponseModel>(responceInfo.Responce);

            expectedResponse.Should().BeEquivalentTo(actualResponse);
        }

        [Then(@"the response does not contain data about the employee")]
        public void ThenTheResponseDoesNotContainDataAboutTheEmployee()
        {
            var expectedResponse = new ListOfEmployeeModel()
            {
                status = BaseConstants.SuccessStatus,
                data = null,
                message = BaseConstants.SuccessGetUserById
            };
            var actualResponse = JsonSerializer.Deserialize<ListOfEmployeeModel>(responceInfo.Responce);

            actualResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Then(@"responsed employee data is correct")]
        public void ThenResponsedEmployeeDataIsCorrect(Table table)
        {
            var employeeData = table.CreateInstance<TableEmployeeModel>();
            var expectedResponse = new EmployeeResponseModel()
            {
                status = BaseConstants.SuccessStatus,
                data = new EmployeeModel()
                {
                    id = responceInfo.EmployeeId,
                    employee_name = employeeData.Name,
                    employee_age = employeeData.Age,
                    employee_salary = employeeData.Salary,
                    profile_image = ""
                },
                message = BaseConstants.SuccessGetUserById
            };
            var actualResponse = JsonSerializer.Deserialize<EmployeeResponseModel>(responceInfo.Responce);

            expectedResponse.status.Should().BeEquivalentTo(actualResponse.status);
            expectedResponse.data.Should().BeEquivalentTo(actualResponse.data);
            expectedResponse.message.Should().BeEquivalentTo(actualResponse.message);
        }

        [Then(@"returned correct message in response")]
        public void ThenReturnedMessageInResponse()
        {
            var expectedMessage = BaseConstants.GetUserWithoutIdErrorMessage;

            var actualMessage = JsonSerializer.Deserialize<EmptyIdResponseModel>(responceInfo.Responce);

            expectedMessage.Should().BeEquivalentTo(actualMessage.message);
        }

        #endregion
    }
}
