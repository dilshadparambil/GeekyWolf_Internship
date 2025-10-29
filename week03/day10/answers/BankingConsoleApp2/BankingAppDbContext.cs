using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankingConsoleApp2
{
    public class BankingAppDbContext : DbContext
    {
        //Create a BankingAppDbContext
        //Assign Connection string
        //Create DbSets for the models

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = @"Data Source=localhost,1433;Initial Catalog=bankingapp;User ID=sa;Password=qwer@1234;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(cs);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //Constraints:
        //    Customer
        //        FullName is mandatory and Max length of 100 chars
        //        Email is mandatory and max length 256 chars
        //    Address
        //        Street,City ,State ,PostalCode ,Country all mandatory and max length of 100 chars
        //    Account
        //        AccountNumber is mandatory and max length of 30 chars and unique

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.FullName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(256);

            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(a => a.Street).IsRequired().HasMaxLength(100);
                entity.Property(a => a.City).IsRequired().HasMaxLength(100);
                entity.Property(a => a.State).IsRequired().HasMaxLength(100);
                entity.Property(a => a.PostalCode).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Country).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(a => a.AccountNumber).IsRequired().HasMaxLength(30);
                entity.HasIndex(a => a.AccountNumber).IsUnique();
            });

            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.Address) // A Customer has one Address
                .WithOne(address => address.Customer) // An Address has one Customer
                .HasForeignKey<Address>(address => address.CustomerId);
        }
    }
}
