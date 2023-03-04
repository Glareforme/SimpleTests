using OpenQA.Selenium;
using SimpleTests.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTests.Support.PageActions
{
    public class ProductsPage
    {
        IWebDriver webDriver;
        public ProductsPage()
        {
            webDriver = BrowserHelper.GetBrowser();
        }

        public string CurrectPageUrl()
        {
            return webDriver.Url.ToString();
        }
    }
}
