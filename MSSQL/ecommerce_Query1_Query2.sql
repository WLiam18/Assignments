--QS1.Create a database named ECOMMERCE_ASSIGNMENT_DB.
CREATE DATABASE ECOMMERCE_ASSIGNMENT_DB;
USE ECOMMERCE_ASSIGNMENT_DB;

--QS2.Create a table named Customer.
--QS7..Add proper primary keys to all tables.
CREATE TABLE Customer
(
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    MobileNo VARCHAR(20),
    City VARCHAR(50),
    Address VARCHAR(200),
    IsActive BIT,
    CreatedDate DATETIME
);

--QS3.Create a table named Seller.
--QS7..Add proper primary keys to all tables.
CREATE TABLE Seller
(
    SellerId INT PRIMARY KEY IDENTITY(1,1),
    SellerName VARCHAR(100),
    Email VARCHAR(100),
    MobileNo VARCHAR(20),
    City VARCHAR(50),
    Rating DECIMAL (3,2),
    IsActive BIT
);

--QS4.Create a table named Product.
--QS7..Add proper primary keys to all tables.
--QS9.Add foreign key relationship between Seller and Product.
CREATE TABLE Product
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2),
    StockQuantity INT,
    SellerId INT,
    CreatedDate DATETIME,

    FOREIGN KEY (SellerId) REFERENCES Seller(SellerId)
);


--QS5.Create a table named Orders.
--QS7..Add proper primary keys to all tables.
--QS8.Add foreign key relationship between Customer and Orders.
CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT,
    OrderDate DATETIME,
    OrderStatus VARCHAR(50),
    PaymentMode VARCHAR(50),
    DeliveryCity VARCHAR(50),
    CreatedDate DATETIME,

    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

--QS6.Create a table named OrderItem.
--QS7..Add proper primary keys to all tables.
--QS10.Add foreign key relationship between Orders and OrderItem.
--QS11.Add foreign key relationship between Product and OrderItem.
CREATE TABLE OrderItem
(
    OrderitemId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    ProductId INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2),

    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);

--QS12.Add UNIQUE constraint for customer email.
-- remove unique temporarily because Email column must be modified first
ALTER TABLE Customer
DROP CONSTRAINT UQ_Customer_Email;

--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE Customer
ALTER COLUMN Email VARCHAR(100) NOT NULL;

--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE Customer
ALTER COLUMN City VARCHAR(50) NOT NULL;

--QS12.Add UNIQUE constraint for customer email.
ALTER TABLE Customer
ADD CONSTRAINT UQ_Customer_Email
UNIQUE (Email);

--QS20.Add DEFAULT constraint for customer status.
ALTER TABLE Customer
ADD CONSTRAINT DF_Customer_IsActive
DEFAULT 1 FOR IsActive;




--QS13.Add UNIQUE constraint for seller email.
ALTER TABLE Seller
ALTER COLUMN SellerName VARCHAR(100) NOT NULL;

--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE Seller
ALTER COLUMN Email VARCHAR(100) NOT NULL;

--QS13.Add UNIQUE constraint for seller email.
ALTER TABLE Seller
ADD CONSTRAINT UQ_Seller_Email
UNIQUE (Email);


--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE Product
ALTER COLUMN ProductName VARCHAR(100) NOT NULL;

ALTER TABLE Product
ALTER COLUMN Category VARCHAR(50) NOT NULL;

ALTER TABLE Product
ALTER COLUMN SellerId INT NOT NULL;

--QS15.Add CHECK constraint for product price greater than 0.
ALTER TABLE Product
ADD CONSTRAINT CHK_Product_Price
CHECK (Price > 0);

--QS16.Add CHECK constraint for stock quantity greater than or equal to 0.
ALTER TABLE Product
ADD CONSTRAINT CHK_Product_Stock
CHECK (StockQuantity >= 0);

--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE Orders
ALTER COLUMN CustomerId INT NOT NULL;

--QS18.Add DEFAULT constraint for order date.
ALTER TABLE Orders
ADD CONSTRAINT DF_Order_Date
DEFAULT GETDATE() FOR OrderDate;

--QS19.Add DEFAULT constraint for order status.
ALTER TABLE Orders
ADD CONSTRAINT DF_Order_Status
DEFAULT 'Pending' FOR OrderStatus;

--QS14.Add NOT NULL constraints for important columns.
ALTER TABLE OrderItem
ALTER COLUMN OrderId INT NOT NULL;

ALTER TABLE OrderItem
ALTER COLUMN ProductId INT NOT NULL;

--QS17.Add CHECK constraint for order quantity greater than 0.
ALTER TABLE OrderItem
ADD CONSTRAINT CHK_OrderItem_Quantity
CHECK (Quantity > 0);




--INSERT 
--QS1.Insert at least 5 customer records.

INSERT INTO Customer
(CustomerName, Email, MobileNo, City, Address, IsActive, CreatedDate)

VALUES

('Arun','arun@gmail.com','9876543210','Chennai','Anna Nagar',1,GETDATE()),
('Bala','bala@gmail.com','9876543211','Bangalore','MG Road',1,GETDATE()),
('Charan','charan@gmail.com','9876543212','Hyderabad','Cyber City',1,GETDATE()),
('Deepak','deepak@gmail.com','9876543213','Chennai','Tambaram',1,GETDATE()),
('Ajay','ajay@gmail.com','9876543214','Coimbatore','Peelamedu',1,GETDATE());


--QS2.Insert at least 4 seller records.

INSERT INTO Seller

(SellerName,Email,MobileNo,City,Rating,IsActive)

