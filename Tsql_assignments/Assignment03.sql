
-- String Functions

-- Create database (optional)
CREATE DATABASE StringFunctionsDB;
GO
USE StringFunctionsDB;
GO


-- 1. Extract the middle 3 characters from the string 'ABCDEFG'.
select substring('ABCDEFG',3,3) as middlecharacters;

-- 2. From a table 'Employees' with a column 'FullName', write a query to extract the first name (assuming it's always the first word before a space).
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    FullName AS (FirstName + ' ' + LastName),
    Email VARCHAR(100)
);

INSERT INTO Employees (FirstName, LastName, Email) VALUES
('John', 'Doe', 'john.doe@example.com'),
('Jane', 'Smith', 'jane.smith@company.org'),
('Michael', 'Johnson', 'michael.j@work.net'),
('Alexander', 'Hamilton', 'alex.hamilton@republic.us'),
('Christopher', 'Thompson', 'c.thompson@enterprise.com');

select substring(fullname,1,charindex(' ',FullName)) from Employees as firstname;

-- 3. Extract the first 5 characters from the string 'SQL Server 2022'.
select left('SQL Server 2022',5) as result;

-- 4. From a 'Products' table with a 'ProductCode' column, write a query to get the first 3 characters of each product code.
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    ProductCode VARCHAR(20),
    ProductDescription VARCHAR(200)
);

INSERT INTO Products (ProductName, ProductCode, ProductDescription) VALUES
('Apple iPhone 15', 'IPH001', 'Latest Apple Smartphone'),
('Samsung Galaxy S24', 'SAM002', 'High-end Android phone'),
('Dell Laptop XPS13', 'DEL003', 'Powerful ultrabook for professionals'),
('Sony Headphones WH1000', 'SON004', 'Noise Cancelling Headphones'),
('HP Printer 5200', 'HP005', 'Office printer with scanning features');

select left(ProductCode,3) from products;

-- 5. Extract the last 4 characters from the string 'ABCDEFGHIJKL'.
select right('ABCDEFGHIJKL',4);

-- 6. From an 'Orders' table with an 'OrderID' column (format: ORD-YYYY-NNNN), write a query to extract just the numeric portion at the end.
CREATE TABLE Orders (
    OrderID VARCHAR(20) PRIMARY KEY,
    CustomerID INT,
    OrderTotal DECIMAL(10,2)
);

INSERT INTO Orders (OrderID, CustomerID, OrderTotal) VALUES
('ORD-2023-0001', 1, 1299.99),
('ORD-2023-0002', 2, 499.50),
('ORD-2024-0003', 3, 1999.00),
('ORD-2024-0004', 4, 250.75),
('ORD-2025-0005', 5, 875.00);

select right(orderid,4) from orders;

-- 7. Write a query to find the length of the string 'SQL Server Functions'.
select len('SQL Server Functions');

-- 8. From a 'Customers' table, find customers whose names are longer than 20 characters.
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100)
);

INSERT INTO Customers (CustomerName, Email) VALUES
('Global Enterprises International', 'info@globalenterprises.com'),
('John Carter', 'john.carter@gmail.com'),
('Alexander Maximillian Johnson', 'alex.max.j@gmail.com'),
('Tech Solutions Inc', 'contact@techsolutions.io'),
('Sarah Annabella Thompson', 'sarah.anna@example.com');

select CustomerName from customers where len(customername)>20;

-- 9. Compare the results of character count and byte count for the string 'SQL Server' with a trailing space.
select len('SQL Server  ') as charactercount, datalength('SQL Server  ') as bytecount;

-- 10. Write a query to find the byte count of an empty string and explain the result.
select datalength('') as bytecount; -- gives 0 as output

-- 11. Find the position of 'Server' in the string 'Microsoft SQL Server'.
select charindex('Server','Microsoft SQL Server')

-- 12. From an 'Emails' table, write a query to extract the domain name from email addresses.
CREATE TABLE Emails (
    EmailID INT IDENTITY(1,1) PRIMARY KEY,
    EmailAddress VARCHAR(100)
);

INSERT INTO Emails (EmailAddress) VALUES
('user1@gmail.com'),
('employee@company.org'),
('customer123@shop.net'),
('test.user@sample.com'),
('maskme@domain.co');

