using BankingConsoleApp2;

AccountOperations operations = new AccountOperations();


var newCustomer = new Customer
{
    FullName = "John Doe",
    Email = "john.doe@example.com",
    PhoneNumber = "555-1234",
    DateOfBirth = new DateTime(1990, 1, 15),
    Address = new Address
    {
        Street = "123 Main St",
        City = "Anytown",
        State = "CA",
        PostalCode = "90210",
        Country = "USA"
    },

    Accounts = new List<Account>
    {
        new Account { AccountNumber = "ACC-001", Balance = 1500.00m }
    }
};
operations.Add(newCustomer);
operations.Display();

int newCustomerId = 1;
var secondAccount = new Account { AccountNumber = "CHK-777", Balance = 350.50m };
operations.AddAccount(newCustomerId, secondAccount);
operations.Display();


var updatedAddress = new Address
{
    Street = "456 New Ave",
    City = "New City",
    State = "NY",
    PostalCode = "10001",
    Country = "USA"
};
operations.AddAddress(newCustomerId, updatedAddress);
operations.Display();

int accountToDeleteId = 1;
operations.DeleteAccount(newCustomerId, accountToDeleteId);
operations.Display();