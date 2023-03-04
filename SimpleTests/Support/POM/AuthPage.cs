using OpenQA.Selenium;

namespace SimpleTests.Support.POM
{
    internal class AuthPage
    {
        internal static By UsernameField = By.CssSelector("#user-name");
        internal static By PasswordField = By.CssSelector("#password");
        internal static By SubmitButton = By.CssSelector("#login-button");
        internal static By ExceptionMessage = By.CssSelector("div .error-message-container h3");
    }
}
