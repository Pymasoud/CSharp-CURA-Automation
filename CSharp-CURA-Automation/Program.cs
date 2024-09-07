using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSharp_CURA_Automation
{

    
    internal class Program
    {

        IWebDriver driver;

        [SetUp]
        public void initilizeTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            
        }

        [Test]
        public void executeTest()
        {
            // Open the website.
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
        }

        [TearDown]
        public void closeTest()
        {
            // Waiting 5 sec and close the test.
            Thread.Sleep(5000);
            driver.Close();

        }



        static void Main(string[] args)
        {
        }
    }
}
