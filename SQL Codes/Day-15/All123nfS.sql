create database Day15;
use Day15

-- Step 2: Create the 1NF table
CREATE TABLE EmployeeRaw (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Role VARCHAR(100),
    Dept VARCHAR(50),
    DeptLocation VARCHAR(100),
    ManagerName VARCHAR(100),
    ManagerRole VARCHAR(100),
    ManagerDept VARCHAR(50)
);

-- Step 3: Insert data into 1NF table
INSERT INTO EmployeeRaw VALUES 
(201, 'Alice Brown', 'HR Executive', 'HR', 'Mumbai', 'Priya Mehta', 'HR Manager', 'HR'),
(202, 'Bob Smith', 'IT Analyst', 'IT', 'Pune', 'Karan Kapoor', 'IT Head', 'IT'),
(203, 'John Davis', 'HR Executive', 'HR', 'Mumbai', 'Priya Mehta', 'HR Manager', 'HR'),
(204, 'Riya Shah', 'HR Manager', 'HR', 'Mumbai', 'Arjun Sharma', 'HR Director', 'HR'),
(205, 'Priya Mehta', 'HR Manager', 'HR', 'Mumbai', 'Arjun Sharma', 'HR Director', 'HR');





--2NF
CREATE TABLE Department (
    Dept VARCHAR(50) PRIMARY KEY,
    DeptLocation VARCHAR(100)
);

--2NF & 3NF
CREATE TABLE Manager (
    ManagerName VARCHAR(100) PRIMARY KEY,
    ManagerRole VARCHAR(100),
    ManagerDept VARCHAR(50)
);

--referencing Manager and Dept
CREATE TABLE Employee (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Role VARCHAR(100),
    Dept VARCHAR(50),
    ManagerName VARCHAR(100),
    
    FOREIGN KEY (Dept) REFERENCES Department(Dept),
    FOREIGN KEY (ManagerName) REFERENCES Manager(ManagerName)
);

-- Step 5: Insert into Department
INSERT INTO Department (Dept, DeptLocation) VALUES 
('HR', 'Mumbai'),
('IT', 'Pune');

-- Step 6: Insert into Manager
INSERT INTO Manager (ManagerName, ManagerRole, ManagerDept) VALUES 
('Priya Mehta', 'HR Manager', 'HR'),
('Karan Kapoor', 'IT Head', 'IT'),
('Arjun Sharma', 'HR Director', 'HR');

-- Step 7: Insert into Employee
INSERT INTO Employee (EmpID, EmpName, Role, Dept, ManagerName) VALUES 
(201, 'Alice Brown', 'HR Executive', 'HR', 'Priya Mehta'),
(202, 'Bob Smith', 'IT Analyst', 'IT', 'Karan Kapoor'),
(203, 'John Davis', 'HR Executive', 'HR', 'Priya Mehta'),
(204, 'Riya Shah', 'HR Manager', 'HR', 'Arjun Sharma'),
(205, 'Priya Mehta', 'HR Manager', 'HR', 'Arjun Sharma');

SELECT * FROM Employee;
SELECT * FROM Department;
SELECT * FROM Manager;
SELECT 
    e.EmpID,
    e.EmpName,
    e.Role AS EmployeeRole,
    e.Dept,
    d.DeptLocation,
    e.ManagerName,
    m.ManagerRole,
    m.ManagerDept
FROM Employee e
JOIN Department d ON e.Dept = d.Dept
JOIN Manager m ON e.ManagerName = m.ManagerName;

