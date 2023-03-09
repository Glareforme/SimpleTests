using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using SimpleTests.Support.Models;

namespace SimpleTests.Hooks
{
    [Binding]
    internal class SqlTestsHooks
    {
        [AfterScenario("@deleteAfter")]
        public static void DeleteDataAfterTests()
        {
            DatabaseHelper.DeleteEmployee(new SqlEmployeeModel() { LastName = BaseConstants.EmployeeLastNameForSQL });
        }

        [AfterFeature("@dbTests")]
        public static void CloseDatabaseConnection()
        {
            DatabaseHelper.CloseConnection();
        }

    }
}
