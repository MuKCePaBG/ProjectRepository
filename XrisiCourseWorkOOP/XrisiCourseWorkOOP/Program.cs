using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrisiCourseWorkOOP.Views;
using XrisiCourseWorkOOP.Tools;

namespace XrisiCourseWorkOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginView login = new LoginView();
            login.ShowView();
            MainView mainmenu = new MainView();
            mainmenu.ShowMenu(); 
            Console.ReadKey(true);
        }
    }
}
