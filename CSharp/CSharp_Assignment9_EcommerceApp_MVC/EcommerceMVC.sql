-- Create database
CREATE DATABASE ECommerceDB;
GO

USE ECommerceDB;
GO

-- Create Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Create Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000) NULL,
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    ImageUrl NVARCHAR(500) NULL,
    CategoryId INT NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Insert categories
INSERT INTO Categories (Name, Description) VALUES 
('Electronics', 'Gadgets and devices'),
('Clothing', 'Fashion and apparel'),
('Books', 'Reading materials');

-- Insert products
INSERT INTO Products (Name, Description, Price, StockQuantity, CategoryId, ImageUrl) VALUES 
('iPhone 15 Pro', 'Apple latest smartphone', 99999.00, 10, 1, 'https://images.unsplash.com/photo-1695048133142-1a20484d2569?w=300&h=200&fit=crop'),
('Samsung Galaxy S24', 'Premium Android phone', 89999.00, 15, 1, 'https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=300&h=200&fit=crop'),
('Men T-Shirt', '100% cotton comfortable', 1499.00, 50, 2, 'https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?w=300&h=200&fit=crop'),
('C# Programming', 'Learn C# step by step', 2499.00, 30, 3, 'https://images.unsplash.com/photo-1532012197267-da84d127e765?w=300&h=200&fit=crop');