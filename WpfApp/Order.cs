using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Order : ICloneable
    {
        public DateTime DateTime { get; set; }

        public string Beverage { get; set; }
        public string Milk { get; set; }
        public string Sugar { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
