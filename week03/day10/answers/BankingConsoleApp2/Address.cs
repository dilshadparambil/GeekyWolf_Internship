using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp2
{
    public class Address
    {
        //Add Address class
        //Id
        //Street
        //City
        //State
        //PostalCode
        //Country

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country{ get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  
    }
}