VALUES

('Cloudtail','cloudtail@gmail.com','9000000001','Chennai',4.5,1),
('Retailnet','retailnet@gmail.com','9000000002','Bangalore',4.2,1),
('Reliance','relaince@gmail.com','9000000003','Hyderabad',4.7,1),
('croma','croma@gmail.com','9000000004','Mumbai',4.1,1);


--QS3.Insert at least 8 product records.

INSERT INTO Product

(ProductName,Category,Price,StockQuantity,SellerId,CreatedDate)

VALUES

('iPhone 15','Mobile',75000,20,1,GETDATE()),
('Samsung S24','Mobile',68000,15,2,GETDATE()),
('MacBook Air','Laptop',95000,10,3,GETDATE()),
('Dell Inspiron','Laptop',62000,8,3,GETDATE()),
('Boat Headphones','Accessories',2500,50,4,GETDATE()),
('Nothing Phone','Mobile',32000,25,2,GETDATE()),
('HP Pavilion','Laptop',70000,6,3,GETDATE()),
('Asus Vivobook','Laptop',55000,12,3,GETDATE());


--QS4.Insert at least 5 order records.

INSERT INTO Orders

(CustomerId,PaymentMode,DeliveryCity)

VALUES

(1,'UPI','Chennai'),
(2,'Card','Bangalore'),
(3,'Cash','Hyderabad'),
(1,'UPI','Chennai'),
(5,'Card','Coimbatore');


--QS5.Insert at least 10 order item records.

INSERT INTO OrderItem

(OrderId,ProductId,Quantity,UnitPrice)

VALUES

(1,1,1,75000),
(1,5,2,2500),
(2,2,1,68000),
(2,6,1,32000),
(3,3,1,95000),
(3,5,1,2500),
(4,4,1,62000),
(4,2,1,68000),
(5,7,1,70000),
(5,1,1,75000);




--UPDATE 
--QS6.Update one customer city.
UPDATE Customer SET City='Madurai' WHERE CustomerId=2;

--QS7.Update one product price.
UPDATE Product SET Price=80000 WHERE ProductId=1;

--QS8.Update one order status.
UPDATE Orders SET OrderStatus='Delivered' WHERE OrderId=1;




--DELETE
--QS9.Delete one product that is not used in any order item.
SELECT * FROM Product WHERE ProductId NOT IN

(
    SELECT ProductId

    FROM OrderItem
);

DELETE FROM Product

WHERE ProductId = 8;





--SELECT
--QS10.Select all records from all tables.

SELECT * FROM Customer;

SELECT * FROM Seller;

SELECT * FROM Product;

SELECT * FROM Orders;

SELECT * FROM OrderItem;

--WHERE CLAUSE based questions
--QS1.Display all customers from Chennai.
SELECT * FROM Customer WHERE City='Chennai';

--QS2.Display all customers not from Chennai.
SELECT * FROM Customer WHERE City != 'Chennai';

--QS3.Display all products with price greater than 50000.
SELECT *FROM Product WHERE Price > 50000;

--QS4.Display all products with price between 10000 and 60000.
SELECT * FROM Product WHERE Price BETWEEN 10000 AND 60000;

--QS5.Display all products from category Mobile or Laptop.
SELECT * FROM Product WHERE Category='Mobile' OR Category='Laptop';

--QS6.Display all customers whose name starts with A.
SELECT * FROM Customer WHERE CustomerName LIKE 'A%';

--QS7.Display all customers whose email contains gmail.
SELECT * FROM Customer WHERE Email LIKE '%gmail%';

--QS8.Display all products whose product name contains Phone.
SELECT * FROM Product WHERE ProductName LIKE '%Phone%';

--QS9.Display all orders with status Delivered.
SELECT * FROM Orders WHERE OrderStatus='Delivered';

--QS10.Display all products where stock quantity is less than 10.
SELECT * FROM Product WHERE StockQuantity < 10;

--QS11.Display all customers where mobile number is not null.
SELECT * FROM Customer WHERE MobileNo IS NOT NULL;

--QS12.Display all products where price is not between 10000 and 50000.
SELECT * FROM Product WHERE Price NOT BETWEEN 10000 AND 50000;

--QS13.Display all customers from Chennai or Bangalore.
SELECT * FROM Customer WHERE City='Chennai' OR City='Bangalore';

--QS14.Display all customers from Chennai and active status.
SELECT * FROM Customer WHERE City='Chennai' AND IsActive=1;

--QS15.Display all customers except those from Hyderabad.
SELECT * FROM Customer WHERE City!='Hyderabad';






--GROUP BY based questions
--QS1.Count total customers city-wise.
SELECT City,COUNT(*) AS TotalCustomers FROM Customer GROUP BY City;

--QS2.Count total products category-wise.
SELECT Category,
COUNT(*) AS TotalProducts FROM Product GROUP BY Category;

--QS3.Find total stock quantity category-wise.
SELECT Category,SUM(StockQuantity) AS TotalStock FROM Product GROUP BY Category;

--QS4.Find maximum product price category-wise.
SELECT Category,
MAX(Price) AS MaximumPrice FROM Product GROUP BY Category;

--QS5.Find minimum product price category-wise.
SELECT Category,MIN(Price) AS MinimumPrice FROM Product GROUP BY Category;

--QS6.Find average product price category-wise.
SELECT Category,AVG(Price) AS AveragePrice FROM Product GROUP BY Category;

--QS7.Find total order amount customer-wise.
SELECT CustomerId,SUM(Quantity * UnitPrice) AS TotalAmount FROM Orders O
JOIN OrderItem OI ON O.OrderId = OI.OrderId
GROUP BY CustomerId;

