using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumVersionFix.TablesTest
{
    public class Table
    {

        public IWebDriver driver = null;

        public Table(IWebDriver driver) { 
        
                this.driver = driver;
        
        }
        public void tableData() {

            IList<IWebElement> all = new List<IWebElement>();
            all = driver.FindElements(By.XPath("//table[@id='customers']//td"));

            Boolean result = false;
            foreach (var i in all) {
            
                if (i.Text == "USA") {

                    //result = "TRUE";
                    result = true;

                }   

            }

            Assert.IsTrue(result);

        }




    }
}
