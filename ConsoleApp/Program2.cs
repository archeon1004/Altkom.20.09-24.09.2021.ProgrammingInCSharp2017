using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ConsoleApp
{
    class Program2
    {
        static void Main(string[] args)
        {

            var people = new Person[2];

            var person = new Person();
            person.SetFirstName("Ala");
            person[1] = "Alowska";

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(person[i]);
            }


            Hashtable prices = new Hashtable();
            prices.Add("Café au Lait", 1.99M);
            prices.Add("Caffe Americano", 1.89M);
            prices.Add("Café Mocha", 2.99M);
            prices.Add("Cappuccino", 2.49M);
            prices.Add("Espresso", 1.49M);
            prices.Add("Espresso Romano", 1.59M);
            prices.Add("English Tea", 1.69M);
            prices.Add("Juice", 2.89M);



            SomeDelegate someDelegate = null;
            someDelegate += FindDrinks;
            //someDelegate += FindDrinksUnsorted;

            if(someDelegate != null)
                someDelegate(prices);

            DoSth(FindDrinksUnsorted, prices);


            var service = new Service();

            service.ServiceStoppedEvent += Service_ServiceStoppedEvent;
            service.ServiceStoppedEvent -= Service_ServiceStoppedEvent;

            service.StopService("MainService", 1000);

            Console.ReadLine();
        }

        private static void Service_ServiceStoppedEvent(string name)
        {
            Console.WriteLine(name);
        }

        public delegate IEnumerable SomeDelegate(Hashtable hashTable);

        public static void DoSth(SomeDelegate someDelegate, Hashtable prices)
        {
            someDelegate(prices);
        }

        private static IEnumerable FindDrinksUnsorted(Hashtable prices)
        {
            ArrayList drinks2 = new ArrayList();
            foreach (string drink in prices.Keys)
            {
                if ((Decimal)prices[drink] < 2.00M)
                    drinks2.Add(drink);
            }
            return drinks2;
        }
        private static IEnumerable FindDrinks(Hashtable prices)
        {
            return from string drink in prices.Keys
                         where (Decimal)prices[drink] < 2.00M
                         orderby prices[drink]
                         select drink;
        }

    }
}