--QS8.Find total sales product-wise.
SELECT ProductId,SUM(Quantity * UnitPrice) AS TotalSales FROM OrderItem GROUP BY ProductId;

--QS9.Find total quantity sold product-wise.
SELECT ProductId,SUM(Quantity) AS TotalQuantity FROM OrderItem GROUP BY ProductId;

--QS10.Display only categories having more than 1 product.
SELECT Category,COUNT(*) AS ProductCount FROM Product GROUP BY Category HAVING COUNT(*) > 1;

--QS11.Display only customers whose total order amount is greater than 50000.
SELECT CustomerId,SUM(Quantity * UnitPrice) AS TotalAmount
FROM Orders O
JOIN OrderItem OI
ON O.OrderId=OI.OrderId GROUP BY CustomerId HAVING SUM(Quantity * UnitPrice) > 50000;

--QS12.Find seller-wise total number of products.
SELECT SellerId,COUNT(*) AS TotalProducts FROM Product GROUP BY SellerId;

--QS13.Find seller-wise total sales amount.
SELECT SellerId,SUM(Quantity * UnitPrice) AS TotalSales
FROM Product P 
JOIN OrderItem OI ON P.ProductId=OI.ProductId GROUP BY SellerId;

--QS14.Find order status-wise order count.
SELECT OrderStatus,COUNT(*) AS OrderCount FROM Orders GROUP BY OrderStatus;

--QS15.Find city-wise customer count and sort by highest count.
SELECT City,COUNT(*) AS TotalCustomers FROM Customer 
GROUP BY City
ORDER BY TotalCustomers DESC;



--ORDER BY based questions

--QS1.Display products by price ascending.
SELECT * FROM Product ORDER BY Price ASC;

--QS2.Display products by price descending.
SELECT * FROM Product ORDER BY Price DESC;

--QS3.Display customers by city ascending and customer name ascending.
SELECT * FROM Customer ORDER BY City ASC,CustomerName ASC;

--QS4.Display orders by order date descending.
SELECT * FROM Orders ORDER BY OrderDate DESC;

--QS5.Display products by category ascending and price descending.
SELECT * FROM Product ORDER BY Category ASC,Price DESC;

--QS6.Display top 3 highest priced products.
SELECT TOP 3 * FROM Product ORDER BY Price DESC;

--QS7.Display top 5 recent orders.
SELECT TOP 5 * FROM Orders ORDER BY OrderDate DESC;

--QS8.Display customers sorted by active status and name.
SELECT * FROM Customer ORDER BY IsActive DESC,CustomerName ASC;


--JOIN based questions
--QS1.Display orders with customer details using INNER JOIN.
SELECT * FROM Orders O INNER JOIN Customer C
ON O.CustomerId = C.CustomerId;

--QS2.Display products with seller details using INNER JOIN.
SELECT * FROM Product P INNER JOIN Seller S
ON P.SellerId = S.SellerId;

--QS3.Display order items with product details using INNER JOIN.
SELECT * FROM OrderItem OI INNER JOIN Product P
ON OI.ProductId = P.ProductId;

--QS4.Display complete order report with customer, order, product, and seller details.
SELECT * FROM Customer C INNER JOIN Orders O
ON C.CustomerId = O.CustomerId
INNER JOIN OrderItem OI
ON O.OrderId = OI.OrderId
INNER JOIN Product P
ON OI.ProductId = P.ProductId
INNER JOIN Seller S
ON P.SellerId = S.SellerId;

--QS5.Display all customers and their orders using LEFT JOIN.
SELECT *FROM Customer C LEFT JOIN Orders O 
ON C.CustomerId = O.CustomerId;

--QS6.Display all orders and customers using RIGHT JOIN.
SELECT * FROM Customer C RIGHT JOIN Orders O 
ON C.CustomerId = O.CustomerId;

--QS7.Display all customers and all orders using FULL OUTER JOIN.
SELECT * FROM Customer C FULL OUTER JOIN Orders O
ON C.CustomerId = O.CustomerId;

--QS8.Display all possible combinations of customers and products using CROSS JOIN.
SELECT * FROM Customer CROSS JOIN Product;

--QS9.Display customers who have not placed any order.
SELECT * FROM Customer C LEFT JOIN Orders O
ON C.CustomerId = O.CustomerId
WHERE O.OrderId IS NULL;

--QS10.Display products that are not ordered.
SELECT * FROM Product P LEFT JOIN OrderItem OI
ON P.ProductId = OI.ProductId
WHERE OI.ProductId IS NULL;

--QS11.Display seller-wise product list.
SELECT SellerName,ProductName
FROM Seller S INNER JOIN Product P
ON S.SellerId=P.SellerId;

--QS12.Display customer-wise ordered products.
SELECT CustomerName,ProductName FROM Customer C
INNER JOIN Orders O
ON C.CustomerId=O.CustomerId
INNER JOIN OrderItem OI
ON O.OrderId=OI.OrderId
INNER JOIN Product P
ON OI.ProductId=P.ProductId;

--QS13.Display order-wise total amount.
SELECT OrderId,SUM(Quantity * UnitPrice) AS TotalAmount FROM OrderItem
GROUP BY OrderId;

--QS14.Display seller-wise total sales.
SELECT SellerName,SUM(Quantity * UnitPrice) AS TotalSales FROM Seller S
INNER JOIN Product P
ON S.SellerId=P.SellerId
INNER JOIN OrderItem OI
ON P.ProductId=OI.ProductId
GROUP BY SellerName;

