using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IPaymentService
    {
        void MakePayment(double amount);
    }
    public class CreditCardPayment : IPaymentService
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Processing {amount} payment via Credit Card.");
        }
    }
    public class UPIPayment : IPaymentService
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Processing {amount} payment via Upi.");
        }
    }
    public class NetBankingPayment : IPaymentService
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Processing {amount} payment via Net Banking.");
        }
    }
    
}
