using System;
using TechTalk.SpecFlow;

namespace SimpleTests.StepDefinitions
{
    [Binding]
    public class UITestsStepDefinitions
    {
        [Given(@"\[context]")]
        public void GivenContext()
        {
            throw new PendingStepException();
        }

        [When(@"\[action]")]
        public void WhenAction()
        {
            throw new PendingStepException();
        }

        [Then(@"\[outcome]")]
        public void ThenOutcome()
        {
            throw new PendingStepException();
        }
    }
}
