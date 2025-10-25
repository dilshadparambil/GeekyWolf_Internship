using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day3
{
    public class BankAccount
    {
        /// <summary>
        /// Create a class BankAccount(AccountNumber, AccountHolder, Balance ) with
        /// default and parameterized constructors using constructor chaining. 
        /// Add Deposit() which increments the balance and DisplayBalance() to display the account details methods.
        /// </summary>
        /// 

        public long AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public double Balance { get; set; }

        double accDeposit;
        public BankAccount() : this(1000001,"test user",0) 
        {
        
        }

        public BankAccount(long accountNumber, string accountHolder)
        {
            this.AccountNumber = accountNumber;
            this.AccountHolder = accountHolder;
        }
        public BankAccount(long accountNumber, string accountHolder, double balance) : this(accountNumber, accountHolder)
        {
            this.Balance = balance;
        }

        public void Deposit()
        {
            Console.Write("Enter deposit amount : ");
            double.TryParse(Console.ReadLine(), out accDeposit);
            this.Balance += accDeposit;
            Console.WriteLine($"Successfully deposited {accDeposit}\nnew balance is {this.Balance}");
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {this.AccountNumber}\nAccount Holder: {this.AccountHolder}\nBalance: {this.Balance}");
            Console.WriteLine();
        }
    }
    
}
