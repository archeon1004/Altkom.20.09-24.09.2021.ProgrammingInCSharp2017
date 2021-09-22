using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IBeverage
    {
        int GetServingTemperature(bool includesMilk);
        bool IsFairTrade { get; set; }
    }
    public class Coffee : IBeverage
    {
        public int ServingTempWithoutMilk { get; set; }
        public int ServingTempWithMilk { get; set; }

        public int GetServingTemperature(bool includesMilk)
        {
            //if (includesMilk)
            //{
            //    return ServingTempWithMilk;
            //}
            //else
            //{
            //    return ServingTempWithoutMilk;
            //}

            return includesMilk ? ServingTempWithMilk : ServingTempWithoutMilk;
        }
        public bool IsFairTrade { get; set; }

        // Other non-interface members go here.
    }
    public class Tea : IBeverage
    {
        public int ServingTemp { get; set; }

        public int GetServingTemperature(bool includesMilk)
        {
            return ServingTemp;
        }
        public bool IsFairTrade { get; set; }

        // Other non-interface members go here.
    }
}
