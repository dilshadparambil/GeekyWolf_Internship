CREATE DATABASE adodb;

CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Salary DECIMAL(10, 2)
);

INSERT INTO Employee (Name, Salary) VALUES
('Alice Smith', 60000),
('Bob Johnson', 75000),
('Charlie Brown', 52000);


CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Class VARCHAR(50)
);

INSERT INTO Student (Name, Class) VALUES
('David Lee', 'Class 10'),
('Emily White', 'Class 11');

CREATE PROCEDURE GetStudentById
    @StudentId INT
AS
BEGIN
    SELECT Id, Name, Class FROM Student WHERE Id = @StudentId;
END

CREATE PROCEDURE InsertStudent
    @Name VARCHAR(100),
    @Class VARCHAR(50),
    @LastInsertedId INT OUTPUT
AS
BEGIN
    INSERT INTO Student (Name, Class) VALUES (@Name, @Class);
    SET @LastInsertedId = SCOPE_IDENTITY();
END

CREATE PROCEDURE DeleteStudent
    @StudentId INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Student WHERE Id = @StudentId)
    BEGIN
        DELETE FROM Student WHERE Id = @StudentId;
        SELECT 1;
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END

CREATE PROCEDURE UpdateStudent
    @StudentId INT,
    @StudentName VARCHAR(100),
    @Class VARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Student WHERE Id = @StudentId)
    BEGIN
        UPDATE Student
        SET Name = @StudentName, Class = @Class
        WHERE Id = @StudentId;
        SELECT 1;
    END
    ELSE
    BEGIN
        SELECT 0;
    END
END