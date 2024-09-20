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

        [SetUp]
        public void initilizeTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");

            PropertiesCollection.driver = new ChromeDriver(options);
            PropertiesCollection.driver.Manage().Window.Maximize();

            // Open the website.
            PropertiesCollection.driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");

        }

        [Test]
        public void executeTest()
        {
            // Click on Make Appointment button.
            SeleniumSetMethods.Click("btn-make-appointment", "Id");

            
            // Type Username.
            SeleniumSetMethods.EnterText("txt-username", "John Doe", "Id");

           
            // checking the "Typed Password".
            SeleniumSetMethods.EnterText("txt-password", "ThisIsNotAPassword", "Id");

            // Get the typed password.
            Console.WriteLine("The value of password is: " + SeleniumGetMethods.GetText("txt-password", "Id"));

            // Click on Login.
            SeleniumSetMethods.Click("btn-login", "Id");


            // Facility DropDown.
            SeleniumSetMethods.SelectDropDown("combo_facility", "Seoul CURA Healthcare Center", "Id");

            // Check value of the DropDown of Facility.
            Console.WriteLine("The value of DropDown is: " + SeleniumGetMethods.GetTextFromDDL("combo_facility", "Id"));


            // Click Apply for hospital readmission.
            SeleniumSetMethods.Click("//input[@id='chk_hospotal_readmission']", "XPath");

            // Select HealthProgram.
            SeleniumSetMethods.Click("radio_program_medicaid", "Id");


            // Enter date on the calender.
            SeleniumSetMethods.EnterText("txt_visit_date", "20/09/2024", "Id");

            // Type a comment a comment bar.
            SeleniumSetMethods.EnterText("txt_comment", "Makeing a Appointment.", "Id");

            // Checking the value of The comment bar.
            Console.WriteLine("The value of comment is: " + SeleniumGetMethods.GetText("txt_comment", "Id"));

            // Click the book Appointment.
            SeleniumSetMethods.Click("btn-book-appointment", "Id");









        }

        [TearDown]
        public void closeTest()
        {
            // Waiting 5 sec and close the test.
            //Thread.Sleep(5000);
            //PropertiesCollection.driver.Close();

        }



        static void Main(string[] args)
        {
        }
    }
}



//public static void SelectDate(IWebDriver driver, string date)
//{
//    // Click on the calender.
//    Click(driver, "txt_visit_date", "Id");

//    // Devide the date to (Day, Month and Year).
//    DateTime desiredDate = DateTime.Parse(date);
//    string day = desiredDate.Day.ToString();
//    string month = desiredDate.Month.ToString("MMMM");
//    string year = desiredDate.Year.ToString();

//    // Navigate to correct year and month.
//    while (true)
//    {
//        // Get the month and year from calender.
//        string calenderMonth = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/table/thead/tr[2]/th[2]")).Text;
//        if (calenderMonth.Contains(year) && calenderMonth.Contains(month))
//            break;
//        else
//            Click(driver, "/html/body/div[2]/div[1]/table/thead/tr[2]/th[3]", "XPath");
//    }

//    // Click the right day.
//    driver.FindElement(By.XPath($"//td[@class='day' and text()='{day}']")).Click();


//}
