using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Extensions
{
    public static class CoffeeExtensions
    {
        public static bool IsServingTemperatureHigherThan(this Coffee coffee, bool milk, int temperature)
        {
            return coffee.GetServingTemperature(milk) > temperature;
        }
    }
}