--QS15.Display product-wise total sales quantity.
SELECT ProductName,SUM(Quantity) AS TotalSold
FROM Product P
INNER JOIN OrderItem OI
ON P.ProductId=OI.ProductId
GROUP BY ProductName;





--DAY 2 Assignment 

--Subquery based questions

--QS1.Display all products whose price is greater than the average product price. 
SELECT * FROM Product
WHERE Price > 
    (
    SELECT AVG(Price) FROM Product
    );

--QS2.Display all products whose stock quantity is less than the average stock quantity. 
SELECT * FROM Product WHERE StockQuantity <
    (
    SELECT AVG(StockQuantity) FROM Product
    );

--QS3.Display all customers who placed at least one order. 
SELECT * FROM Customer WHERE CustomerId IN
    (
    SELECT CustomerId FROM Orders
    );

--QS4.Display all customers who have not placed any order. 
SELECT * FROM Customer WHERE CustomerId NOT IN
    (
    SELECT CustomerId FROM Orders
    );
--QS5.Display all products that are ordered at least once. 
SELECT * FROM Product WHERE ProductId IN
    (
    SELECT ProductId FROM OrderItem
    );
--QS6.Display all products that are not ordered by any customer. 
SELECT * FROM Product WHERE ProductId NOT IN
    (
    SELECT ProductId FROM OrderItem
    );
--QS7.Display all sellers who are selling at least one product. 
SELECT * FROM Seller WHERE SellerId IN
    (
    SELECT SellerId FROM Product
    );

--QS8.Display all sellers who are not selling any product. 
SELECT * FROM Seller WHERE SellerId NOT IN
    (
    SELECT SellerId FROM Product
    );

--QS9.Display all orders placed by customers from Chennai. 
SELECT * FROM Orders WHERE CustomerId IN
    (
    SELECT CustomerId FROM Customer WHERE City='Chennai'
    );

--QS10.Display all products sold by sellers from Bangalore. 
SELECT * FROM Product WHERE SellerId IN
    (
    SELECT SellerId FROM Seller WHERE City='Bangalore'
    );




--Subqueries using IN / NOT IN 


--QS11.Display customer details for customers who have placed orders. 
SELECT * FROM Customer WHERE CustomerId IN
    (
    SELECT CustomerId FROM Orders
    );

--QS12.Display customer details for customers who have not placed any orders. 
SELECT * FROM Customer WHERE CustomerId NOT IN
    (
    SELECT CustomerId FROM Orders
    );

--QS13.Display product details for products that are available in the OrderItem table. 
SELECT * FROM Product WHERE ProductId IN
    (
    SELECT ProductId FROM OrderItem
    );

--QS14.Display product details for products that are not available in the OrderItem table. 
SELECT * FROM Product WHERE ProductId NOT IN
    (
    SELECT ProductId FROM OrderItem
    );

--QS15.Display seller details for sellers who have products in the Product table. 
SELECT * FROM Seller WHERE SellerId IN
    (
    SELECT SellerId FROM Product
    );

--QS16.Display seller details for sellers who do not have any products. 
SELECT * FROM Seller WHERE SellerId NOT IN
    (
    SELECT SellerId FROM Product
    );

--QS17.Display orders that contain products from the Mobile category. 
SELECT * FROM Orders WHERE OrderId IN
    (
    SELECT OrderId FROM OrderItem WHERE ProductId IN
    (
        SELECT ProductId FROM Product WHERE Category='Mobile'
    )
);

--QS18.Display orders that do not contain products from the Laptop category. 
SELECT * FROM Orders WHERE OrderId NOT IN
    (
    SELECT OrderId FROM OrderItem WHERE ProductId IN
    (
        SELECT ProductId FROM Product WHERE Category='Laptop'
    )
);


--Subquery with Aggregate Functions

--QS19.Display the product details of the highest priced product. 
SELECT * FROM Product WHERE Price =
    (
    SELECT MAX(Price) FROM Product
    );

--QS20.Display the product details of the lowest priced product. 
SELECT * FROM Product WHERE Price =
    (
    SELECT MIN(Price) FROM Product
    );

--QS21.Display products whose price is greater than the average price of all products. 
SELECT * FROM Product WHERE Price >
    (
    SELECT AVG(Price) FROM Product
    );

--QS22.Display products whose price is less than the average price of all products. 
SELECT * FROM Product WHERE Price <
    (
    SELECT AVG(Price) FROM Product
    );

--QS23.Display customers whose total order amount is greater than the average order amount. 
SELECT CustomerId,SUM(Quantity * UnitPrice) AS TotalAmount
FROM Orders O JOIN OrderItem OI
ON O.OrderId=OI.OrderId
GROUP BY CustomerId
HAVING SUM(Quantity * UnitPrice) >
(
    SELECT AVG(TotalAmount)
    FROM
    (
        SELECT SUM(Quantity * UnitPrice) AS TotalAmount
        FROM Orders O JOIN OrderItem OI
        ON O.OrderId=OI.OrderId
        GROUP BY CustomerId
    ) A
);

--QS24.Display sellers whose total sales amount is greater than 50000. 
SELECT SellerId,SUM(Quantity * UnitPrice) AS TotalSales
FROM Product P
JOIN OrderItem OI ON P.ProductId=OI.ProductId
GROUP BY SellerId
HAVING SUM(Quantity * UnitPrice) > 50000;

