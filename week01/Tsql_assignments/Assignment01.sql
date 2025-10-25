
-- CREATE TABLE: Creates an Employees table with columns for EmployeeID, FirstName, LastName, Department, and Salary.
CREATE TABLE Employees ( 
	EmployeeID INT PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL, 
	LastName VARCHAR(20) NOT NULL, 
	Department VARCHAR(50),
	Salary DECIMAL(10,2)
);
-- INSERT: Adds three employee records to the table.
INSERT INTO Employees VALUES 
	(101,'DIL','SHAD','sales',10000),
	(102,'max','john','hr',30000),
	(103,'david','michael','marketing',15000);
    (104,'david','fincher','IT',20000);

-- SELECT: Shows different ways to query data:
-- Select all columns and rows
SELECT * FROM Employees;
-- Select specific columns
SELECT FirstName,Salary FROM Employees;
-- Select with a WHERE clause to filter results\
SELECT * FROM Employees WHERE Salary>12000;

-- What is the purpose of the IDENTITY keyword in the CREATE TABLE statement?
-- to create a primary key that automatically increments 
-- IDENTITY(seed, increment) seed is the starting value and increment is the amount to be incremented in the next insert
-- EmployeeID INT PRIMARY KEY IDENTITY(1000,1) inorder to start the id from 1000

-- Write a SELECT statement to retrieve only the FirstName and Salary of all employees.
SELECT FirstName,Salary FROM Employees;

-- How would you modify the existing UPDATE statement to give all employees in the IT department a 10% raise
UPDATE Employees 
	SET Salary=(Salary*.10)+Salary
	WHERE Department = 'IT';

-- Write a SELECT statement to find the highest salary in the Employees table.
SELECT *
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);

-- How would you add a new column named "HireDate" of type DATE to the Employees table?
alter table Employees add HireDate Date;

-- Write an INSERT statement to add a new employee named "Sarah Brown" in the "Marketing" department with a salary of 72000.00.
INSERT INTO Employees VALUES 
	(105,'Sarah', 'Brown','Marketing',72000.00,'2025-10-16');

--  How would you modify the table to ensure that the Salary column cannot contain negative values?
alter table Employees ADD CONSTRAINT check_positive CHECK (Salary >= 0);

-- How would you add a UNIQUE constraint to the Employees table to ensure that no two employees can have the same email address
-- Write an ALTER TABLE statement to add an "Email" column to the Employees table with a UNIQUE constraint that allows NULL values

alter table Employees ADD Email VARCHAR(100); 

CREATE UNIQUE INDEX Uniq_Email
ON Employees(Email)
WHERE Email IS NOT NULL;

-- UPDATE Employees
-- SET Email = CASE EmployeeID
--     WHEN 101 THEN 'abc@123.com'
--     WHEN 102 THEN 'qwerty@123.com'
--     WHEN 103 THEN 'asdf@123.com'
--     WHEN 104 THEN 'sa@123.com'
--     WHEN 105 THEN 'sarah@123.com'
-- END
-- WHERE EmployeeID IN (101, 102, 103, 104, 105);

-- ALTER TABLE Employees
-- ADD CONSTRAINT Uniq_Email UNIQUE (Email);
