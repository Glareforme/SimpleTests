using SimpleTests.Drivers;
using SimpleTests.Support.Constants;
using SimpleTests.Support.POM;

namespace SimpleTests.Support.PageActions
{
    public class MethodsAuthPage
    {

        public void InputLogin(string userLogin) => BrowserHelper.FindElementWithWaits(AuthPage.UsernameField, BaseConstants.TimeForWait).SendKeys(userLogin);

        public void InputPassword(string password) => BrowserHelper.FindElementWithWaits(AuthPage.PasswordField, BaseConstants.TimeForWait).SendKeys(password);

        public void ClickSubmitButton() => BrowserHelper.FindElementWithWaits(AuthPage.SubmitButton, BaseConstants.TimeForWait).Click();

        public bool IsExceptionMessageCorrect()
        {
            var listOfExceptions = new List<string>() { BaseConstants.PasswordExceptionMessage, BaseConstants.LoginExceptionMessage, BaseConstants.IncorrectLoginAndPassword };
            var currentExceptionMessage = BrowserHelper.FindElementWithWaits(AuthPage.ExceptionMessage, BaseConstants.TimeForWait).Text;

            foreach (var item in listOfExceptions)
            {
                if (currentExceptionMessage.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
