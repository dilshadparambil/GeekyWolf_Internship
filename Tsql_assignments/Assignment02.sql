-- SQL Assignemnt 2

-- For this assignment, assume you have a database with the following table:
-- CREATE TABLE Employees (
--     EmployeeID INT PRIMARY KEY,
--     FirstName VARCHAR(50),
--     LastName VARCHAR(50),
--     Department VARCHAR(50),
--     Salary DECIMAL(10, 2),
--     HireDate DATE
-- );

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1000,1) PRIMARY KEY ,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2),
    HireDate DATE
);
select * from employees;

INSERT INTO Employees (FirstName, LastName, Department, Salary, HireDate) VALUES
('John', 'Smith', 'Sales', 65000.00, '2018-05-15'),
('Jane', 'Doe', 'Marketing', 58000.00, '2019-08-01'),
('Peter', 'Jones', 'IT', 85000.00, '2017-03-22'),
('Susan', 'Rogers', 'Sales', 75000.00, '2021-02-10'),
('David', 'Brown', 'HR', 50000.00, '2020-11-05'),
('Maria', 'Spencer', 'IT', 92000.00, '2018-09-12'),
('Michael', 'Adams', 'Finance', 110000.00, '2016-07-19'),
('Emily', 'Evans', 'Marketing', 72000.00, '2019-04-30'),
('Daniel', 'Scott', 'Sales', 68000.00, '2022-01-14'),
('Laura', 'Williams', 'IT', 78000.00, '2023-06-08'),
('Robert', 'Baker', 'HR', 48000.00, '2019-12-01'),
('Diane', 'Green', 'Marketing', 62000.00, '2020-03-18'),
('Chris', 'Owens', 'Finance', 81000.00, '2021-08-25'),
('Patricia', 'King', 'Sales', 55000.00, '2017-10-30'),
('Shane', 'Walker', 'IT', 71000.00, '2022-05-11'),
('Anthony', 'Davis', 'Marketing', 60000.00, '2018-11-20'),
('Victoria', 'Clark', 'HR', 45000.00, '2023-01-09'),
('James', 'Lee', 'Sales', 76000.00, '2019-07-15');

-- Create a table students and insert names in malayalam

-- Retrieve all employees who work in Sales, Marketing, or IT departments.
select * from employees where department in ('Sales', 'Marketing', 'IT');

-- Find all employees with salaries ranging from $50,000 to $75,000 (inclusive).
select * from employees where salary between 50000 and 75000;

-- List all employees whose last name begins with the letter 'S'.
select * from employees where lastname like 's%'

-- Display all employees with exactly five letters in their first name.
select * from employees where firstname like '_____'

-- Find employees whose last name starts with either 'B', 'R', or 'S'.
select * from employees where lastname like '[BRS]%'

-- Retrieve all employees whose first name begins with any letter from 'A' through 'M'.
select * from employees where firstname like '[A-M]%'

-- List employees whose last name doesn't start with a vowel (A, E, I, O, U).
select * from employees where lastname Not like '[A,E,I,O,U]%'

-- Identify employees earning more than $80,000 annually. 
select * from employees where salary>80000;

-- Find employees who joined the company before 2020. 
select * from employees where year(hiredate)<2020;

--  List all employees not named 'John' (first name).
select * from employees where firstname != 'John';

-- Identify Marketing department employees earning $60,000 or less who were hired after June 30, 2019.
select * from employees where department='marketing' and salary<=60000 and hiredate>'2019-06-30';

-- Find employees whose first name contains the letters 'an' anywhere and ends with 'e'.
select * from employees where firstname like '%an%e'