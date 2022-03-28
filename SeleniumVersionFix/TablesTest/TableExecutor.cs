using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumVersionFix.BrowserFactory;

namespace SeleniumVersionFix.TablesTest
{
    [TestClass]
    public class TableExecutor
    {
        String url = "https://seleniumpractise.blogspot.com/?msclkid=bbb2efdba91211ecb2da3c47d9131ac2";

        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }    

        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\saiffham\source\repos\SeleniumVersionFix\data.xml", "tableTest", DataAccessMethod.Sequential)]

        public void tableExecutor() {

            String browser = TestContext.DataRow["browser"].ToString();
            String height = TestContext.DataRow["height"].ToString();
            String width = TestContext.DataRow["width"].ToString();
            String browserType = TestContext.DataRow["browserType"].ToString();
            String deleteCookies = TestContext.DataRow["deleteCookies"].ToString();
            int heightN = Convert.ToInt32(height); //converting height from string to int
            int widthN = Convert.ToInt32(width);    //converting width from string to int


            BrowserFactoryClass browserFactory = new BrowserFactoryClass(browser, url, heightN, widthN, browserType, deleteCookies);

            Table t1 = new Table(browserFactory.driver);

            t1.tableData();


        }        


    }
}
