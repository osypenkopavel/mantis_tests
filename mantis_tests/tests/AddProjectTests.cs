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
                 List<AddData> oldProjects = appmanager.Project.GetProjectsList();

                 AddData add = new AddData("Project Test");
                 add.Description = "Description Test";

                 appmanager.Project.Create(add);

                 List<AddData> newProjects = appmanager.Project.GetProjectsList();

                 oldProjects.Add(add);
                 oldProjects.Sort();
                 newProjects.Sort();
                 Assert.AreEqual(oldProjects, newProjects);
            }        
    }
}


