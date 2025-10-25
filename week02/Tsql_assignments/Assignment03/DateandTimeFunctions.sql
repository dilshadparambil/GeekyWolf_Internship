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