select substring(emailaddress,charindex('@',emailaddress)+1,len(emailaddress)) from emails as domain;

-- 13. Find the position of the first number in the string 'ABC123DEF456'.
select patindex('%[0-9]%','ABC123DEF456');

-- 14. Write a query to find all product names from a 'Products' table that contain a number.
select productname from products where productname like '%[0-9]%';

-- 15. Join the strings 'SQL', 'Server', and '2022' with spaces between them.
select CONCAT_WS(' ','SQL','Server','2022')

-- 16. From 'Employees' table with 'FirstName' and 'LastName' columns, create a 'FullName' column.
select firstname+' '+lastname as fullname from employees;

-- 17. Join the array ('SQL', 'Server', '2022') with a hyphen as the separator.
select concat_ws('-','SQL', 'Server', '2022')

-- 18. From an 'Addresses' table, combine 'Street', 'City', 'State', and 'ZIP' columns into a single address string.
CREATE TABLE Addresses (
    AddressID INT IDENTITY(1,1) PRIMARY KEY,
    Street VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50),
    ZIP VARCHAR(10)
);

INSERT INTO Addresses (Street, City, State, ZIP) VALUES
('123 Main St', 'New York', 'NY', '10001'),
('456 Elm St', 'Los Angeles', 'CA', '90001'),
('789 Pine Ave', 'Chicago', 'IL', '60601'),
('101 Maple Rd', 'Houston', 'TX', '77001'),
('202 Oak Blvd', 'Miami', 'FL', '33101');

select Street+','+City+','+State+','+ZIP as address from Addresses

-- 19. Change all occurrences of 'a' to 'e' in the string 'database management'.
select replace('database management','a','e')

-- 20. From a 'Products' table, write a query to replace all spaces in product names with underscores.
select replace(productname,' ','_') from Products

-- 21. Create a string of 10 asterisks (*).
select replicate('*',10)

-- 22. Write a query to pad all product codes in a 'Products' table to a length of 10 characters with leading zeros.
select replicate('0',10-datalength(productcode))+productcode from products

-- 23. Insert the string 'New ' at the beginning of 'York City'.
select 'New ' + 'York City'

-- 24. From an 'Emails' table, mask the username part of email addresses, showing only the first and last characters.
select 
	left(emailaddress,1)+
	'***'+
	substring(emailaddress,CHARINDEX('@',emailaddress)-1,len(emailaddress))
from emails

-- 25. Convert the string 'sql server' to uppercase.
select upper('sql server')

-- 26. Write a query to convert all customer names in a 'Customers' table to uppercase.
select upper(customername) from customers

-- 27. Convert the string 'SQL SERVER' to lowercase.
select lower('SQL SERVER')

-- 28. From a 'Products' table, write a query to convert all product descriptions to lowercase.
select lower(productdescription) from products

-- 29. Remove trailing spaces from the string 'SQL Server    '.
select rtrim('SQL Server    ')

-- 30. Write a query to remove trailing spaces from all email addresses in an 'Employees' table.
select rtrim(email) from employees

-- 31. Remove leading spaces from the string '   SQL Server'.
select ltrim('   SQL Server')

-- 32. From a 'Comments' table, write a query to remove leading spaces from all comment texts.
CREATE TABLE Comments (
    CommentID INT IDENTITY(1,1) PRIMARY KEY,
    CommentText VARCHAR(200)
);

INSERT INTO Comments (CommentText) VALUES
('   Excellent service!'),
('   Product arrived late but good quality'),
('Fast delivery, great packaging'),
('   Could be better in support response'),
('Amazing!    ');

select ltrim(commenttext) from comments

-- 33. Display the current date in the format 'dd-MM-yyyy'.
select format(GETDATE(),'dd-MM-yyyy')

-- 34. From an 'Orders' table with an 'OrderTotal' column, display the total as a currency with 2 decimal places.
select format(ordertotal,'c','en-in') from orders

-- 35. Separate the string 'apple,banana,cherry' into individual fruits.
select * from string_split('apple,banana,cherry',',')

-- 36. From a 'Skills' table with a 'SkillList' column containing comma-separated skills, write a query to create a row for each individual skill.
CREATE TABLE Skills (
    SkillID INT IDENTITY(1,1) PRIMARY KEY,
    SkillList VARCHAR(200)
);

