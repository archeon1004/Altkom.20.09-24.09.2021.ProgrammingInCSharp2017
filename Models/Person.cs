using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    struct Person
    {
        private string _firstname;

        private string GetFirstName()
        {
            return _firstname;
        }

        public void SetFirstName(string value)
        {
            _firstname = value;

        }


        public string LastName { private get; set; }
    }
}
