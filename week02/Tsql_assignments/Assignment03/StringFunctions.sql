
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


