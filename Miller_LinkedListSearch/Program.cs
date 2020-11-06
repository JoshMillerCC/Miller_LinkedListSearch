using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading file...");
            LinkedList list = LoadFile.FLoader();
            Console.WriteLine("File loaded! =D");
            Console.WriteLine("");

            bool menu = true;
            while(menu)
            {
                UserInterface.Menu();
                string userChoice = Console.ReadLine();
                UserInterface.MenuOptions(userChoice, list);
                Console.WriteLine();
            }

        }
    }
}