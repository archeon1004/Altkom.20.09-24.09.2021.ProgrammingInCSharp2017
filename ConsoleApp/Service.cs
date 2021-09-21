using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Service
    {
        //public void StopService(string name)
        //{
        //    StopService(name, 1000);
        //}
        //public void StopService(string name, int delay)
        //{

        //}

            public bool CompareData(int param)
        {
            return new Random().Next() == param;
        }

            public void StopService()
        {

        }

        public void StopService(string name, int delay = 1000)
        {

        }

        public void StopService(string name, int delay = 1000, int port = 5000, int id = 1)
        {

        }
    }
}
