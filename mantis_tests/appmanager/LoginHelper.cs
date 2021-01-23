using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
            && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector("span[class='user-info']")).Text;
            return text;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span[class='user-info']"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span[class='user-info']")).Click();
            }
        }
    }
}
