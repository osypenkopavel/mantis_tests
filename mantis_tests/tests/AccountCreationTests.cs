using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{
    
    [TestFixture]
    public class AccountCreationTests : TestBase

    {              
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            appmanager.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(@"config_inc.php", FileMode.Open))
            {
                appmanager.Ftp.Upload("/config_inc.php", localFile);
            }               

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData("testuser", "password")
            {                
                Email = "testuser@localhost.localdomain"
            };
            appmanager.Registration.Register(account);
        }

        [OneTimeTearDown]

        public void restoreConfig()
        {
            appmanager.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }

   
}
