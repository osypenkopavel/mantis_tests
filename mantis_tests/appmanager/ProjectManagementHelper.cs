using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }
        public List<AddData> GetProjectsList()
        {
            List<AddData> projects = new List<AddData>();
            manager.Menu.GoToProjectManagement();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//td/a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new AddData(element.Text));
            }
            return projects;
        }

        public ProjectManagementHelper CreateProjectIfAbsent(AddData add)
        {
            if (IfProjectPresent())
            {
                return this;
            }
            Create(add);
            return this;
        }
        private bool IfProjectPresent()
        {
            manager.Menu.GoToProjectManagement();
            if (IsElementPresent(By.XPath("//td/a")))
            {
                return true;
            }
            return false;
        }

        public void Create(AddData add)
        {
            manager.Menu.GoToProjectManagement();
            driver.FindElement(By.XPath("//form[@action ='manage_proj_create_page.php']")).Click();
            Type(By.Name("name"), add.ProjectName);
            Type(By.Name("description"), add.Description);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
                

        internal void Remove(int v)
        {
            manager.Menu.GoToProjectManagement();
            SelectProject(v);
            driver.FindElement(By.Id("project-delete-form")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public ProjectManagementHelper SelectProject(int index)
        {            
            driver.FindElement(By.XPath("(//td//a)[" + (index + 1) + "]")).Click();
            return this;
        }
    }   

}
