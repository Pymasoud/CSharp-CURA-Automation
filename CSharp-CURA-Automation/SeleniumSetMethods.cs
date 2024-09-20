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
        public static void Click(string element, string elementtype)
        {
            if (elementtype == "Id")
                PropertiesCollection.driver.FindElement(By.Id(element)).Click();
            else if (elementtype == "Name")
                PropertiesCollection.driver.FindElement(By.Name(element)).Click();
            else if (elementtype == "XPath")
                PropertiesCollection.driver.FindElement(By.XPath(element)).Click();
        }


        // Enter Text.
        public static void EnterText(string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            else if (elementtype == "Name")
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
            else if (elementtype == "XPath")
                PropertiesCollection.driver.FindElement(By.XPath(element)).SendKeys(value);
        }


        // Selecting a drop down control.
        public static void SelectDropDown(string element, string value, string elementtype)
        {
            if (elementtype == "Id")
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            else if (elementtype == "Name")
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
            else if (elementtype == "XPath")
                new SelectElement(PropertiesCollection.driver.FindElement(By.XPath(element))).SelectByText(value);
        }


        // Selecting a Date on the Calender.
        public static void SelectDate(string date)
        {
            // Click on the calender.
            Click("txt_visit_date", "Id");

            // Devide the date to (Day, Month and Year).
            DateTime desiredDate = DateTime.Parse(date);
            string day = desiredDate.Day.ToString();
            string month = desiredDate.Month.ToString("MMMM");
            string year = desiredDate.Year.ToString();

            // Navigate to correct year and month.
            while(true)
            {
                // Get the month and year from calender.
                string calenderMonth = PropertiesCollection.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/table/thead/tr[2]/th[2]")).Text;
                if (calenderMonth.Contains(year) && calenderMonth.Contains(month))
                    break;
                else
                    Click("/html/body/div[2]/div[1]/table/thead/tr[2]/th[3]", "XPath");
            }

            // Click the right day.
            PropertiesCollection.driver.FindElement(By.XPath($"//td[@class='day' and text()='{day}']")).Click();


        }

    }
}
