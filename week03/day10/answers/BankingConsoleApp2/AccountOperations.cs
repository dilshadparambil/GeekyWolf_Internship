using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp2
{
    public class AccountOperations
    {
        BankingAppDbContext context = new BankingAppDbContext();

        public void Add(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
            Console.WriteLine($"Added customer {customer.FullName}.\n");
        }
        public void Display()
        {
            List<Customer> customers = context.Customer.Include(c => c.Address).Include(c => c.Accounts).ToList();

            foreach (var customer in customers)
            {

                string addressString = "No Address on file";
                if (customer.Address != null)
                {
                    addressString = $"{customer.Address.Street},{customer.Address.City},{customer.Address.State},{customer.Address.PostalCode},{customer.Address.Country}";
                }

                if (customer.Accounts.Any())
                {
                    foreach (var account in customer.Accounts)
                    {
                        Console.WriteLine($"Customer Name : {customer.FullName}; Address : {addressString}; Account : {account.AccountNumber} ({account.Balance})");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine($"Customer Name : {customer.FullName}; Address : {addressString}; Account : No accounts on file\n");
                }
            }
            Console.WriteLine("\n");
        }
        public void AddAddress(int customerId, Address newAddress)
        {

            var existingAddress = context.Address.FirstOrDefault(a => a.CustomerId == customerId);

            if (existingAddress == null)
            {
                newAddress.CustomerId = customerId;
                context.Address.Add(newAddress);
                Console.WriteLine("Added new address.\n");
            }
            else
            {
                existingAddress.Street = newAddress.Street;
                existingAddress.City = newAddress.City;
                existingAddress.State = newAddress.State;
                existingAddress.PostalCode = newAddress.PostalCode;
                existingAddress.Country = newAddress.Country;
                Console.WriteLine("Updated existing address.\n");
            }

            context.SaveChanges();

        }

        public void AddAccount(int customerId, Account newAccount)
        {
            var customer = context.Customer.Find(customerId);
            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {customerId} not found.\n");
            }
            else
            {
                newAccount.CustomerId = customerId;
                context.Account.Add(newAccount);
                context.SaveChanges();
                Console.WriteLine($"Added new account {newAccount.AccountNumber} to {customer.FullName}.\n");
            }

        }

        public void DeleteAccount(int customerId, int accountId)
        {
            var accountToDelete = context.Account.FirstOrDefault(a => a.CustomerId == customerId && a.Id == accountId);

            if (accountToDelete != null)
            {
                context.Account.Remove(accountToDelete);
                context.SaveChanges();
                Console.WriteLine($"Deleted account {accountToDelete.AccountNumber}.\n");
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }

        }


    }
}
