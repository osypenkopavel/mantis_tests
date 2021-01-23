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

        public static bool PERFORM_LONG_UI_CHECKS = true;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            appmanager = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
        public static string GenerateRandomDate()
        {
            int date = rnd.Next(1, 12);
            return date.ToString();
        }
        public static string GenerateRandomMonth()
        {
            var monthList = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            var month = monthList[rnd.Next(monthList.Count)];
            return month.ToString();
        }
        public static string GenerateRandomYear()
        {
            int date = rnd.Next(1900, 2030);
            return date.ToString();
        }

    }
}
