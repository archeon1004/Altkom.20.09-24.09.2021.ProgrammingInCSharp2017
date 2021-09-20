using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var service = new ServiceReference.Service1Client();
            Console.WriteLine(  service.GetData(4)  );

            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
            } while (key != 'f');
        }
    }
}
