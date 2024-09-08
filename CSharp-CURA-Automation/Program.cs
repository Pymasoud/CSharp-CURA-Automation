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

            // Open the website.
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");

        }

        [Test]
        public void executeTest()
        {
            // Click on Make Appointment button.
            SeleniumSetMethods.Click(driver, "btn-make-appointment", "Id");

            // Type Username.
            SeleniumSetMethods.EnterText(driver, "txt-username", "John Doe", "Id");

            // Type Password.
            SeleniumSetMethods.EnterText(driver, "txt-password", "ThisIsNotAPassword", "Id");

            // Click on Login.
            SeleniumSetMethods.Click(driver, "btn-login", "Id");

            // Facility DropDown.
            SeleniumSetMethods.SelectDropDown(driver, "combo_facility", "Seoul CURA Healthcare Center", "Id");

            // Click Apply for hospital readmission.
            SeleniumSetMethods.Click(driver, "//input[@id='chk_hospotal_readmission']", "XPath");

            // Select HealthProgram.
            SeleniumSetMethods.Click(driver, "radio_program_medicaid", "Id");

            SeleniumSetMethods.SelectDate(driver, "2024-10-20");
        }

        [TearDown]
        public void closeTest()
        {
            // Waiting 5 sec and close the test.
            //Thread.Sleep(5000);
            //driver.Close();

        }



        static void Main(string[] args)
        {
        }
    }
}
