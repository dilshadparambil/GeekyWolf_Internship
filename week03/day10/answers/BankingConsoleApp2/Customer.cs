using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp2
{
    public class Customer
    {
        //Add Customer
        //int Id
        //string FullName
        //string Email
        //string PhoneNumber
        //DateTime DateOfBirth

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();

        public Address Address { get; set; }
    }
}