INSERT INTO Skills (SkillList) VALUES
('SQL,Python,Excel'),
('HTML,CSS,JavaScript'),
('C#,ASP.NET,Azure'),
('Project Management,Communication,Leadership'),
('Machine Learning,Data Science,AI');

select skillid,value from skills cross apply string_split(SkillList,',')




-- Date and Time Functions

-- 37. Write a query to display the current date and time.
select sysdatetime()

-- 38. From an 'Orders' table, find all orders placed in the last 24 hours.
ALTER TABLE Orders
ADD OrderDate DATETIME DEFAULT GETDATE(),
    ShipDate DATETIME NULL;

UPDATE Orders
SET OrderDate = DATEADD(DAY, -CAST(RIGHT(OrderID, 4) AS INT) % 5, GETDATE()),
    ShipDate = DATEADD(DAY, CAST(RIGHT(OrderID, 4) AS INT) % 3, GETDATE());

select * from orders where orderdate >= dateadd(hour,-24,getdate())

-- 39. Display the current UTC date and time.
select sysutcdatetime()

-- 40. Write a query to show the time difference between local time and UTC time.
select datediff(hour,getutcdate(),getdate())

-- 41. Convert the current date and time to 'Pacific Standard Time'.
select switchoffset(sysdatetimeoffset(),'-08:00')

-- 42. From a 'Flights' table with a 'DepartureTime' column in UTC, convert all departure times to 'Eastern Standard Time'.
CREATE TABLE Flights (
    FlightID INT IDENTITY PRIMARY KEY,
    DepartureTime DATETIMEOFFSET
);

INSERT INTO Flights (DepartureTime) VALUES
(SYSDATETIMEOFFSET()), 
(DATEADD(HOUR, 5, SYSDATETIMEOFFSET())),
(DATEADD(DAY, 1, SYSDATETIMEOFFSET()));

select departuretime as utc,switchoffset(departuretime,'-05:00') as est from flights

-- 43. Add 3 months to the current date.
select dateadd(month,3,getdate())

-- 44. From an 'Employees' table, write a query to calculate each employee's retirement date (65 years from their 'DateOfBirth').
ALTER TABLE Employees
ADD DateOfBirth DATE NULL,
    HireDate DATE NULL;

UPDATE Employees
SET DateOfBirth = DATEADD(YEAR, - (30 + EmployeeID * 3), GETDATE()),
    HireDate = DATEADD(YEAR, - (EmployeeID % 5), GETDATE());

select fullname,dateadd(year,65,dateofbirth) as RetirementDate from employees

-- 45. Calculate the number of days between '2023-01-01' and '2023-12-31'.
select datediff(day,'2023-01-01','2023-12-31')

-- 46. From an 'Orders' table, find the average number of days between order date and ship date.
select avg(datediff(day,orderdate,shipdate)) from orders

-- 47. Extract the month number from the date '2023-09-15'.
select month('2023-09-15')

-- 48. From a 'Sales' table, write a query to group total sales by the quarter of the sale date.
CREATE TABLE Sales (
    SaleID INT IDENTITY PRIMARY KEY,
    SaleDate DATE,
    Amount DECIMAL(10,2)
);
go
INSERT INTO Sales (SaleDate, Amount) VALUES
('2024-01-15', 1000),
('2024-03-22', 2500),
('2024-05-30', 400),
('2024-07-12', 750),
('2024-10-09', 1800),
('2024-12-25', 2200);

select datepart(quarter,saledate) as quarters,sum(amount) as total_sales from sales group by datepart(quarter,saledate)

-- 49. Extract the year from the current date.
select year(getdate())

-- 50. From an 'Employees' table, find all employees hired in the year 2022.
select * from employees where year(hiredate)=2022

-- 51. Check if '2023-02-30' is a valid date.
select isdate('2023-02-30')

-- 52. Write a query to find all rows in a 'UserInputs' table where the 'EnteredDate' column contains invalid dates.
CREATE TABLE UserInputs (
    InputID INT IDENTITY PRIMARY KEY,
    EnteredDate NVARCHAR(20)
);
go
INSERT INTO UserInputs (EnteredDate)
VALUES ('2023-02-30'), ('2023-05-15'), ('InvalidDate');

