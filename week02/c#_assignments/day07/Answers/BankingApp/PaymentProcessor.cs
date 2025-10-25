using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class PaymentProcessor
    {
        private IPaymentService PaymentService;
        public PaymentProcessor(IPaymentService paymentService) 
        { 
            PaymentService=paymentService;
        }

        public void ExecutePayment(double amount)
        {
            Console.WriteLine("\nPayment Processor: Initiating payment...");
            PaymentService.MakePayment(amount);
            Console.WriteLine("Payment Processor: Payment complete.");
        }
    }
}
