using Dapper;
using SimpleTests.Support.Models;
using SimpleTests.Support.SQLQueries;
using System.Data.SqlClient;

namespace SimpleTests.Drivers
{
    internal class DatabaseHelper
    {
        private static readonly SqlConnection DbConnection =
            new SqlConnection(ConfiguratorHelper.GetSqlSectionModel().ConnectionString);

        static DatabaseHelper()
        {
            DbConnection.Open();
        }

        public static void InsertEmployee(SqlEmployeeModel employeeModel)
        {
            DbConnection.Query(Queries.InsertEmployee, new
            {
                employeeModel.LastName,
                employeeModel.FirstName,
                employeeModel.Title,
                employeeModel.TitleOfCourtesy,
                employeeModel.BirthDate,
                employeeModel.HireDate,
                employeeModel.Address,
                employeeModel.City,
                employeeModel.Region,
                employeeModel.PostalCode,
                employeeModel.Country,
                employeeModel.HomePhone,
                employeeModel.Extension,
                employeeModel.Photo,
                employeeModel.Notes,
                employeeModel.ReportsTo,
                employeeModel.PhotoPath
            });
        }
    }
}
