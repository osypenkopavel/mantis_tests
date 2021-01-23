using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase 
    {
        protected ApplicationManager appmanager;        

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            appmanager = ApplicationManager.GetInstance();
        }        

    }
}
