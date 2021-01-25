﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, String baseURL) : base(manager) 
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.XPath("//tbody/tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name, Id = id 
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//form[@id='manage-user-delete-form']//span//input")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();            
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            return driver;
        }
    }
}
