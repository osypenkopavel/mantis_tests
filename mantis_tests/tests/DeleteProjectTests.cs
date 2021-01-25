using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class DeleteProjectTests : AuthTestBase
    {

        [Test]
        public void DeleteProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            bool projectExists = appmanager.API.GetProjectsList(account).Any();

            if (!projectExists)
            {
                appmanager.API.CreateProject(account);
            }

            AddData add = new AddData("Project Test");
            add.Description = "Description Test";

            appmanager.Project.CreateProjectIfAbsent(add);

            List<AddData> oldProjects = appmanager.API.GetProjectsList(account);

            appmanager.Project.Remove(0);

            List<AddData> newProjects = appmanager.API.GetProjectsList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}