select * from userinputs where isdate(entereddate)=0

-- 53. Find the last day of the current month.
select eomonth(getdate())

-- 54. From a 'Subscriptions' table, write a query to extend all subscription end dates to the end of their respective months.
CREATE TABLE Subscriptions (
    SubscriptionID INT IDENTITY PRIMARY KEY,
    EndDate DATE
);
go
INSERT INTO Subscriptions (EndDate)
VALUES
('2025-02-15'),
('2025-10-31'),
('2025-11-05');

select *,eomonth(enddate)as extended_date from subscriptions

-- 55. Display the current date and time.
select sysdatetime()

-- 56. Compare the results of two different methods to get the current timestamp - are they always the same?
select current_timestamp as method1,getdate() as method2

-- 57. Get the current date and time with higher precision than standard methods.
select sysdatetime()

-- 58. Write a query to insert the current high-precision timestamp into a 'Logs' table.
CREATE TABLE Logs (
    LogID INT IDENTITY PRIMARY KEY,
    LogTime DATETIME2
);

INSERT INTO Logs (LogTime)
VALUES (SYSDATETIME());

-- 59. Display the current UTC date and time with high precision.
select sysutcdatetime()

-- 60. Calculate the difference in microseconds between the current local time and UTC time.
select datediff(microsecond,sysutcdatetime(),sysdatetime())

-- 61. Get the current date, time, and time zone offset.
select sysdatetimeoffset()

-- 62. From a 'GlobalEvents' table, convert all event times to include time zone offset information.
CREATE TABLE GlobalEvents (
    EventID INT IDENTITY PRIMARY KEY,
    EventTime DATETIME
);
go
INSERT INTO GlobalEvents (EventTime)
VALUES (GETDATE()), (DATEADD(HOUR, 5, GETDATE()));

select eventid,todatetimeoffset(eventtime,'+05:30') as EventTimes from globalevents

-- 63. Extract the month number from the date '2023-12-25'.
select month('2023-12-25')

-- 64. From a 'Sales' table, find the total sales for each month of the previous year.
select month(saledate)as salemonth,sum(amount) as totalsales
from sales 
where year(saledate)= year(getdate())-1
group by month(saledate)

-- 65. Extract the day of the month from '2023-03-15'.
select day('2023-03-15')

-- 66. Write a query to find all orders from an 'Orders' table that were placed on the 15th day of any month.
select * from orders where day(orderdate)=15

-- 67. Get the name of the month for the date '2023-09-01'.
select datename(month,'2023-09-01')

-- 68. From an 'Events' table, write a query to display the day of the week (in words) for each event date.
CREATE TABLE Events (
    EventID INT IDENTITY PRIMARY KEY,
    EventDate DATE
);
go
INSERT INTO Events (EventDate) VALUES
('2023-09-01'), ('2023-09-15'), ('2023-12-25'), ('2024-01-01');

select *,datename(weekday,eventdate) as dayname from events

-- 69. Create a date for Christmas Day 2023.
select datefromparts('2023','12','25')

-- 70. Write a query to convert separate year, month, and day columns from a 'Dates' table into a single DATE column.
CREATE TABLE Dates (
    ID INT IDENTITY PRIMARY KEY,
    YearPart INT,
    MonthPart INT,
    DayPart INT
);
go
INSERT INTO Dates (YearPart, MonthPart, DayPart) VALUES
(2023, 12, 25),
(2024, 1, 1),
(2025, 10, 21);

select *,datefromparts(yearpart,monthpart,daypart) as Date from dates



-- SQL SERVER SCHEMA AND ASSIGNMENT QUESTIONS
-- Topic: GROUP BY, HAVING, and Aggregate Functions

-- =====================================================
-- SCHEMA CREATION
-- =====================================================

-- Create Database
CREATE DATABASE SalesAnalysisDB;
USE SalesAnalysisDB;
GO
-- 1. CUSTOMERS Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    City NVARCHAR(50),
    Country NVARCHAR(50),
    Region NVARCHAR(50),
    CustomerType NVARCHAR(20) CHECK (CustomerType IN ('Individual', 'Corporate'))
);

