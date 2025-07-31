-- Create Department Table
CREATE TABLE Dept (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

-- Create Employees Table
CREATE TABLE Employees (
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Salary DECIMAL(10,2),
    DeptID INT,
    ManagerID INT,
    DateOfJoin DATE
);

-- Insert Data into Dept Table
INSERT INTO Dept VALUES 
(1, 'HR'),
(2, 'Finance'),
(3, 'IT');
INSERT INTO Dept VALUES (4, 'Customer Support');


-- Insert Data into Employees Table
INSERT INTO Employees VALUES
(101, 'Souvik', 30000, 3, NULL, '2025-07-01'),
(102, 'Supriya', 50000, 2, 101, '2025-07-01'),
(103, 'Parth', 20000, 2, 101, '2025-07-01'),
(104, 'Suryakant', 35000, 1, 103, '2025-07-01'),
(105, 'Kareena', 22000, 3, NULL, '2025-07-01');
INSERT INTO Employees VALUES(106,'Kishor', 80000,5,null,'2018-01-15');

-- View the Tables
SELECT * FROM Dept;
SELECT * FROM Employees;

--Build in scalar fun 
select EmpName,LEN(EmpName) AS LenEmpName from Employees;
SELECT EmpName,Round(Salary,-3)as RoundedSalary from Employees;
select GETDATE() as currentDate;

--aggregate function
select count(*) as TotalEmployee from Employees;
select Round(avg(Salary),-3) as AvgSalary from Employees;
select max(Salary) as MaxSalary from Employees;

--joins
--Inner join
select E.EmpName,D.DeptName from Employees E INNER JOIN Dept D on E.DeptID=D.DeptID;
select E.EmpName,D.DeptName from Employees E LEFT JOIN Dept D on E.DeptID=D.DeptID;
select E.EmpName,D.DeptName from Employees E RIGHT JOIN Dept D on E.DeptID=D.DeptID;
select E.EmpName,D.DeptName from Employees E FULL OUTER JOIN Dept D on E.DeptID=D.DeptID;
Select E1.EmpName AS Employee, E2.EmpName AS Manager FROM Employees E1  Left JOIN  Employees E2  ON E1.ManagerID = E2.EmpID;
SELECT EmpName, DeptName FROM Employees cross join Dept;

--set operation
select EmpName from Employees union select DeptName from Dept;
select DeptID from Employees intersect select DeptID from Dept;

select DeptID from Dept MINUS SELECT DeptID from Employees;

create procedure DisplayDepartments
as
Begin
select * from Dept;
end;

execute DisplayDepartments;

---- lets create a stored procedure for getting employee details
create procedure GetEmployeeDetails
@EmpID int, @EmpName varchar(100) output
as
begin
select @EmpName = EmpName from Employees where EmpID = @EmpID;

End;

declare @Name varchar(100);
execute GetEmployeeDetails 103, @EmpName = @Name output;
print @Name;

--- update employee details

CREATE PROCEDURE UpdateEmployeeDetails
    @EmpID INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary 
    WHERE EmpID = @EmpID;

    -- Optional: Return all employees for review
    SELECT * FROM Employees;
END;

-- Call UpdateEmployeeDetails
EXEC UpdateEmployeeDetails @EmpID = 103, @NewSalary = 45000.00;

--- check salary


create procedure CheckSalary
@EmpID int 
as
begin
declare @Salary decimal(10,2)
select @Salary = Salary from Employees where EmpID = @EmpID;
if @Salary> 55000
print 'High Earner'
else
print 'Low Earner';
end;


---Creating  a transaction & error handling
BEGIN TRY
BEGIN Transaction;
update Employees set Salary=Salary+5000 where DeptID=1;
commit --all changes are permannent
END TRY
BEGIN CATCH
ROLLBACK;
PRINT Error_Message();
END CATCH
SELECT * FROM Employees WHERE DeptID=1;

--scalar function
create function GetYearOfJoining(@EmpID INT)
RETURNS INT
AS
BEGIN 
Declare @Year INT;
SELECT @Year=YEAR(DateOfJoin) FROM Employees where EmpId=@EmpID;
RETURN @Year;
END

--CALLING a fun
SELECT EmpName,dbo.GetYearOfJoining(EmpID) as JoiningYear FROM Employees;

--Inline table valued function
create function GetEmployeeByDept(@DeptID INT)
returns table 
as
return(
select EmpId,EmpName,Salary from Employees where DeptID=@DeptID
)
SELECT * FROM dbo.GetEmployeeByDept(1)


---calling function inside a procedure
create procedure PrintEmployeeJoingYear
@EmpID INT 
AS 
begin
declare @Year int;
set @Year=dbo.GetYearOfJoining(@EmpID)
print 'Joined'+CAST(@Year as varchar);
END;

EXECUTE PrintEmployeeJoingYear 101;



