using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace CSharp_CURA_Automation
{
    internal class SeleniumGetMethods
    {
        // This Class will hold all the get operations.

        public static string GetText(string element, string elementtype)
        {
            if (elementtype == "Id")
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            else if (elementtype == "Name")
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            else return string.Empty;
        }


        public static string GetTextFromDDL(string element, string elementtype)
        {
            if (elementtype == "Id")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            else if (elementtype == "Name")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else return string.Empty;
        }

    }
}
