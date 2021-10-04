CREATE DATABASE Housing-- Create Databse

USE Housing-- Use Created Database

CREATE TABLE Resident --  Create Resident Table
(
UnitID INT NOT NULL PRIMARY KEY,
Name VARCHAR(25) NOT NULL,
Surname VARCHAR(25) NOT NULL,
EmailAddress VARCHAR(50) NOT NULL,
CellNumber VARCHAR(12) NOT NULL,
YearMovedIn INT NOT NULL
);

CREATE TABLE Tickets -- Create Tickets Table FK References Resident Table UnitID
(
TicketID INT NOT NULL IDENTITY PRIMARY KEY,
Complaint VARCHAR(180) NOT NULL
);

CREATE TABLE Resident_Ticket(
ResidentTicketID int PRIMARY KEY IDENTITY,
UnitID INT NOT NULL,
TicketID INT NOT NULL,
TicketStatus VARCHAR(25),
FOREIGN KEY(UnitID) REFERENCES Resident(UnitID),
FOREIGN KEY(TicketID) REFERENCES Tickets(TicketID),
);
 
