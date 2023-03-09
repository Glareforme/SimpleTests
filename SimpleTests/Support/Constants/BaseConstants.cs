namespace SimpleTests.Support.Constants
{
    internal class BaseConstants
    {
        public const string ProductsPageURL = "https://www.saucedemo.com/inventory.html";
        public const int TimeForWait = 20;

        public const string LoginExceptionMessage = "Username is required";
        public const string PasswordExceptionMessage = "Password is required";
        public const string IncorrectLoginAndPassword = "Username and password do not match any user in this service";

        public const string SuccessGetAllUserMessage = "Successfully! All records has been fetched.";
        public const string SuccessGetUserById = "Successfully! Record has been fetched.";
        public const string GetUserWithoutIdErrorMessage = "Error Occured! Page Not found, contact rstapi2example@gmail.com";

        public const string SuccessStatus = "success";
        public const string Error = "error";

        public const string EmployeeLastNameForSQL = "LastTest";
    }
}
