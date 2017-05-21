using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrisiCourseWorkOOP.Tools;
using XrisiCourseWorkOOP.Entity;


namespace XrisiCourseWorkOOP.Views
{
    class LoginView
    {
        public void ShowView()
        {
            while (true)
            {
                Console.WriteLine(" *\u2665 Xrisi's Diary \u2665*\n   [L]ogin [M]enu\n");
                Console.Write("Username:");
                string user = Console.ReadLine();
                Console.Write("Password:");
                PassMask inst = new PassMask();
                string pass = inst.ReadPassword();

                if (user==OUAP.Username && pass==OUAP.Password)
                {
                    Console.Write("\nWelcome back {0} \u2665\u2665\u2665", OUAP.OwnerName);
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Write("Incorrect input ! Try again ...");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
        }
    }
}
