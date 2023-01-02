using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public class Address
    {
        //ctor
        public Address()
        {
        }

        public Address(string firstName, string lasttName, string country, string city, string street)
        {
            FirstName = firstName;
            LasttName = lasttName;
            this.country = country;
            this.city = city;
            this.street = street;
        }

        //this is not tabel in the data base
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        
        public string country { get; set; }
        //city
        public string city { get; set; }
        public string street { get; set; }


    }
}