--QS25.Display products whose total sold quantity is greater than the average sold quantity. 
SELECT ProductId,SUM(Quantity) AS TotalSold FROM OrderItem
GROUP BY ProductId
HAVING SUM(Quantity) >
    (
    SELECT AVG(TotalSold) FROM
    (
        SELECT SUM(Quantity) AS TotalSold
        FROM OrderItem
        GROUP BY ProductId
    ) A
);
--QS26.Display the customer who has spent the highest total amount. 
SELECT TOP 1 CustomerId,SUM(Quantity * UnitPrice) AS TotalSpent
FROM Orders O
JOIN OrderItem OI ON O.OrderId=OI.OrderId
GROUP BY CustomerId
ORDER BY TotalSpent DESC;

--QS27.Display the product that has generated the highest sales amount. 
SELECT TOP 1 ProductId,SUM(Quantity * UnitPrice) AS TotalSales
FROM OrderItem
GROUP BY ProductId
ORDER BY TotalSales DESC;

--QS28.Display the seller who has generated the highest total sales. 
SELECT TOP 1 SellerId,SUM(Quantity * UnitPrice) AS TotalSales
FROM Product P
JOIN OrderItem OI
ON P.ProductId=OI.ProductId
GROUP BY SellerId
ORDER BY TotalSales DESC;





--Correlated Subquery Questions
--QS29.Display products whose price is greater than the average price of products in the same category. 
SELECT * FROM Product P1 WHERE Price >
    (
    SELECT AVG(Price) FROM Product P2 WHERE P1.Category=P2.Category
    );

--QS30.Display products whose price is less than the average price of products in the same category. 
SELECT * FROM Product P1 WHERE Price <
    (
    SELECT AVG(Price) FROM Product P2 WHERE P1.Category=P2.Category
    );
--QS31.Display sellers who have more than 2 products. 
SELECT * FROM Seller S WHERE
    (
    SELECT COUNT(*) FROM Product P WHERE S.SellerId=P.SellerId
    ) > 2;

--QS32.Display customers who have placed more than one order. 
SELECT * FROM Customer C WHERE
    (
    SELECT COUNT(*) FROM Orders O WHERE C.CustomerId=O.CustomerId
    ) > 1;

--QS33.Display orders whose order amount is greater than the average order amount of all orders. 
SELECT OrderId,SUM(Quantity * UnitPrice) AS TotalAmount
FROM OrderItem GROUP BY OrderId
HAVING SUM(Quantity * UnitPrice) >
    (
        SELECT AVG(OrderAmount) FROM
        (
            SELECT SUM(Quantity * UnitPrice) AS OrderAmount
            FROM OrderItem
            GROUP BY OrderId
        ) A
);
--QS34.Display products where stock quantity is greater than the average stock quantity of products from the same category.
SELECT * FROM Product P1 WHERE StockQuantity >
    (
    SELECT AVG(StockQuantity) FROM Product P2 WHERE P1.Category=P2.Category
    );

--QS35.Display sellers whose product price average is greater than the overall product average price. 
SELECT * FROM Seller S WHERE
    (
    SELECT AVG(Price) FROM Product P WHERE S.SellerId=P.SellerId
    )
    >
        (
        SELECT AVG(Price) FROM Product
        );






--EXISTS / NOT EXISTS Questions

--QS36.Display customers who have placed at least one order using EXISTS. 
SELECT * FROM Customer C WHERE EXISTS
    (
        SELECT *
        FROM Orders O
        WHERE C.CustomerId = O.CustomerId
    );

--QS37.Display customers who have not placed any order using NOT EXISTS. 
SELECT * FROM Customer C WHERE NOT EXISTS
    (
        SELECT *
        FROM Orders O
        WHERE C.CustomerId = O.CustomerId
    );

--QS38.Display products that are ordered at least once using EXISTS. 
SELECT * FROM Product P WHERE EXISTS
    (
        SELECT * FROM OrderItem OI WHERE P.ProductId = OI.ProductId
    );

--QS39.Display products that are not ordered using NOT EXISTS. 
SELECT * FROM Product P WHERE NOT EXISTS
    (
        SELECT * FROM OrderItem OI WHERE P.ProductId = OI.ProductId
    );

--QS40.Display sellers who have at least one product using EXISTS. 
SELECT * FROM Seller S WHERE EXISTS
    (
        SELECT * FROM Product P WHERE S.SellerId = P.SellerId
    );

--QS41.Display sellers who do not have any product using NOT EXISTS. 
SELECT * FROM Seller S WHERE NOT EXISTS
    (
        SELECT * FROM Product P WHERE S.SellerId = P.SellerId
    );

--QS42.Display customers who ordered any Mobile category product. 
SELECT *
FROM Customer C
WHERE EXISTS
    (
        SELECT * FROM Orders O 
        JOIN OrderItem OI ON O.OrderId = OI.OrderId
        JOIN Product P ON OI.ProductId = P.ProductId
        WHERE C.CustomerId = O.CustomerId
        AND Category='Mobile'
    );

--QS43.Display customers who never ordered any Laptop category product. 
SELECT * FROM Customer C WHERE NOT EXISTS
    (
        SELECT * FROM Orders O
        JOIN OrderItem OI ON O.OrderId = OI.OrderId
        JOIN Product P ON OI.ProductId = P.ProductId
        WHERE C.CustomerId = O.CustomerId
        AND Category='Laptop'
    );








--Stored Procedure  Questions
--QS1.Create a stored procedure to display all customer records. 
GO

CREATE PROCEDURE GetAllCustomers
AS
BEGIN

SELECT * FROM Customer;

END;

GO
EXEC GetAllCustomers;
--QS2.Create a stored procedure to display all product records. 
GO

