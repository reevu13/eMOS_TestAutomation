using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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

    class Properties
    {
        public static IWebDriver Driver { get; set; }
                       
    }
}
