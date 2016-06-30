using System;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumSpecflowMasterclass
{
    public class DriverStore
    {
        [ThreadStatic] public static IWebDriver Driver;

        public static IWebDriver GetForCurrentThread()
        {
            if (Driver != null)
            {
                return Driver;
            }           

            Trace.WriteLine($"Creating driver context for thread {Thread.CurrentThread.Name}");

            Driver = new ChromeDriver();

            var driver = Driver;

            AppDomain.CurrentDomain.DomainUnload += (IChannelSender, args) => driver.Quit();

            return Driver;
        }


    }
}