CREATE PROCEDURE GetAllProducts
AS
BEGIN

SELECT * FROM Product;

END;

GO
EXEC GetAllProducts;

--QS3.Create a stored procedure to display all seller records. 
GO
CREATE PROCEDURE GetAllSellers
AS
BEGIN

SELECT * FROM Seller;

END;
GO
EXEC GetAllSellers;

--QS4.Create a stored procedure to display all order records. 
GO
CREATE PROCEDURE GetAllOrders
AS
BEGIN

SELECT *FROM Orders;

END;
GO
EXEC GetAllOrders;

--QS5.Create a stored procedure to display all order item records. 
GO
CREATE PROCEDURE GetAllOrderItems
AS
BEGIN

SELECT *FROM OrderItem;

END;
GO
EXEC GetAllOrderItems;





--Stored Procedure with Input Parameter
--QS6.Create a stored procedure to display customer details based on CustomerId. 
GO

CREATE PROCEDURE GetCustomerById
@CustomerId INT

AS
BEGIN

SELECT * FROM Customer
WHERE CustomerId=@CustomerId;

END
GO
EXEC GetCustomerById 1;

--QS7.Create a stored procedure to display product details based on ProductId. 
GO

CREATE PROCEDURE GetProductById
@ProductId INT

AS
BEGIN

SELECT * FROM Product WHERE ProductId=@ProductId;

END
GO
EXEC GetProductById 2;

--QS8.Create a stored procedure to display seller details based on SellerId. 
GO

CREATE PROCEDURE GetSellerById
@SellerId INT

AS
BEGIN

SELECT * FROM Seller WHERE SellerId=@SellerId;

END
GO
EXEC GetSellerById 1;

--QS9.Create a stored procedure to display order details based on OrderId. 
GO

CREATE PROCEDURE GetOrderById
@OrderId INT

AS
BEGIN

SELECT * FROM Orders WHERE OrderId=@OrderId;

END
GO
EXEC GetOrderById 1;

--QS10.Create a stored procedure to display all customers from a given city. 
GO

CREATE PROCEDURE GetCustomersByCity
@City VARCHAR(50)

AS
BEGIN

SELECT * FROM Customer WHERE City=@City;

END
GO
EXEC GetCustomersByCity 'Chennai';

--QS11.Create a stored procedure to display all products from a given category. 
GO

CREATE PROCEDURE GetProductsByCategory
@Category VARCHAR(50)

AS
BEGIN

SELECT * FROM Product WHERE Category=@Category;

END
GO
EXEC GetProductsByCategory 'Mobile';

--QS12.Create a stored procedure to display products based on seller id. 
GO

CREATE PROCEDURE GetProductsBySeller

@SellerId INT

AS
BEGIN

SELECT *
FROM Product
WHERE SellerId=@SellerId;

END

GO
EXEC GetProductsBySeller 1;

--QS13.Create a stored procedure to display orders based on customer id. 
GO

CREATE PROCEDURE GetOrdersByCustomer
@CustomerId INT

AS
BEGIN

SELECT * FROM Orders WHERE CustomerId=@CustomerId;

END
GO
EXEC GetOrdersByCustomer 2;

--QS14.Create a stored procedure to display order items based on order id. 
GO

CREATE PROCEDURE GetOrderItemsByOrder
@OrderId INT

AS
BEGIN

SELECT * FROM OrderItem WHERE OrderId=@OrderId;

END
GO
EXEC GetOrderItemsByOrder 1;

--QS15.Create a stored procedure to display products greater than a given price. 
GO

CREATE PROCEDURE GetProductsGreaterThanPrice
@Price DECIMAL(10,2)

AS
BEGIN

SELECT * FROM Product WHERE Price>@Price;

END
GO
EXEC GetProductsGreaterThanPrice 50000;




--Insert Stored Procedure Questions
--QS16.Create a stored procedure to insert a new customer. 
GO

CREATE PROCEDURE InsertCustomer
@CustomerName VARCHAR(100),
@Email VARCHAR(100),
@MobileNo VARCHAR(20),
@City VARCHAR(50),
@Address VARCHAR(200)

AS
BEGIN

INSERT INTO Customer(CustomerName,Email,MobileNo,City,Address)
VALUES(@CustomerName,@Email,@MobileNo,@City,@Address);

END
GO
EXEC InsertCustomer'Arun','arun@gmail.com','9876543210','Chennai','Anna Nagar';

--QS17.Create a stored procedure to insert a new seller. 
GO

CREATE PROCEDURE InsertSeller
@SellerName VARCHAR(100),
@Email VARCHAR(100),
@MobileNo VARCHAR(20),
@City VARCHAR(50),
@Rating DECIMAL(3,2)

AS
BEGIN

INSERT INTO Seller(SellerName,Email,MobileNo,City,Rating)
VALUES(@SellerName,@Email,@MobileNo,@City,@Rating);

END
GO
EXEC InsertSeller 'TechStore','tech@gmail.com','9999999999','Chennai',4.5;

--QS18.Create a stored procedure to insert a new product. 
GO

CREATE PROCEDURE InsertProduct
@ProductName VARCHAR(100),
@Category VARCHAR(50),
@Price DECIMAL(10,2),
@StockQuantity INT,
@SellerId INT

AS
BEGIN

INSERT INTO Product(ProductName,Category,Price,StockQuantity,SellerId)
VALUES(@ProductName,@Category,@Price,@StockQuantity,@SellerId);

END
GO
EXEC InsertProduct 'iPhone 16','Mobile',75000,10,1;

