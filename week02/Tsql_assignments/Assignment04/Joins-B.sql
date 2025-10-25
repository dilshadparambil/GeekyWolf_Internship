-- E-commerce Platform Schema

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    RegistrationDate DATE
);
go
INSERT INTO Customers (CustomerID, CustomerName, Email, RegistrationDate) VALUES
(1, 'John Doe', 'john.doe@email.com', '2022-05-10'),
(2, 'Jane Smith', 'jane.smith@email.com', '2023-01-15'),
(3, 'Robert Brown', 'robert.brown@email.com', '2021-11-20'),
(4, 'Emily Johnson', 'emily.johnson@email.com', '2023-08-05'),
(5, 'Michael Davis', 'michael.davis@email.com', '2024-02-12'),
(6, 'Olivia Wilson', 'olivia.wilson@email.com', '2024-09-01'),
(7, 'Daniel Miller', 'daniel.miller@email.com', '2020-07-19'),
(8, 'Sophia Garcia', 'sophia.garcia@email.com', '2023-10-01'),
(9, 'Noah Martinez', 'noah.martinez@email.com', '2024-03-25'),
(10, 'Ava Taylor', 'ava.taylor@email.com', '2025-01-10');
go
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(200),
    Price DECIMAL(10, 2),
    CategoryID INT
);
go
INSERT INTO Products (ProductID, ProductName, Price, CategoryID) VALUES
(1, 'Smartphone X', 799.99, 1),
(2, 'Wireless Earbuds', 149.99, 1),
(3, '4K Television', 1199.50, 1),
(4, 'Vacuum Cleaner', 249.99, 2),
(5, 'Air Fryer', 189.99, 2),
(6, 'Fiction Novel', 19.99, 3),
(7, 'Yoga Mat', 39.99, 5),
(8, 'Running Shoes', 129.99, 5),
(9, 'T-shirt', 25.00, 4),
(10, 'Laptop Sleeve', 29.99, NULL),   
(11, 'Gaming Console', 499.99, 1),     
(12, 'Blender', 89.99, 2),
(13, 'Drone Pro', 899.00, 1),         
(14, 'Soccer Ball', 35.00, 5);      
go

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);
go
INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Electronics'),
(2, 'Home Appliances'),
(3, 'Books'),
(4, 'Clothing'),
(5, 'Sports'),
(6, 'Toys');   
go

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
go
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount) VALUES
(1, 1, '2022-11-25', 949.98), 
(2, 2, '2023-04-15', 149.99),
(3, 3, '2023-12-05', 1299.49),
(4, 4, '2024-07-20', 219.98),
(5, 5, '2024-10-03', 249.99),
(6, 6, '2025-03-12', 139.98),
(7, 7, '2025-10-17', 1199.50),  
(8, 1, '2025-10-20', 89.99);    
go
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
go
INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
-- Order 1 (John)
(1, 1, 1, 1), (2, 1, 2, 1),
-- Order 2 (Jane)
(3, 2, 2, 1),
-- Order 3 (Robert)
(4, 3, 3, 1), (5, 3, 11, 1),
-- Order 4 (Emily)
(6, 4, 6, 2),
-- Order 5 (Michael)
(7, 5, 4, 1),
-- Order 6 (Olivia)
(8, 6, 7, 2), (9, 6, 9, 1),
-- Order 7 (Daniel – recent)
(10, 7, 3, 1),
-- Order 8 (John – recent)
(11, 8, 12, 1);
go


-- Questions

-- 1. List all products with their category names, including products without a category.
select 
p.productid,
p.productname,
c.categoryname
from products p
left join categories c on p.categoryid=c.categoryid

-- 2. Display all customers and their order history, including customers who haven't placed any orders.
select 
c.customerid,
c.customername,
o.orderdate,
o.totalamount
from customers c 
left join orders o on c.customerid=o.customerid

-- 3. Show all categories and the products in each category, including categories without any products.
select 
c.categoryid,
c.categoryname,
p.productname
from categories c 
left join products p on c.categoryid=p.categoryid

-- 4. List all possible customer-product combinations, regardless of whether a purchase has occurred.
select 
c.customername,
p.productname
from customers c
cross join products p

-- 5. Display all orders with customer and product information, including orders where either the customer or product information is missing.
select 
o.orderid,
o.orderdate,
c.customername,
p.productname,
ord.quantity

from orders o
left join customers c on o.customerid=c.customerid  
left join orderdetails ord on o.orderid=ord.orderid
left join products p on ord.productid=p.productid

-- 6. Show all products that have never been ordered, along with their category information.
select
p.productid,
p.productname,
c.categoryid,
c.categoryname
from products p
left join orderdetails od on p.productid = od.productid
left join categories c on p.categoryid = c.categoryid

-- 7. List all customers who have placed orders in the last week, along with the products they've purchased.
select DISTINCT
c.customername,
o.orderdate,
p.productname,
od.quantity
from orders o
join customers c on c.customerid=o.customerid
join orderdetails od on od.orderid=o.orderid
join products p on p.productid=od.productid
where o.orderdate between dateadd(week,-1,getdate()) and  getdate() 

-- 8. Display all categories with products priced over $100, including categories without such products.
select  DISTINCT
c.categoryname,
p.productname,
p.price
from categories c
left join products p on p.categoryid=c.categoryid and p.price>100 
-- 9. Show all orders placed before 2023 and any associated product information.
select 
o.orderid,
o.orderdate,
p.productname
from orders o
left join orderdetails od on od.orderid=o.orderid
left join products p on p.productid=od.productid
where year(o.orderdate)<2023

-- 10. List all possible category-customer combinations, regardless of whether the customer has purchased a product from that category.
select 
ca.categoryname,
c.customername
from categories ca
cross join customers c