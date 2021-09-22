using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public struct Person
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

        public DateTime BirthDate { get; set; }

        public string this[int index]
        {
            get {
                switch (index) {
                    case 0:
                        return GetFirstName();
                    case 1:
                        return LastName;
                    case 2:
                        return BirthDate.ToString();
                    default:
                        return null;
                };
            }
            set {
                switch (index)
                {
                    case 0:
                        SetFirstName(value);
                        break;
                    case 1:
                        LastName = value;
                        break;
                    case 2:
                        BirthDate =  DateTime.Parse(value);
                        break;
                };
            }
        }
    }
}
