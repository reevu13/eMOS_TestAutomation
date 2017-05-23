using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TestProject
{
    [TestClass]

    public class Test
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            Console.WriteLine("Starting...");
        }

        [Test]

        public void Testing()
        {

            //driver.Url = "http://172.16.0.200:8300/login.aspx/";
            driver.Url = "http://google.com/";

            String Tittle = driver.Title;

            int TittleLength = driver.Title.Length;

            Console.WriteLine("Page tittle : " + Tittle);

            Console.WriteLine("Tittle length " + TittleLength);

            String PageURL = driver.Url;

            int URLLength = PageURL.Length;

            Console.WriteLine("URL of the page is : " + PageURL);

            Console.WriteLine("Length of the URL is : " + URLLength);

            String PageSource = driver.PageSource;

            int PageSourceLength = driver.PageSource.Length;

            Console.WriteLine("Page Source of the page is : " + PageSource);

            Console.WriteLine("Length of the Page Source is : " + PageSourceLength);

            driver.Quit();
        }

        [TearDown]

        public void EndTest()
        {
            driver.Close();
        }
    }
}
