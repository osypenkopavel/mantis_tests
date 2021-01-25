using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : AuthTestBase
    {              
        
            [Test]
            public void AddProject()
            {

                 AccountData account = new AccountData()
                 {
                        Name = "administrator",
                        Password = "root"
                 };

                 List<AddData> oldProjects = appmanager.API.GetProjectsList(account);

                 AddData add = new AddData("Project Test Mantis");
                 add.Description = "Description Test";

                 appmanager.Project.Create(add);

                 List<AddData> newProjects = appmanager.API.GetProjectsList(account);

                 oldProjects.Add(add);
                 oldProjects.Sort();
                 newProjects.Sort();
                 Assert.AreEqual(oldProjects, newProjects);
            

            }        
    }
}


