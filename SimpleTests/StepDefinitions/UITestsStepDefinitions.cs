using SimpleTests.Support.Constants;
using SimpleTests.Support.Models;
using SimpleTests.Support.PageActions;
using TechTalk.SpecFlow.Assist;

namespace SimpleTests.StepDefinitions
{
    [Binding]
    public class UITestsStepDefinitions
    {
        MethodsAuthPage authMethods = new MethodsAuthPage();

        #region Given

        #endregion

        #region When 

        [When(@"the user enters invalid credentials")]
        [When(@"the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials(Table table)
        {
            var currentCredentials = table.CreateInstance<CredentialsModel>();

            authMethods.InputLogin(currentCredentials.Login);
            authMethods.InputPassword(currentCredentials.Password);
            authMethods.ClickSubmitButton();
        }

        #endregion

        #region Then

        [Then(@"the product page is displayed")]
        public void ThenTheMainPageIsDisplayed()
        {
            var mainPage = new ProductsPage();

           mainPage.CurrectPageUrl().Should().BeEquivalentTo(BaseConstants.ProductsPageURL);
        }

        [Then(@"returned expection with message")]
        public void ThenReturnedExpectionWithMessage()
        {
            authMethods.IsExceptionMessageCorrect().Should().BeTrue();
        }

        #endregion
    }
}
