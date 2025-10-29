

using BankingConsoleApp;

var operations = new AccountOperations();


operations.populateInitialData();
operations.Display();

operations.Update(1, "789 Market St, San Francisco, USA");
operations.Display();

operations.Delete(5);
operations.Display();

var newCustomer = new Customer
{
    FullName = "Dilshad P",
    Email = "abc@123.com",
    PhoneNumber = "555-1234",
    DateOfBirth = new DateTime(2002, 04, 02),
    Address = "1 qwerty asdf",
    CreatedDate = DateTime.Now
};
operations.Add(newCustomer);
operations.Display();