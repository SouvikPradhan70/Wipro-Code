create DATABASE HollySSS
USE HollySSS
-- Step 1: Drop tables if they already exist
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Department;

-- Step 2: Create Department table
CREATE TABLE Department (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

-- Step 3: Create Employees table
CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Salary DECIMAL(10,2),
    DeptID INT,
    FOREIGN KEY (DeptID) REFERENCES Department(DeptID)
);

-- Step 4: Insert sample data into Department
INSERT INTO Department (DeptID, DeptName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Marketing');

-- Step 5: Insert sample data into Employees
INSERT INTO Employees (EmpID, EmpName, Salary, DeptID) VALUES
(101, 'Souvik Pradhan', 45000.00, 2),
(102, 'Priya Das', 50000.00, 1),
(103, 'Rahul Roy', 60000.00, 2),
(104, 'Sneha Sinha', 48000.00, 3);

-- Step 6: Perform an INNER JOIN to show employee with department name
SELECT e.EmpName, e.Salary, d.DeptName
FROM Employees e
JOIN Department d ON e.DeptID = d.DeptID;
