using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using SimpleTests.Support.Models;
using System;
using TechTalk.SpecFlow;

namespace SimpleTests.StepDefinitions
{
    [Binding]
    public class DatabaseStepDefinitions
    {
        private readonly ResponceInfo responceInfo;
        public DatabaseStepDefinitions(ResponceInfo responceInfo)
        {
            this.responceInfo = responceInfo;
        }

        [Given(@"Database is already exist")]
        public void GivenDatabaseIsAlreadyExist()
        {
            //mock
        }

        [When(@"user add new employee in table")]
        public void WhenUserAddNewEmployeeInTable()
        {
            var employee = new SqlEmployeeModel()
            {
                LastName = BaseConstants.EmployeeLastNameForSQL,
                FirstName = "FirstTest",
                Title = "TitleTest",
                TitleOfCourtesy = "TitleOfCourtesyTest",
                BirthDate = DateTime.Now,
                HireDate = DateTime.Now,
                Address = "AddressTest",
                City = "CityTest",
                Region = "RegionTest",
                PostalCode = "Test",
                Country = "CountryTest",
                HomePhone = "HomePhoneTest",
                Extension = null,
                Photo = null,
                Notes = null,
                ReportsTo = 1,
                PhotoPath = "TestPath"
            };

            DatabaseHelper.InsertEmployee(employee);

            responceInfo.EmployeeLastName = employee.LastName;
        }

        [Then(@"employee displayed in database table")]
        public void ThenEmployeeDisplayedInDatabaseTable()
        {
            var employee = new SqlEmployeeModel()
            {
                LastName = BaseConstants.EmployeeLastNameForSQL
            };

            DatabaseHelper.IsEmployeeRecordExistInDB(employee).Should().BeTrue();
        }
    }
}
