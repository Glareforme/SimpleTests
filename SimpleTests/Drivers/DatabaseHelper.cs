using Dapper;
using SimpleTests.Support.Models;
using SimpleTests.Support.SQLQueries;
using System.Data.SqlClient;

namespace SimpleTests.Drivers
{
    public class DatabaseHelper
    {
        private static readonly SqlConnection DbConnection =
            new SqlConnection(ConfiguratorHelper.GetSqlSectionModel().ConnectionString);

        public DatabaseHelper()
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

        public static bool IsEmployeeRecordExistInDB(SqlEmployeeModel employeeLastName)
        {
            var employee = DbConnection.Query(Queries.SelectEmployee, new { employeeLastName.LastName }).ToString();
            if (employee.Length >= 0 || employee == null)
            {
                return true;
            }
            return false;
        }

        public static void DeleteEmployee(SqlEmployeeModel employeeLastName)
        {
            DbConnection.Query(Queries.DeleteEmployee, new
            {
                employeeLastName.LastName
            });
        }

        public static void CloseConnection()
        {
            DbConnection.Close();
            DbConnection.Dispose();
        }
    }
}