-- 2. PRODUCTS Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    UnitPrice DECIMAL(10,2),
    UnitsInStock INT,
    Supplier NVARCHAR(100)
);

-- 3. EMPLOYEES Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Department NVARCHAR(50),
    Salary DECIMAL(10,2),
    HireDate DATE,
    ManagerID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
);

-- 4. ORDERS Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    OrderDate DATE,
    ShippedDate DATE,
    ShipCity NVARCHAR(50),
    ShipCountry NVARCHAR(50),
    Freight DECIMAL(8,2)
);

-- 5. ORDER_DETAILS Table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    Discount DECIMAL(4,2) DEFAULT 0.00
);

-- =====================================================
-- SAMPLE DATA INSERTION
-- =====================================================

-- Insert Customers
INSERT INTO Customers (CustomerName, City, Country, Region, CustomerType) VALUES
('ABC Corporation', 'New York', 'USA', 'North America', 'Corporate'),
('John Smith', 'London', 'UK', 'Europe', 'Individual'),
('Tech Solutions Ltd', 'Toronto', 'Canada', 'North America', 'Corporate'),
('Maria Garcia', 'Madrid', 'Spain', 'Europe', 'Individual'),
('Global Industries', 'Tokyo', 'Japan', 'Asia', 'Corporate'),
('David Wilson', 'Sydney', 'Australia', 'Oceania', 'Individual'),
('Innovation Corp', 'Berlin', 'Germany', 'Europe', 'Corporate'),
('Sarah Johnson', 'Chicago', 'USA', 'North America', 'Individual'),
('Asian Trading Co', 'Singapore', 'Singapore', 'Asia', 'Corporate'),
('Michael Brown', 'Paris', 'France', 'Europe', 'Individual');

-- Insert Products
INSERT INTO Products (ProductName, Category, UnitPrice, UnitsInStock, Supplier) VALUES
('Laptop Pro 15', 'Electronics', 1299.99, 50, 'TechSupplier Inc'),
('Wireless Mouse', 'Electronics', 29.99, 200, 'TechSupplier Inc'),
('Office Chair', 'Furniture', 199.99, 75, 'FurnitureCorp'),
('Desk Lamp', 'Furniture', 49.99, 120, 'FurnitureCorp'),
('Smartphone X1', 'Electronics', 899.99, 80, 'Mobiletech Ltd'),
('Coffee Maker', 'Appliances', 159.99, 45, 'HomeGoods Co'),
('Standing Desk', 'Furniture', 399.99, 30, 'FurnitureCorp'),
('Bluetooth Speaker', 'Electronics', 79.99, 150, 'AudioPro'),
('Microwave Oven', 'Appliances', 299.99, 25, 'HomeGoods Co'),
('Ergonomic Keyboard', 'Electronics', 89.99, 100, 'TechSupplier Inc');

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, Department, Salary, HireDate, ManagerID) VALUES
('Alice', 'Johnson', 'Sales', 65000.00, '2020-01-15', NULL),
('Bob', 'Smith', 'Sales', 58000.00, '2021-03-20', 1),
('Carol', 'Davis', 'Marketing', 62000.00, '2019-11-10', NULL),
('David', 'Miller', 'Sales', 55000.00, '2022-02-14', 1),
('Emma', 'Wilson', 'IT', 75000.00, '2018-09-05', NULL),
('Frank', 'Taylor', 'Marketing', 59000.00, '2021-08-12', 3),
('Grace', 'Brown', 'Sales', 61000.00, '2020-12-03', 1),
('Henry', 'Jones', 'IT', 72000.00, '2019-04-18', 5),
('Ivy', 'Garcia', 'HR', 68000.00, '2021-01-25', NULL),
('Jack', 'Martinez', 'Sales', 57000.00, '2022-06-30', 1);

