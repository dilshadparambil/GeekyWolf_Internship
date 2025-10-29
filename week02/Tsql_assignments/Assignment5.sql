
-- As todays assignment, please try to incorporate all the existing movie booking features of bookmyshow,
 --> create a the schema in database and insert the records.

create database bookmyshow
go
use bookmyshow
go

-- USERS
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name VARCHAR(100),
    UName VARCHAR(50) UNIQUE,
    PWord VARCHAR(50)
);

-- THEATRES
CREATE TABLE Theatre (
    TheatreID INT PRIMARY KEY,
    Name VARCHAR(100),
    Location VARCHAR(100)
);

-- SCREENS
CREATE TABLE Screen (
    ScreenID INT PRIMARY KEY,
    TheatreID INT,
    FOREIGN KEY (TheatreID) REFERENCES Theatre(TheatreID)
);

-- SEATS
CREATE TABLE Seats (
    SeatID INT PRIMARY KEY,
    ScreenID INT,
    SeatNumber VARCHAR(10),
    FOREIGN KEY (ScreenID) REFERENCES Screen(ScreenID)
);

-- LANGUAGE
CREATE TABLE Language (
    LanguageID INT PRIMARY KEY,
    Language VARCHAR(50)
);

-- MOVIES
CREATE TABLE Movies (
    MovieID INT PRIMARY KEY,
    Name VARCHAR(200),
    Length INT,  -- in minutes
    LanguageID INT,
    FOREIGN KEY (LanguageID) REFERENCES Language(LanguageID)
);

-- SHOWS
CREATE TABLE Shows (
    ShowID INT PRIMARY KEY,
    Time DATETIME,
    MovieID INT,
    ScreenID INT,
    FOREIGN KEY (MovieID) REFERENCES Movies(MovieID),
    FOREIGN KEY (ScreenID) REFERENCES Screen(ScreenID)
);

-- BOOKINGS
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY,
    ShowID INT,
    UserID INT,
    BookingDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ShowID) REFERENCES Shows(ShowID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- USER_SEATS
CREATE TABLE UserSeats (
    UserSeatID INT PRIMARY KEY,
    SeatID INT,
    BookingID INT,
    FOREIGN KEY (SeatID) REFERENCES Seats(SeatID),
    FOREIGN KEY (BookingID) REFERENCES Booking(BookingID)
);


INSERT INTO Users VALUES
(1, 'Amit Sharma', 'amit_s', 'pass123'),
(2, 'Priya Nair', 'priya_n', 'secure456'),
(3, 'Ravi Patel', 'ravi_p', 'hello789');

INSERT INTO Theatre VALUES
(1, 'PVR Cinemas', 'Mumbai'),
(2, 'INOX', 'Bangalore');

INSERT INTO Screen VALUES
(1, 1),  
(2, 1),  
(3, 2);  

INSERT INTO Seats VALUES
(1, 1, 'A1'), (2, 1, 'A2'), (3, 1, 'A3'),
(4, 2, 'B1'), (5, 2, 'B2'),
(6, 3, 'C1'), (7, 3, 'C2');

INSERT INTO Language VALUES
(1, 'English'),
(2, 'Hindi'),
(3, 'Tamil');

INSERT INTO Movies VALUES
(1, 'Inception', 148, 1),
(2, '3 Idiots', 170, 2),
(3, 'Vikram', 155, 3);

INSERT INTO Shows VALUES
(1, '2025-10-21 18:30', 1, 1),
(2, '2025-10-21 21:00', 2, 2), 
(3, '2025-10-22 19:00', 3, 3); 

INSERT INTO Booking VALUES
(1, 1, 1, '2025-10-20'), 
(2, 2, 2, '2025-10-21'), 
(3, 3, 3, '2025-10-21'); 

INSERT INTO UserSeats VALUES
(1, 1, 1),  
(2, 2, 1),  
(3, 4, 2),  
(4, 6, 3);  