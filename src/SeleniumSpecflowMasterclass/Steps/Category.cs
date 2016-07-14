using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowMasterclass.Steps
{
    [Binding, Scope(Feature = "Category")]
    public class CategorySteps
    {
        [Given(@"I am on the Headphones Category Page")]
        public void GivenIAmOnThe()
        {
            var category = "Headphones";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constants.HeadphonesCategoryPageUrl);
            driver.Title.Should().Be($"{category} | Dixons Travel | Official website for Manchester Airport Duty Free Shopping | Manchester Airport");
        }

        [Then(@"the header is Headphones")]
        public void ThenTheHeaderIs()
        {
            IWebDriver driver = new ChromeDriver();
            IWebElement header = driver.FindElement(By.TagName("h1"));
            var actualHeader = header.Text.Replace("\r\n", " ");
            actualHeader.Should().Be("Headphones");
        }
    }
}