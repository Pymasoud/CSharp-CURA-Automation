using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace CSharp_CURA_Automation
{
    internal class SeleniumSetMethods
    {
        // Click into a button, Checkbox, option etc.
        public static void Click(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "Id")
                driver.FindElement(By.Id(element)).Click();
            else if (elementtype == "Name")
                driver.FindElement(By.Name(element)).Click();
            else if (elementtype == "XPath")
                driver.FindElement(By.XPath(element)).Click();
        }


        // Enter Text.
        public static void EnterText(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            else if (elementtype == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);
            else if (elementtype == "XPath")
                driver.FindElement(By.XPath(element)).SendKeys(value);
        }


        // Selecting a drop down control.
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            else if (elementtype == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            else if (elementtype == "XPath")
                new SelectElement(driver.FindElement(By.XPath(element))).SelectByText(value);
        }


        // Selecting a Date on the Calender.
        public static void SelectDate(IWebDriver driver, string date)
        {
            // Click on the calender.
            Click(driver, "txt_visit_date", "Id");

            // Devide the date to (Day, Month and Year).
            DateTime desiredDate = DateTime.Parse(date);
            string day = desiredDate.Day.ToString();
            string month = desiredDate.Month.ToString("MMMM");
            string year = desiredDate.Year.ToString();

            // Navigate to correct year and month.
            while(true)
            {
                // Get the month and year from calender.
                string calenderMonth = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/table/thead/tr[2]/th[2]")).Text;
                if (calenderMonth.Contains(year) && calenderMonth.Contains(month))
                    break;
                else
                    Click(driver, "/html/body/div[2]/div[1]/table/thead/tr[2]/th[3]", "XPath");
            }

            // Click the right day.
            driver.FindElement(By.XPath($"//td[@class='day' and text()='{day}']")).Click();


        }

    }
}
