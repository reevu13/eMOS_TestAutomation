using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMOS
{

    enum PropertyType
    {
        Id,
        CssSelector,
        LinkText
    }

    public static class Properties
    {
        public static IWebDriver Driver { get; set; }

        public static int  InactivePhase = Convert.ToInt32(ConfigurationManager.AppSettings["inactive-phase"]);

        public static int LittlePause = Convert.ToInt32(ConfigurationManager.AppSettings["little-phase"]);

        public static int VeryInactivePhase = Convert.ToInt32(ConfigurationManager.AppSettings["very-inactive-phase"]);

    }
}
