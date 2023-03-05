namespace SimpleTests.Support.Constants
{
    internal class BaseConstants
    {
        public const string ProductsPageURL = "https://www.saucedemo.com/inventory.html";
        public const int TimeForWait = 20;

        public const string LoginExceptionMessage = "Username is required";
        public const string PasswordExceptionMessage = "Password is required";
        public const string IncorrectLoginAndPassword = "Username and password do not match any user in this service";

        public const string GetEmployeeUrl = "employees";
        public const string GetEmployeeByIdUrl = "employee/{0}";
        public const string PostCreateEmployeeUrl = "create";
        public const string PutUpdateEmployeeByIdUrl = "update/{0}";
        public const string DeleteEmployeeUrl = "delete/{0}";
    }
}
