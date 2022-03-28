using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumVersionFix.BrowserFactory;

namespace SeleniumVersionFix.SwagLabs.LoginPage
{
    [TestClass]
    public class LoginExecutor
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        String Url = "https://www.saucedemo.com/";
        [TestMethod]
        [TestCategory("Regression")]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\SeleniumVersionFix\data.xml", "login", DataAccessMethod.Sequential)]


        public void LoginTest()
        {
          
            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();
            int heightN = Convert.ToInt32(height); //converting height from string to int
            int widthN = Convert.ToInt32(width);    //converting width from string to int

            String username = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();

            BrowserFactoryClass bfc = new BrowserFactoryClass(browser,Url,heightN,widthN,browserType,deleteCookies);

            Login l1 = new Login(bfc.driver);
            l1.loginSauceLab(username,password);
            bfc.driver.Close();
          


        }


    }
}
