CREATE DATABASE RetailStoreDB;
use RetailStoreDB;
-- Create Categories table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT,
    Price DECIMAL(10, 2) CHECK(Price >= 0),
    StockQuantity INT CHECK(StockQuantity >= 0),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(20)
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) CHECK(TotalAmount >= 0),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT CHECK(Quantity > 0),
    UnitPrice DECIMAL(10, 2) CHECK(UnitPrice >= 0),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Insert into Categories
INSERT INTO Categories VALUES 
(1, 'Electronics'),
(2, 'Books'),
(3, 'Clothing');

-- Insert into Products
INSERT INTO Products VALUES 
(101, 'Smartphone', 1, 29999.99, 50),
(102, 'Laptop', 1, 55000.00, 20),
(103, 'Novel - The Alchemist', 2, 399.50, 100),
(104, 'T-shirt', 3, 599.00, 75);

-- Insert into Customers
INSERT INTO Customers VALUES 
(1, 'Ravi Kumar', 'ravi@gmail.com', '9876543210'),
(2, 'Sneha Das', 'sneha@gmail.com', '9123456789');

-- Insert into Orders
INSERT INTO Orders VALUES 
(1001, 1, '2025-07-30', 30399.49),
(1002, 2, '2025-07-31', 56199.00);

-- Insert into OrderDetails
INSERT INTO OrderDetails VALUES 
(1, 1001, 103, 1, 399.50),
(2, 1001, 101, 1, 29999.99),
(3, 1002, 102, 1, 55000.00),
(4, 1002, 104, 2, 599.50);

SELECT * FROM Categories;
SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;

-- Total sales amount grouped by category
SELECT 
    c.CategoryName,
    SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM 
    OrderDetails od
JOIN Products p ON od.ProductID = p.ProductID
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName;

-- Products with low stock
SELECT 
    ProductName, 
    StockQuantity 
FROM 
    Products
WHERE 
    StockQuantity < 10;

-- Products with low stock
SELECT 
    ProductName, 
    StockQuantity 
FROM 
    Products
WHERE 
    StockQuantity < 10;

-- Get order info with customer and product details
SELECT 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    c.Email,
    p.ProductName,
    od.Quantity,
    od.UnitPrice
FROM 
    Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate DESC;

-- Transaction for bulk stock update
BEGIN TRY
    BEGIN TRANSACTION;

    -- Reduce stock of product 101 by 5
    UPDATE Products
    SET StockQuantity = StockQuantity - 5
    WHERE ProductID = 101;

    -- Reduce stock of product 102 by 3
    UPDATE Products
    SET StockQuantity = StockQuantity - 3
    WHERE ProductID = 102;

    -- Check if stock went negative (invalid case)
    IF EXISTS (
        SELECT * FROM Products WHERE StockQuantity < 0
    )
    BEGIN
        -- Throw custom error
        RAISERROR('Stock level cannot be negative.', 16, 1);
    END

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;

    -- Optional: Print error info
    PRINT 'Transaction failed. Rolling back.';
    PRINT ERROR_MESSAGE();
END CATCH;

CREATE PROCEDURE GetOrdersByCustomer
    @CustomerID INT
AS
BEGIN
    SELECT 
        o.OrderID,
        o.OrderDate,
        p.ProductName,
        od.Quantity,
        od.UnitPrice
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
    WHERE o.CustomerID = @CustomerID;
END;

EXEC GetOrdersByCustomer @CustomerID = 1;

create function GetDiscount(@price decimal(10,2),@discount decimal(5,2))
returns decimal(10,2)
as
begin
return @price*(1-@discount/100);
end

SELECT dbo.GetDiscount(1000,10) as DiscountedPrice

create function GetProductByCatagory(@catagoryId int)
returns table
as
return (select ProductName,Price,ProductID,StockQuantity from Products where CategoryID=@catagoryId);

select * from dbo.GetProductByCatagory(2);

--create procedure which deduct the stock insert 