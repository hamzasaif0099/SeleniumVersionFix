using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumVersionFix.SwagLabs.Inventorypage
{
    public class Inventory
    {

        public IWebDriver driver = null;

        public Inventory(IWebDriver driver) {
            this.driver = driver;
        
        }

        IList<IWebElement> filterList = new List<IWebElement>();
        List<String> listNew = new List<String>();

        //TEST CASE DISCRIPTION: Method for validating applied filter

        public void dropdownMethod(String appliedFilter) {


            if (appliedFilter == "a-z")
            {

                filterAZ();

            }
            else if (appliedFilter == "z-a") { 
            
                filterZA();
            
            }

            

           
        }



        public void filterAZ() {

            //inventory item names     //default product names
            filterList = driver.FindElements(By.XPath("//div[@class='inventory_list']//div[@class='inventory_item_name']"));
            //IList clone into plain list //yahan paste

            foreach (var i in filterList)
            {

                listNew.Add(i.Text);

            }
            listNew.Sort();


            fil(filterList);


        }

        public void filterZA() {

            IWebElement element = driver.FindElement(By.ClassName("product_sort_container"));
            SelectElement s1 = new SelectElement(element);
            s1.SelectByIndex(1);

            filterList = driver.FindElements(By.XPath("//div[@class='inventory_list']//div[@class='inventory_item_name']"));
            foreach (var i in filterList)
            {

                listNew.Add(i.Text);
                
            }
            listNew.Sort();
            listNew.Reverse();
            
            Console.WriteLine("PRINT AFTER Z _ A");

            filterList = driver.FindElements(By.XPath("//div[@class='inventory_list']//div[@class='inventory_item_name']"));

           
            fil(filterList);
                
        }


        public void fil(IList<IWebElement> e1) {

            for (int i = 0; i < e1.Count; i++)
            {

                if (e1[i].Text == listNew[i])
                {
                    Assert.AreEqual(e1[i].Text, listNew[i]);


                }

            }


        }

    }
}