-- Insert Orders
INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, ShippedDate, ShipCity, ShipCountry, Freight) VALUES
(1, 2, '2024-01-15', '2024-01-18', 'New York', 'USA', 25.50),
(2, 4, '2024-01-20', '2024-01-23', 'London', 'UK', 35.75),
(3, 7, '2024-02-05', '2024-02-08', 'Toronto', 'Canada', 28.90),
(1, 2, '2024-02-15', '2024-02-18', 'New York', 'USA', 42.30),
(4, 10, '2024-02-28', '2024-03-03', 'Madrid', 'Spain', 31.20),
(5, 2, '2024-03-10', '2024-03-13', 'Tokyo', 'Japan', 55.80),
(6, 4, '2024-03-25', '2024-03-28', 'Sydney', 'Australia', 67.40),
(7, 7, '2024-04-12', '2024-04-15', 'Berlin', 'Germany', 38.90),
(2, 10, '2024-04-20', '2024-04-23', 'London', 'UK', 29.60),
(8, 2, '2024-05-05', '2024-05-08', 'Chicago', 'USA', 33.75),
(9, 4, '2024-05-18', '2024-05-21', 'Singapore', 'Singapore', 48.20),
(3, 7, '2024-06-02', '2024-06-05', 'Toronto', 'Canada', 52.10),
(10, 10, '2024-06-15', '2024-06-18', 'Paris', 'France', 41.30),
(1, 2, '2024-07-01', '2024-07-04', 'New York', 'USA', 36.80),
(5, 4, '2024-07-20', '2024-07-23', 'Tokyo', 'Japan', 59.90);

-- Insert Order Details
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(1, 1, 2, 1299.99, 0.05), (1, 2, 5, 29.99, 0.00),
(2, 3, 1, 199.99, 0.00), (2, 4, 2, 49.99, 0.10),
(3, 5, 1, 899.99, 0.00), (3, 8, 3, 79.99, 0.00),
(4, 1, 1, 1299.99, 0.00), (4, 10, 2, 89.99, 0.05),
(5, 6, 1, 159.99, 0.00), (5, 9, 1, 299.99, 0.00),
(6, 2, 10, 29.99, 0.15), (6, 4, 3, 49.99, 0.00),
(7, 7, 1, 399.99, 0.00), (7, 3, 2, 199.99, 0.10),
(8, 5, 2, 899.99, 0.00), (8, 8, 1, 79.99, 0.00),
(9, 1, 1, 1299.99, 0.00), (9, 2, 3, 29.99, 0.00),
(10, 6, 2, 159.99, 0.05), (10, 9, 1, 299.99, 0.00),
(11, 10, 5, 89.99, 0.00), (11, 8, 2, 79.99, 0.10),
(12, 3, 3, 199.99, 0.00), (12, 7, 1, 399.99, 0.00),
(13, 5, 1, 899.99, 0.00), (13, 2, 4, 29.99, 0.00),
(14, 1, 3, 1299.99, 0.10), (14, 4, 1, 49.99, 0.00),
(15, 9, 2, 299.99, 0.00), (15, 6, 1, 159.99, 0.00);

-- =====================================================
-- ASSIGNMENT QUESTIONS
-- =====================================================


-- Question 1: Find the total number of customers in each country.
select country,count(country)as customers
from customers
group by country


-- Question 2: Calculate the average unit price of products in each category.
select category,avg(unitprice) as AveragePrice 
from products
group by category

-- Question 3: Find the maximum and minimum salary in each department.
select department,max(salary) as MaxSalary,min(salary)as MinSalary 
from employees
group by department

-- Question 4: Count the total number of products supplied by each supplier.
select supplier,count(*) as NumberOfProducts
from products
group by supplier

-- Question 5: Calculate the total value of inventory (UnitsInStock × UnitPrice) for each product category.
select category,sum(unitprice*unitsinstock) as TotalValue 
from products
group by category 

-- Question 6: Find all product categories that have more than 2 products.
select category , count(*) as productcount
from products
group by category
having count(*)>2

-- Question 7: List departments where the average salary is greater than $60,000.
select department ,AVG(salary) AS AvgSalary
from employees
group by department
having avg(salary)>60000

-- Question 8: Show product categories where the average unit price is between $100 and $500.
select category ,avg(unitprice) as AveragePrice
from products
group by category
having avg(unitprice)>=100 and avg(unitprice)<=500 

-- Question 9: Find suppliers who supply products worth more than $10,000 in total inventory value.
select supplier ,sum(unitprice*unitsinstock) as InventoryValue
from products
group by supplier
having sum(unitprice*unitsinstock)>10000

-- Question 10: List countries that have more than 1 customer and show the customer count.
select country,count(*) as customercount  
from customers
group by country
having count(*)>1


