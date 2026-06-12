CREATE DATABASE FleetMaintenanceDb;
GO

USE FleetMaintenanceDb;
GO

CREATE TABLE Vehicles
(
    VehicleId INT IDENTITY(1,1) PRIMARY KEY,
    VehicleNumber VARCHAR(20) NOT NULL,
    VehicleType VARCHAR(50) NOT NULL,
    Brand VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    PurchaseYear INT NOT NULL,
    IsActive BIT NOT NULL
);

CREATE TABLE Drivers
(
    DriverId INT IDENTITY(1,1) PRIMARY KEY,
    DriverName VARCHAR(100) NOT NULL,
    LicenseNumber VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    City VARCHAR(50) NOT NULL,
    IsAvailable BIT NOT NULL
);

CREATE TABLE MaintenanceRecords
(
    MaintenanceId INT IDENTITY(1,1) PRIMARY KEY,
    VehicleId INT NOT NULL,
    DriverId INT NOT NULL,
    ServiceDate DATE NOT NULL,
    ServiceType VARCHAR(100) NOT NULL,
    ServiceCost DECIMAL(18,2) NOT NULL,
    ServiceStatus VARCHAR(30) NOT NULL,
    Remarks VARCHAR(250) NULL,
    CreatedDate DATETIME NOT NULL,
    CONSTRAINT FK_MaintenanceRecords_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId),
    CONSTRAINT FK_MaintenanceRecords_Drivers FOREIGN KEY (DriverId) REFERENCES Drivers(DriverId)
);

-- insert vehicles
INSERT INTO Vehicles (VehicleNumber, VehicleType, Brand, Model, PurchaseYear, IsActive) VALUES
('TN38AB1234', 'Truck', 'Tata', 'Ace', 2021, 1),
('TN01CD5678', 'Van', 'Mahindra', 'Bolero', 2019, 1),
('TN45EF9012', 'Truck', 'Ashok Leyland', 'Dost', 2020, 1),
('TN22GH3456', 'Pickup', 'Tata', 'Xenon', 2018, 1),
('TN09IJ7890', 'Van', 'Force', 'Traveller', 2022, 1),
('TN33KL2345', 'Truck', 'Eicher', 'Pro 3015', 2021, 1),
('TN55MN6789', 'Pickup', 'Mahindra', 'Supro', 2017, 0),
('TN67OP0123', 'Truck', 'Tata', 'Prima', 2023, 1),
('TN78QR4567', 'Van', 'Toyota', 'HiAce', 2020, 1),
('TN90ST8901', 'Truck', 'BharatBenz', '1415R', 2022, 1);

-- insert drivers
INSERT INTO Drivers (DriverName, LicenseNumber, PhoneNumber, City, IsAvailable) VALUES
('Ramesh Kumar', 'DL2026TN1001', '9876543210', 'Chennai', 1),
('Suresh Babu', 'DL2024TN1002', '9876543211', 'Coimbatore', 1),
('Murugan P', 'DL2023TN1003', '9876543212', 'Madurai', 0),
('Arjun Singh', 'DL2025TN1004', '9876543213', 'Trichy', 1),
('Karthik R', 'DL2022TN1005', '9876543214', 'Salem', 1),
('Vijay D', 'DL2021TN1006', '9876543215', 'Chennai', 1),
('Rajan M', 'DL2026TN1007', '9876543216', 'Erode', 0),
('Bala S', 'DL2020TN1008', '9876543217', 'Tirunelveli', 1),
('Senthil K', 'DL2019TN1009', '9876543218', 'Vellore', 1),
('Dinesh A', 'DL2024TN1010', '9876543219', 'Coimbatore', 1);

