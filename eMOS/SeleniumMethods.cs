using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace eMOS
{
    public static class SeleniumMethods
    { 

        public static void ClearText(this IWebElement element)
        {
            element.Clear();
        }


        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }


        public static void  Clicks(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(300));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                Console.WriteLine($"could not find {element}");

                element.WaitUntil();
            }

            element.Click();
        }


        public static void SelectDropdown(this IWebElement element, string value)
        {
            try
            {
                new SelectElement(element).SelectByText(value);
            }
            catch (Exception e)
            {
                Console.WriteLine($"could not find {element}");

                element.SelectDropdown(value);
            }
        }


        public static void SelectIndex(this IWebElement element, int num)
        {
            
            try
            {
                new SelectElement(element).SelectByIndex(num);
            }
            catch (Exception e)
            {
                Console.WriteLine($"could not find {element}");

                element.SelectIndex(num);
            }
        }


        public static void WaitUntil(this IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(300));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));

                //wait.Until(RetryingElementLocator)
            }
            catch (Exception e)
            {
                Console.WriteLine($"could not find {element}");

                element.WaitUntil();
            }
            
        }

       
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");                        
        }

        public static string GetTextFromDdL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

    }
}
