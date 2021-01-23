using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {

        }
        internal void GoToProjectManagement()
        {    
              
            driver.FindElement(By.XPath("//i[contains(@class,'gears')] ")).Click();            
            driver.FindElement(By.XPath("//div[2]/div[2]/div/ul/li[3]")).Click();
        }
    }
}
