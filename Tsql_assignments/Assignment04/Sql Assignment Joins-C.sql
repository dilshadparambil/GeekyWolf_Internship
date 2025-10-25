-- Library Management Schema

CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    AuthorName VARCHAR(100),
    BirthYear INT
);
go
INSERT INTO Authors (AuthorID, AuthorName, BirthYear) VALUES
(1, 'George Orwell', 1903),
(2, 'J.K. Rowling', 1965),
(3, 'Haruki Murakami', 1949),
(4, 'Yuval Noah Harari', 1976),
(5, 'Sally Rooney', 1991),
(6, 'Unknown Author', NULL),
(7, 'New Author No Books', 1985);  
go

CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(200),
    AuthorID INT,
    PublicationYear INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);
go
INSERT INTO Books (BookID, Title, AuthorID, PublicationYear) VALUES
(1, '1984', 1, 1949),
(2, 'Animal Farm', 1, 1945),
(3, 'Harry Potter and the Sorcerers Stone', 2, 1997),
(4, 'Kafka on the Shore', 3, 2002),
(5, 'Norwegian Wood', 3, 1987),
(6, 'Sapiens: A Brief History of Humankind', 4, 2011),
(7, 'Normal People', 5, 2018),
(8, 'Unpublished Work', NULL, NULL),    
(9, 'Old Mystery Novel', 6, 1950),     
(10, 'Future Book', NULL, 2026);        
go

CREATE TABLE Patrons (
    PatronID INT PRIMARY KEY,
    PatronName VARCHAR(100),
    MembershipDate DATE
);
go

INSERT INTO Patrons (PatronID, PatronName, MembershipDate) VALUES
(1, 'Alice Johnson', '2022-01-10'),
(2, 'Bob Smith', '2023-05-21'),
(3, 'Charlie Brown', '2024-03-03'),
(4, 'Diana Prince', '2024-07-15'),
(5, 'Ethan Hunt', '2025-01-12'),
(6, 'Fiona Adams', '2025-09-05'),
(7, 'George King', '2025-10-01'),   
(8, 'Helen Carter', '2023-11-09');  
go

CREATE TABLE Loans (
    LoanID INT PRIMARY KEY,
    BookID INT,
    PatronID INT,
    LoanDate DATE,
    ReturnDate DATE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (PatronID) REFERENCES Patrons(PatronID)
);
go

INSERT INTO Loans (LoanID, BookID, PatronID, LoanDate, ReturnDate) VALUES
(1, 1, 1, '2022-06-10', '2022-06-30'),  
(2, 2, 1, '2023-03-05', '2023-03-25'),  
(3, 3, 2, '2023-12-15', '2024-01-05'),
(4, 4, 3, '2024-09-10', NULL),         
(5, 5, 4, '2025-02-01', '2025-02-20'),
(6, 6, 5, '2025-09-25', NULL),          
(7, 7, 6, '2025-10-15', NULL),          
(8, 9, 1, '2021-05-01', '2021-05-20'),  
(9, NULL, 2, '2024-06-10', '2024-06-30'), 
(10, 10, NULL, '2025-04-10', NULL);       
go

-- questions

-- 1. list all books along with their authors, including books without assigned authors.
select b.title, a.authorname
from books b
left join authors a on b.authorid = a.authorid;

-- 2. display all patrons and their loan history, including patrons who have never borrowed a book.
select p.patronname, l.loanid, l.loandate
from patrons p
left join loans l on p.patronid = l.patronid;

-- 3. show all authors and the books they've written, including authors who haven't written any books in our collection.
select a.authorname, b.title
from authors a
left join books b on a.authorid = b.authorid;

-- 4. list all possible book-patron combinations, regardless of whether a loan has occurred.
select b.title, p.patronname
from books b
cross join patrons p;

-- 5. display all loans with book and patron information, including loans where either the book or patron information is missing.
select l.loanid, b.title, p.patronname, l.loandate, l.returndate
from loans l
left join books b on l.bookid = b.bookid
left join patrons p on l.patronid = p.patronid;

-- 6. show all books that have never been loaned, along with their author information.
select b.title, a.authorname
from books b
left join loans l on b.bookid = l.bookid
left join authors a on b.authorid = a.authorid
where l.loanid is null;

-- 7. list all patrons who have borrowed books in the last month, along with the books they've borrowed.
select distinct p.patronname, b.title, l.loandate
from loans l
join patrons p on l.patronid = p.patronid
join books b on l.bookid = b.bookid
where l.loandate >= dateadd(day, 1, eomonth(getdate(), -2))
  and l.loandate <= eomonth(getdate(), -1)


-- 8. display all authors born after 1970 and their books, including those without any books in our collection.
select a.authorname, b.title
from authors a
left join books b on a.authorid = b.authorid
where a.birthyear > 1970;

-- 9. show all books published before 2000 and any associated loan information.
select b.title, b.publicationyear, l.loandate, p.patronname
from books b
left join loans l on b.bookid = l.bookid
left join patrons p on l.patronid = p.patronid
where b.publicationyear < 2000;

-- 10. list all possible author-patron combinations, regardless of whether the patron has borrowed a book by that author.
select a.authorname, p.patronname
from authors a
cross join patrons p;
