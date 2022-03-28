using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SeleniumVersionFix.BrowserFactory
{
    public class BrowserFactoryClass
    {
        
            public IWebDriver driver;
        //  String deletecookies = "";
        ChromeOptions options = new ChromeOptions();
        EdgeOptions options1 = new EdgeOptions();
        public BrowserFactoryClass(String Browser, String Url, int height, int width, String browserType, String deleteCookies) {

            if (browserType.Equals("Headless", StringComparison.InvariantCultureIgnoreCase))
            {
                options.AddArgument("--headless");

                driver = new ChromeDriver(options);
                driver.Url = Url;
            }

            else
            {

    
                if (Browser.Equals("Chrome", StringComparison.InvariantCultureIgnoreCase))
                {

                    driver = new ChromeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();

                    }
                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }

                else if (Browser.Equals("Edge", StringComparison.InvariantCultureIgnoreCase))
                {
                    driver = new EdgeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    if (deleteCookies.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                    {
                        cookiesDelete();
                    }

                    driver.Manage().Window.Size = new System.Drawing.Size(height, width);
                    driver.Url = Url;

                }

            }


        }
        public void cookiesDelete()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

    }
}
