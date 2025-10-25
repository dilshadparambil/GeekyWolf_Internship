using BankingApp;

IAccount Savings = new SavingsAccount();
Savings.Deposit(5000);
Savings.Withdraw(1000);

Console.WriteLine();

IAccount Current = new CurrentAccount();
Current.Deposit(10000);
Current.Withdraw(15000);
Current.Withdraw(8000);


IPaymentService creditCard = new CreditCardPayment();
PaymentProcessor processor1 = new PaymentProcessor(creditCard);
processor1.ExecutePayment(250.75);

IPaymentService upi = new UPIPayment();
PaymentProcessor processor2 = new PaymentProcessor(upi);
processor2.ExecutePayment(80.50);

IPaymentService netbanking = new NetBankingPayment();
PaymentProcessor processor3 = new PaymentProcessor(netbanking);
processor3.ExecutePayment(1200.00);