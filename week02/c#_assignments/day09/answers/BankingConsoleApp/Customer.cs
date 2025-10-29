using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp
{
    //Create a Banking Console App.
    //Add Customer
    //int Id
    //string FullName
    //string Email
    //string PhoneNumber
    //DateTime DateOfBirth

    public class Customer
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class BankingAppDbContext : DbContext
    {
        //Create a BankingAppDbContext
        //Assign Connection string
        //Create DbSet for Customer

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = @"Data Source=localhost,1433;Initial Catalog=adodb;User ID=sa;Password=qwer@1234;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(cs);
        }
    }

    

    public class AccountOperations
    {
        BankingAppDbContext context = new BankingAppDbContext();

        public void populateInitialData()
        {
            if (context.Customers.Any())
            {
                Console.WriteLine("Database already contains data\n");
                return;
            }
            var customers = new List<Customer>
            { 
                new Customer { FullName = "John Smith", Email = "john.smith@email.com", PhoneNumber = "-857", DateOfBirth = new DateTime(1987, 4, 12), Address = "123 Main St, New York, USA", CreatedDate = new DateTime(2025, 1, 1) },
                new Customer { FullName = "Maria Gonzalez", Email = "maria.gonzalez@gmail.com", PhoneNumber = "-1601", DateOfBirth = new DateTime(1990, 8, 25), Address = "45 Calle Mayor, Madrid, Spain", CreatedDate = new DateTime(2025, 2, 15) },
                new Customer { FullName = "Liam O’Connor", Email = "liam.oconnor@outlook.com", PhoneNumber = "-907779", DateOfBirth = new DateTime(1985, 11, 3), Address = "89 Abbey Rd, London, UK", CreatedDate = new DateTime(2025, 3, 10) },
                new Customer { FullName = "Sophia Müller", Email = "sophia.mueller@gmail.com", PhoneNumber = "-2345780", DateOfBirth = new DateTime(1992, 7, 18), Address = "22 Berliner Str, Berlin, Germany", CreatedDate = new DateTime(2025, 4, 5) },
                new Customer { FullName = "Ethan Brown", Email = "ethan.brown@yahoo.com", PhoneNumber = "-1374", DateOfBirth = new DateTime(1989, 2, 14), Address = "17 King St, Sydney, Australia", CreatedDate = new DateTime(2025, 5, 1) }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine($"SUCCESS: Added customer {customer.FullName}.\n");
        }

        public void Update(int customerId, string newAddress)
        {
            var customer = context.Customers.Find(customerId);

            if (customer == null)
            {
                Console.WriteLine($"ERROR: Customer with ID {customerId} not found.\n");
                return;
            }

            customer.Address = newAddress;
            context.SaveChanges();
            Console.WriteLine($"SUCCESS: Updated address for {customer.FullName}.\n");
        }

        public void Delete(int customerId)
        {
            var customer = context.Customers.Find(customerId);

            if (customer == null)
            {
                Console.WriteLine($"ERROR: Customer with ID {customerId} not found.\n");
                return;
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            Console.WriteLine($"SUCCESS: Deleted customer {customer.FullName}.\n");
        }

        public void Display()
        {
            List<Customer> customers = context.Customers.ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers found in the database.\n");
                return;
            }

            foreach (var c in customers)
            {
                Console.WriteLine($"ID: {c.Id} | Name: {c.FullName} | Email: {c.Email}");
                Console.WriteLine($"  Address: {c.Address}");
                Console.WriteLine($"  Created: {c.CreatedDate.ToShortDateString()}");
            }
            Console.WriteLine("\n");
        }
    }

}
