-- ============================================
-- VEHICLE RENTAL SYSTEM - DATABASE SETUP
-- Run this script to set up the database
-- ============================================

-- Step 1: Create the database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'VehicleRentalDB')
BEGIN
    CREATE DATABASE VehicleRentalDB;
    PRINT 'Database VehicleRentalDB created.';
END
ELSE
BEGIN
    PRINT 'Database VehicleRentalDB already exists.';
END
GO

USE VehicleRentalDB;
GO

-- Step 2: Create Users table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId       INT PRIMARY KEY IDENTITY(1,1),
        FullName     NVARCHAR(100)  NOT NULL,
        Email        NVARCHAR(100)  NOT NULL UNIQUE,
        PasswordHash NVARCHAR(256)  NOT NULL,
        Phone        NVARCHAR(20),
        CreatedAt    DATETIME       DEFAULT GETDATE()
    );
    PRINT 'Table Users created.';
END
GO

-- Step 3: Create Vehicles table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_NAME = 'Vehicles')
BEGIN
    CREATE TABLE Vehicles (
        VehicleId    INT PRIMARY KEY IDENTITY(1,1),
        Brand        NVARCHAR(50)   NOT NULL,
        Model        NVARCHAR(50)   NOT NULL,
        Year         INT            NOT NULL,
        LicensePlate NVARCHAR(20)   NOT NULL UNIQUE,
        PricePerDay  DECIMAL(10,2)  NOT NULL,
        IsAvailable  BIT            DEFAULT 1
    );
    PRINT 'Table Vehicles created.';
END
GO

-- Step 4: Create Reservations table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
               WHERE TABLE_NAME = 'Reservations')
BEGIN
    CREATE TABLE Reservations (
        ReservationId INT PRIMARY KEY IDENTITY(1,1),
        UserId        INT            NOT NULL,
        VehicleId     INT            NOT NULL,
        StartDate     DATETIME       NOT NULL,
        EndDate       DATETIME       NOT NULL,
        TotalPrice    DECIMAL(10,2)  NOT NULL,
        Status        NVARCHAR(20)   DEFAULT 'Pending',
        FOREIGN KEY (UserId)    REFERENCES Users(UserId),
        FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId)
    );
    PRINT 'Table Reservations created.';
END
GO

-- Step 5: Insert sample vehicles
IF NOT EXISTS (SELECT * FROM Vehicles)
BEGIN
    INSERT INTO Vehicles (Brand, Model, Year, LicensePlate, PricePerDay)
    VALUES
        ('Toyota',   'Corolla',  2022, 'AB-123-CD', 45.00),
        ('Honda',    'Civic',    2021, 'EF-456-GH', 50.00),
        ('Renault',  'Clio',     2023, 'IJ-789-KL', 38.00),
        ('BMW',      'Series 3', 2022, 'MN-012-OP', 95.00),
        ('Mercedes', 'C-Class',  2023, 'QR-345-ST', 110.00);
    PRINT 'Sample vehicles inserted.';
END
GO

PRINT '===================================';
PRINT 'Database setup completed!';
PRINT 'You can now run the application.';
PRINT '===================================';