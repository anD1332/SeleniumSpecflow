using System;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowMasterclass.Steps
{
    [Binding, Scope(Feature = "Checkout")]
    public class Checkout : StepsBaseClass
    {
        public void AddProductToBasket()
        {
            Driver.Navigate().GoToUrl(@"http://test.dutyfree.maginfrastructure.com/store/dixons-travel/headphones/bang-olufsen-beoplay-h6/c-24/c-116/p-790");

            var reserveButton = Driver.FindElement(By.Id("add-to-basket"));
            reserveButton.Click();

            var miniBasketElement = Driver.FindElement(By.Id("mini-basket"));
            miniBasketElement.Click();

            var bagContinueButton = Driver.FindElement(By.CssSelector("button[name=update-and-continue]"));
            bagContinueButton.Click();
        }

        [Given(@"I have gone to the product page")]
        public void GivenIHaveGoneToTheProductPage()
        {
            IWebDriver driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(@"http://test.dutyfree.maginfrastructure.com/store/dixons-travel/headphones/bang-olufsen-beoplay-h6/c-24/c-116/p-790");
        }

        [Given(@"I reserve the product")]
        public void GivenIReserveTheProduct()
        {
            var reserveButton = Driver.FindElement(By.Id("add-to-basket"));
            reserveButton.Click();
        }

        [Given(@"I click the mini basket")]
        public void GivenIClickTheMiniBasket()
        {
            var miniBasketElement = Driver.FindElement(By.Id("mini-basket"));
            miniBasketElement.Click();
        }

        [When(@"I press Reserve")]
        public void WhenIPressReserve()
        {
            var bagContinueButton = Driver.FindElement(By.CssSelector("button[name=update-and-continue]"));
            bagContinueButton.Click();
        }

        [Then(@"the form will have a series of fields")]
        public void ThenTheFormWillHaveASeriesOfFields(Table expectedFields)
        {
            for(int i = 0; i < expectedFields.RowCount; i++)
            {
                IWebElement form = Driver.FindElement(By.Id("reservationForm"));
                IWebElement formField = form.FindElements(By.ClassName("form-group"))[i];
                var actualFormLabel = formField.FindElement(By.ClassName("control-label"));
                var expectedFormLabel = expectedFields.Rows[i][0];
                actualFormLabel.Text.Should().Contain(expectedFormLabel);
            }
        }
    }
}