--QS19.Create a stored procedure to insert a new order. 
GO

CREATE PROCEDURE InsertOrder
@CustomerId INT,
@PaymentMode VARCHAR(50),
@DeliveryCity VARCHAR(50)

AS
BEGIN

INSERT INTO Orders(CustomerId,PaymentMode,DeliveryCity)
VALUES(@CustomerId,@PaymentMode,@DeliveryCity);

END
GO
EXEC InsertOrder 1,'UPI','Chennai';

--QS20.Create a stored procedure to insert a new order item. 
GO

CREATE PROCEDURE InsertOrderItem
@OrderId INT,
@ProductId INT,
@Quantity INT,
@UnitPrice DECIMAL(10,2)

AS
BEGIN

INSERT INTO OrderItem(OrderId,ProductId,Quantity,UnitPrice)
VALUES(@OrderId,@ProductId,@Quantity,@UnitPrice);

END
GO
EXEC InsertOrderItem 1,2,3,50000;




--Update Stored Procedure Questions
--QS21.Create a stored procedure to update customer city based on customer id. 
GO

CREATE PROCEDURE UpdateCustomerCity
@CustomerId INT,
@City VARCHAR(50)

AS
BEGIN

UPDATE Customer SET City=@City WHERE CustomerId=@CustomerId;

END
GO
EXEC UpdateCustomerCity 1,'Bangalore';

--QS22.Create a stored procedure to update customer mobile number based on customer id. 
GO

CREATE PROCEDURE UpdateCustomerMobile
@CustomerId INT,
@MobileNo VARCHAR(20)

AS
BEGIN

UPDATE Customer SET MobileNo=@MobileNo WHERE CustomerId=@CustomerId;

END
GO
EXEC UpdateCustomerMobile 1,'9876543210';

--QS23.Create a stored procedure to update product price based on product id. 
GO

CREATE PROCEDURE UpdateProductPrice
@ProductId INT,
@Price DECIMAL(10,2)

AS
BEGIN

UPDATE Product SET Price=@Price WHERE ProductId=@ProductId;

END
GO
EXEC UpdateProductPrice 1,65000;

--QS24.Create a stored procedure to update product stock quantity based on product id. 
GO

CREATE PROCEDURE UpdateProductStock
@ProductId INT,
@StockQuantity INT

AS
BEGIN

UPDATE Product SET StockQuantity=@StockQuantity WHERE ProductId=@ProductId;

END
GO
EXEC UpdateProductStock 1,20;

--QS25.Create a stored procedure to update order status based on order id. 
GO

CREATE PROCEDURE UpdateOrderStatus
@OrderId INT,
@OrderStatus VARCHAR(50)

AS
BEGIN

UPDATE Orders SET OrderStatus=@OrderStatus WHERE OrderId=@OrderId;

END
GO
EXEC UpdateOrderStatus 1,'Delivered';

--QS26.Create a stored procedure to update seller rating based on seller id. 
GO

CREATE PROCEDURE UpdateSellerRating
@SellerId INT,
@Rating DECIMAL(3,2)

AS
BEGIN

UPDATE Seller SET Rating=@Rating WHERE SellerId=@SellerId;

END
GO
EXEC UpdateSellerRating 1,4.8;

--QS27.Create a stored procedure to update customer active status. 
GO

CREATE PROCEDURE UpdateCustomerStatus
@CustomerId INT,
@IsActive BIT

AS
BEGIN

UPDATE Customer SET IsActive=@IsActive WHERE CustomerId=@CustomerId;

END
GO
EXEC UpdateCustomerStatus 1,1;

--QS28.Create a stored procedure to update seller active status. 
GO

CREATE PROCEDURE UpdateSellerStatus
@SellerId INT,
@IsActive BIT

AS
BEGIN

UPDATE Seller SET IsActive=@IsActive WHERE SellerId=@SellerId;

END
GO
EXEC UpdateSellerStatus 1,1;





--Delete Stored Procedure Questions
--QS29.Create a stored procedure to delete a customer based on customer id. 
GO

CREATE PROCEDURE DeleteCustomer
@CustomerId INT

AS
BEGIN

DELETE FROM Customer WHERE CustomerId=@CustomerId;

END
GO
EXEC DeleteCustomer 1;

--QS30.Create a stored procedure to delete a seller based on seller id. 
GO

CREATE PROCEDURE DeleteSeller
@SellerId INT

AS
BEGIN

DELETE FROM Seller WHERE SellerId=@SellerId;

END
GO
EXEC DeleteSeller 1;

--QS31.Create a stored procedure to delete a product based on product id. 
GO

CREATE PROCEDURE DeleteProduct
@ProductId INT

AS
BEGIN

DELETE FROM Product WHERE ProductId=@ProductId;

END
GO
EXEC DeleteProduct 5;

--QS32.Create a stored procedure to delete an order based on order id. 
GO

CREATE PROCEDURE DeleteOrder
@OrderId INT

AS
BEGIN

DELETE FROM Orders WHERE OrderId=@OrderId;

END
GO
EXEC DeleteOrder 2;

--QS33.Create a stored procedure to delete an order item based on order item id.
GO

CREATE PROCEDURE DeleteOrderItem
@OrderItemId INT

AS
BEGIN

DELETE FROM OrderItem WHERE OrderItemId=@OrderItemId;

END
GO
EXEC DeleteOrderItem 3;






--Stored Procedure with Joins
--QS34.Create a stored procedure to display customer-wise order details. 
GO

CREATE PROCEDURE CustomerWiseOrders

AS
BEGIN

