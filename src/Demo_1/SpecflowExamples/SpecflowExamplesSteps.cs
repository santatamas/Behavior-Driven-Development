using SpecflowExamples.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowExamples
{
    [Binding]
    public class SpecflowExamplesSteps
    {
        #region Calculator example
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            
        }
        #endregion

        #region WebAutomation example - part 1
        [Given(@"I am on the (.*) page")]
        public void GivenIAmOnTheHomePage(string page)
        {
            // TODO: use something instead of string
            string url;
            switch (page)
            {
                case "Home":
                    url = "http://www.meme.com";
                    break;
                case "Article list":
                    url = "http://www.meme.com/list/1";
                    break;
                case "Article":
                    url = "http://www.meme.com/how_tough_polar_bears_can_really_be";
                    break;
                case "Checkout":
                    url = "http://www.meme.com/checkout";
                    break;
                case "Confirmation":
                    url = "http://www.meme.com/confirmation";
                    break;
                default:
                    throw new NotSupportedException("invalid page name: " + page);
            }
            
            // TODO: navigate to url here...
        }


        [When(@"I login with default user")]
        public void WhenILoginWithDefaultUser()
        {
            
        }

        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            
        }
        #endregion

        #region WebAutomation example - part 2

        [When(@"I login with the following user")]
        public void WhenILoginWithTheFollowingUser(Table table)
        {
            // TODO: do the parsing somewhere else
            var email = table.Rows[0]["Email"];
            var password = table.Rows[0]["Password"];
        }

        #endregion
    }
}
