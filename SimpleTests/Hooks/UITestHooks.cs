using SimpleTests.Drivers;

namespace SimpleTests.Hooks
{
    [Binding]
    public sealed class UITestHooks
    {

        [BeforeFeature("@uiFeature")]
        public static void BeforeScenarioWithTag() => BrowserHelper.GetBrowser().Navigate().GoToUrl(ConfiguratorHelper.GetUISection().ConnectionUrl);


        [BeforeFeature(@"uiTest")]
        public static void OpenNewWindowBeforeTest() => BrowserHelper.GetBrowser().Navigate().GoToUrl(ConfiguratorHelper.GetUISection().ConnectionUrl);

        [AfterFeature(@"uiTest")]
        public static void CloseWindowAfterTest() => BrowserHelper.CleanDriver();

        [AfterFeature("@uiFeature")]
        public static void AfterScenario() => BrowserHelper.CloseDriver();
    }
}