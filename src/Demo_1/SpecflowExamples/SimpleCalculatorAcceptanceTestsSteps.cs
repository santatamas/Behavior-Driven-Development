using NUnit.Framework;
using SimpleCalculator;
using System;
using TechTalk.SpecFlow;

namespace SpecflowExamples
{
    [Binding]
    public class SimpleCalculatorAcceptanceTestsSteps
    {
        StringCalculator _calculator = null;
        int _result = 0;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new StringCalculator();
        }


        [When(@"I call Add with ""(.*)""")]
        public void WhenICallAddWith(string p0)
        {
            _result = _calculator.Add(p0);
        }

        [Then(@"the result should be the sum of the numbers")]
        public void ThenTheResultShouldBeTheSumOfTheNumbers()
        {
            Assert.AreEqual(7, _result);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(p0, _result);
        }
    }
}
