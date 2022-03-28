using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumVersionFix.BrowserFactory;
using SeleniumVersionFix.SwagLabs.LoginPage;

namespace SeleniumVersionFix.SwagLabs.Inventorypage
{   
    [TestClass]
    public class InventoryExecutor
    {
        public TestContext instance;
        
        public TestContext TestContext
        { 
         
            set { instance = value; }
            get { return instance; }
        
        }

        string Url = "https://www.saucedemo.com/";

        [TestMethod,TestCategory("smoke")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\SeleniumVersionFix\data.xml", "dropdown", DataAccessMethod.Sequential)]
        public void dropdownExecutor() {


            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();
            int heightN = Convert.ToInt32(height); //converting height from string to int
            int widthN = Convert.ToInt32(width);    //converting width from string to int

            String username = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();

            String appliedFilter = TestContext.DataRow["appliedFilter"].ToString();

          
            BrowserFactoryClass factory = new BrowserFactoryClass(browser, Url, heightN, widthN, browserType, deleteCookies);

            Login login = new Login(factory.driver);
            login.loginSauceLab(username, password);

            Inventory inventory = new Inventory(factory.driver);
            inventory.dropdownMethod(appliedFilter);
            factory.driver.Close();



        }         
        
        //[TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\SeleniumVersionFix\data.xml", "dropdown", DataAccessMethod.Sequential)]

        //public void filterValidation()
        //{

        //    String browser = TestContext.DataRow["browser"].ToString();
        //    String height = TestContext.DataRow["height"].ToString();
        //    String width = TestContext.DataRow["width"].ToString();
        //    String browserType = TestContext.DataRow["browserType"].ToString();
        //    String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();
        //    int heightN = Convert.ToInt32(height); //converting height from string to int
        //    int widthN = Convert.ToInt32(width);    //converting width from string to int

        //    String username = TestContext.DataRow["username"].ToString();
        //    String password = TestContext.DataRow["password"].ToString();
        //   // String filterOption = TestContext.DataRow["filterOption"].ToString();
        //    String appliedFilter = TestContext.DataRow["appliedFilter"].ToString();



        //    BrowserFactoryClass factory = new BrowserFactoryClass(browser, Url, heightN, widthN, browserType, deleteCookies);

        //    Login login = new Login(factory.driver);
        //    login.loginSauceLab(username, password);

        //    Inventory inventory = new Inventory(factory.driver);
        //    inventory.filter(appliedFilter);

        //    factory.driver.Close(); 


        //}    


    }
}
