using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Base;

namespace ConsoleApp
{
    class Program
    {
        static void Increment(int param)
        {
            //param = param + 1;
            param++;
        }

        struct Person
        {
            public string Name { get; set; }

            public void EditPerson()
            {
                Name = "Anna";
            }
        }

        static void EditPerson(ref Person person)
        {
            person.Name = "Ewa";
        }

        //TODO Correct
        static void Main(string[] args)
        {
            Mod2();
            Mod1();
        }

        private static void Mod2()
        {
            string value = "4e4";
            var myService = new Service();
            TryCatch(value, myService);

            int intValue = OutParameters(value);
            DefaultParameters(myService);
            ValueTypes();
        }

        private static void Mod1()
        {
            Console.WriteLine("Hello World!");
            ServiceReference.Service1Client service = Method1();
            NewMethod2(service);

            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
                NewMethod(key);

                Console.WriteLine(key == 'p' ? "p" : "none");

                int? b = null;
                var a = b ?? 1;

                var c = "asd";

                var l = 1l;
                b = l as int?;

                float f = 1.3f;
                double d;
                d = f;

                f = (float)d;

                l = System.Convert.ToInt64("1231213");

                l = long.Parse("123123");


                string @string = "a=" + a + ", b=" + b;
                @string = string.Format("a={0}, b={1}", a, b);
                @string = $"a={a}, b={b}"; // string interpolowany

                int[,,] array = new int[10, 5, 10];
                array[0, 0, 0] = 10;
                array[9, 4, 9] = 10;

                int[][] array2 = new int[3][];
                array2[0] = new int[2];
                array2[1] = new int[5];
                array2[2] = new int[10];
                array2[2] = new int[40];
                array2[2][39] = 12;


            } while (key != 'f');
        }

        private static void TryCatch(string value, Service myService)
        {
            try
            {
                ExecuteService(value, myService);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                if (!EventLog.SourceExists("Szkolenie 20483"))
                    EventLog.CreateEventSource("Szkolenie 20483", "ConsoleApp");

                EventLog.WriteEntry("Szkolenie 20483", e.Message);
            }
        }

        private static int OutParameters(string value)
        {
            int intValue;
            bool result = int.TryParse(value, out intValue);
            if (result)
            {
                Console.WriteLine($"int = {intValue}");
            }

            if (int.TryParse(value, out var myValue))
            {
                Console.WriteLine($"int = {myValue}");
            }

            return intValue;
        }

        private static void DefaultParameters(Service myService)
        {
            myService.StopService("serviceName", 5);
            myService.StopService("name", port: 433);
        }

        private static void ValueTypes()
        {
            int x = 15;
            Increment(x);

            var person = new Person();
            person.EditPerson();

            EditPerson(ref person);
        }

        private static void ExecuteService(string value, Service myService)
        {
            try
            {
                var intValue = int.Parse(value);
                if (myService.CompareData(intValue) == false)
                {
                    throw new Exception("Data not compatible");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            finally
            {
                myService.StopService();
            }
        }

        private static void NewMethod2(ServiceReference.Service1Client service)
        {
            Console.WriteLine(service.GetData(4));
        }

        private static ServiceReference.Service1Client Method1()
        {
            return new ServiceReference.Service1Client();
        }

        private static void NewMethod(char key)
        {
            switch (key)
            {
                case 'p':
                    Console.WriteLine("P");
                    break;
                case 'P':
                    Console.WriteLine("p");
                    break;
                default:
                    Console.WriteLine("none");
                    break;
            }
        }
    }
}
