using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IAccount
    {
        void Deposit(double amount);
        void Withdraw(double amount);
        double GetBalance();

    }

    public class SavingsAccount : IAccount
    {
        private double balance;
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount} into Savings. New balance: {balance}");
        }
        public void Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount:C} from Savings. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds in Savings Account.");
            }
        }
        public double GetBalance()
        {
            return balance;
        }
    }
    public class CurrentAccount : IAccount
    {
        private double balance;
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount} into Current. New balance: {balance}");
        }
        public void Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount:C} from Current. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds in Current Account.");
            }
        }
        public double GetBalance()
        {
            return balance;
        }
    }

}