-- insert maintenance records
INSERT INTO MaintenanceRecords (VehicleId, DriverId, ServiceDate, ServiceType, ServiceCost, ServiceStatus, Remarks, CreatedDate) VALUES
(1, 1, '2026-01-05', 'Oil Change', 2500.00, 'Completed', 'Regular oil replacement', '2026-01-01 10:00:00'),
(2, 2, '2026-01-10', 'Brake Inspection', 3000.00, 'Completed', 'Brake pads replaced', '2026-01-08 09:00:00'),
(3, 3, '2026-01-15', 'Tyre Replacement', 8000.00, 'Completed', 'All 4 tyres replaced', '2026-01-12 11:00:00'),
(4, 4, '2026-01-20', 'Battery Check', 1500.00, 'Completed', 'Battery was weak', '2026-01-18 10:30:00'),
(5, 5, '2026-02-01', 'General Service', 4500.00, 'Completed', 'Full service done', '2026-01-28 08:00:00'),
(6, 6, '2026-02-05', 'Engine Repair', 12000.00, 'Completed', 'Engine overheat issue fixed', '2026-02-03 09:00:00'),
(7, 7, '2026-02-10', 'Oil Change', 2500.00, 'Cancelled', 'Driver unavailable', '2026-02-08 10:00:00'),
(8, 8, '2026-02-15', 'Brake Inspection', 3500.00, 'Completed', 'Front brakes serviced', '2026-02-12 09:30:00'),
(9, 9, '2026-02-20', 'General Service', 5000.00, 'Completed', 'Routine checkup', '2026-02-18 11:00:00'),
(10, 10, '2026-02-25', 'Tyre Replacement', 7500.00, 'Completed', 'Two tyres replaced', '2026-02-22 10:00:00'),
(1, 2, '2026-03-01', 'Battery Check', 1800.00, 'Completed', 'Battery replaced', '2026-02-27 09:00:00'),
(2, 3, '2026-03-05', 'Engine Repair', 15000.00, 'InProgress', 'Engine mount broken', '2026-03-03 10:00:00'),
(3, 4, '2026-03-10', 'Oil Change', 2500.00, 'Completed', 'Oil filter also changed', '2026-03-08 08:30:00'),
(4, 5, '2026-03-15', 'General Service', 4000.00, 'Scheduled', 'Upcoming service', '2026-03-12 09:00:00'),
(5, 6, '2026-03-20', 'Brake Inspection', 3200.00, 'Completed', 'Brake fluid topped up', '2026-03-18 10:30:00'),
(6, 7, '2026-04-01', 'Tyre Replacement', 9000.00, 'Completed', 'All 6 tyres replaced', '2026-03-28 09:00:00'),
(7, 8, '2026-04-05', 'Oil Change', 2500.00, 'Completed', 'Synthetic oil used', '2026-04-03 10:00:00'),
(8, 9, '2026-04-10', 'Battery Check', 1200.00, 'Completed', 'Battery terminals cleaned', '2026-04-08 09:30:00'),
(9, 10, '2026-04-15', 'Engine Repair', 18000.00, 'InProgress', 'Injector replacement', '2026-04-12 11:00:00'),
(10, 1, '2026-04-20', 'General Service', 5500.00, 'Scheduled', 'Scheduled for next week', '2026-04-18 10:00:00'),
(1, 3, '2026-05-01', 'Brake Inspection', 2800.00, 'Completed', 'Rear brakes serviced', '2026-04-28 09:00:00'),
(2, 4, '2026-05-05', 'Tyre Replacement', 6000.00, 'Completed', 'Front tyres replaced', '2026-05-03 10:00:00'),
(3, 5, '2026-05-10', 'Oil Change', 2500.00, 'Scheduled', 'Due for oil change', '2026-05-08 08:00:00'),
(4, 6, '2026-05-15', 'General Service', 4800.00, 'Completed', 'AC gas refilled', '2026-05-12 09:30:00'),
(5, 7, '2026-05-20', 'Battery Check', 1600.00, 'Cancelled', 'Vehicle breakdown', '2026-05-18 10:00:00'),
(6, 8, '2026-06-01', 'Engine Repair', 22000.00, 'InProgress', 'Gear box issue', '2026-05-28 09:00:00'),
(7, 9, '2026-06-05', 'Oil Change', 2500.00, 'Scheduled', 'Monthly oil change', '2026-06-03 10:00:00'),
(8, 10, '2026-06-10', 'Brake Inspection', 3000.00, 'Scheduled', 'Brake check due', '2026-06-08 09:30:00'),
(9, 1, '2026-06-15', 'General Service', 5200.00, 'Scheduled', 'Full service scheduled', '2026-06-12 11:00:00'),
(10, 2, '2026-06-20', 'Tyre Replacement', 8500.00, 'Scheduled', 'Tyres worn out', '2026-06-18 10:00:00');