SELECT C.CustomerId,C.CustomerName,O.OrderId,O.OrderDate,O.OrderStatus

FROM Customer C
JOIN Orders O ON C.CustomerId=O.CustomerId;

END
GO
EXEC CustomerWiseOrders;

--QS35.Create a stored procedure to display seller-wise product details. 
GO

CREATE PROCEDURE SellerWiseProducts

AS
BEGIN

SELECT S.SellerId,S.SellerName,P.ProductId,P.ProductName,P.Price
FROM Seller S
JOIN Product P ON S.SellerId=P.SellerId;

END
GO

EXEC SellerWiseProducts;

--QS36.Create a stored procedure to display order-wise product details. 
GO

CREATE PROCEDURE OrderWiseProducts

AS
BEGIN

SELECT O.OrderId,P.ProductName,OI.Quantity,OI.UnitPrice
FROM Orders O
JOIN OrderItem OI ON O.OrderId=OI.OrderId
JOIN Product P ON OI.ProductId=P.ProductId;

END
GO

EXEC OrderWiseProducts;

--QS37.Create a stored procedure to display complete order report with customer, product, seller, quantity, price, and total amount. 
GO

CREATE PROCEDURE CompleteOrderReport

AS
BEGIN

SELECT C.CustomerName,
P.ProductName,
S.SellerName,
OI.Quantity,
OI.UnitPrice,
(OI.Quantity*OI.UnitPrice) AS TotalAmount

FROM Customer C
JOIN Orders O ON C.CustomerId=O.CustomerId
JOIN OrderItem OI ON O.OrderId=OI.OrderId
JOIN Product P ON OI.ProductId=P.ProductId
JOIN Seller S ON P.SellerId=S.SellerId;

END
GO

EXEC CompleteOrderReport;

--QS38.Create a stored procedure to display customer-wise total order amount. 
GO

CREATE PROCEDURE CustomerTotalOrders

AS
BEGIN

SELECT C.CustomerName,
SUM(OI.Quantity*OI.UnitPrice) AS TotalAmount

FROM Customer C
JOIN Orders O ON C.CustomerId=O.CustomerId
JOIN OrderItem OI ON O.OrderId=OI.OrderId

GROUP BY C.CustomerName;

END
GO

EXEC CustomerTotalOrders;

--QS39.Create a stored procedure to display seller-wise total sales amount. 
GO

CREATE PROCEDURE SellerTotalSales

AS
BEGIN

SELECT S.SellerName,
SUM(OI.Quantity*OI.UnitPrice) AS TotalSales

FROM Seller S
JOIN Product P ON S.SellerId=P.SellerId
JOIN OrderItem OI ON P.ProductId=OI.ProductId

GROUP BY S.SellerName;

END
GO

EXEC SellerTotalSales;

--QS40.Create a stored procedure to display product-wise total sales quantity.
GO

CREATE PROCEDURE ProductSalesQuantity

AS
BEGIN

SELECT P.ProductName,
SUM(OI.Quantity) AS TotalQuantity

FROM Product P
JOIN OrderItem OI ON P.ProductId=OI.ProductId

GROUP BY P.ProductName;

END
GO

EXEC ProductSalesQuantity;







--Stored Procedure with Output Parameter
--QS46.Create a stored procedure to return the total number of customers. 
GO

CREATE PROCEDURE TotalCustomers
@TotalCustomers INT OUTPUT

AS
BEGIN

SELECT @TotalCustomers=COUNT(*) FROM Customer;

END
GO

DECLARE @Count INT
EXEC TotalCustomers @Count OUTPUT
SELECT @Count AS TotalCustomers;

--QS47.Create a stored procedure to return the total number of products. 

GO

CREATE PROCEDURE TotalProducts
@TotalProducts INT OUTPUT

AS
BEGIN

SELECT @TotalProducts=COUNT(*) FROM Product;

END
GO

DECLARE @Count INT
EXEC TotalProducts @Count OUTPUT
SELECT @Count AS TotalProducts;

--QS48.Create a stored procedure to return the total number of orders. 
GO

CREATE PROCEDURE TotalOrders
@TotalOrders INT OUTPUT

AS
BEGIN

SELECT @TotalOrders=COUNT(*) FROM Orders;

END
GO

DECLARE @Count INT
EXEC TotalOrders @Count OUTPUT
SELECT @Count AS TotalOrders;

--QS49.Create a stored procedure to return the total sales amount of a product. 
GO

CREATE PROCEDURE ProductSalesAmount
@ProductId INT,
@TotalSales DECIMAL(10,2) OUTPUT

AS
BEGIN

SELECT @TotalSales=SUM(Quantity*UnitPrice) FROM OrderItem
WHERE ProductId=@ProductId;

END
GO

DECLARE @Sales DECIMAL(10,2)
EXEC ProductSalesAmount 1,@Sales OUTPUT
SELECT @Sales AS TotalSales;

--QS50.Create a stored procedure to return the total purchase amount of a customer.
GO

CREATE PROCEDURE CustomerPurchaseAmount
@CustomerId INT,
@TotalPurchase DECIMAL(10,2) OUTPUT

AS
BEGIN

SELECT @TotalPurchase=SUM(OI.Quantity*OI.UnitPrice)

FROM Orders O

JOIN OrderItem OI ON O.OrderId=OI.OrderId
WHERE CustomerId=@CustomerId;

END
GO

DECLARE @Amount DECIMAL(10,2)
EXEC CustomerPurchaseAmount 1,@Amount OUTPUT
SELECT @Amount AS TotalPurchase;