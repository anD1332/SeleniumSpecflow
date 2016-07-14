using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowMasterclass
{
    public class StepsBaseClass
    {
        protected static IWebDriver Driver
        {
            get { return DriverStore.GetForCurrentThread(); }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if(ScenarioContext.Current.ScenarioInfo.Tags.Contains("mobile"))
            {
                Driver.Manage().Window.Size = new Size(320, 800);
            }

            else if(ScenarioContext.Current.ScenarioInfo.Tags.Contains("<1280px"))
            {
                Driver.Manage().Window.Size = new Size(1279, 800);
            }
            else
            {
                Driver.Manage().Window.Size = new Size(1920, 995);
            }
        }
    }
}