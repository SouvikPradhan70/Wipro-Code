create database CollegeDB;
USE CollegeDB;

CREATE TABLE Student(
StudentID INT PRIMARY KEY,
FullName VARCHAR(50) NOT NULL,
Email VARCHAR(100)UNIQUE NOT NULL,
Age INT CHECK(Age>=18)
);
CREATE TABLE Instructor(
InstructorID INT PRIMARY KEY,
FullName varchar (100),
Email varchar(100) unique 
);


Create table Course(
CourseID INT PRIMARY KEY,
CourseName varchar(100),
InstructorID INT,
Foreign key (InstructorID) references Instructor(InstructorID)
);
create table Enrollment(
EnrollmentID INT PRIMARY KEY,
StudentID INT,
CourseID INT,
EnrollmentDate Date Default GETDATE(),
Foreign key(StudentID) references Student(StudentID),
foreign key(CourseID) references Course(CourseID)
);
DROP TABLE Enrollment;
DROP TABLE COURSE;

--insserting into tabels
INSERT INTO Instructor values(1,'Dr.Smith','smith@gmail.com'),
(2,'Prof.Mani','mani@gmail.com');

insert into Course values(101,'Data Science',1),
(102,'Computer Science',1);
select * from Course
select * from Instructor

insert into Student values(1,'Rohit','rohit96@gmai.comm',17);-- will not accept because of age
insert into Student values(1,'Remo','rohit96@gmai.comm',19);
insert into Student values(2,'Rajiv','rohit96@gmai.comm',20);--will not accept as email is not unique
insert into Student values(2,'Sonia','sionia96@gmai.comm',20);
select * from Student

--inserting values in enrollment
insert into Enrollment values(1001,1,101,GETDATE());
INSERT INTO Enrollment values(1002,2,102,GETDATE());

SELECT * FROM Enrollment

--grant and revoke
GRANT SELECT ON Student to auditor;
GRANT SELECT ON Enrollment to auditor;

--for above to work we have to create login and user
CREATE LOGIN auditor with Password='StrongPassword123';
CREATE USER auditor for login auditor;

REVOKE SELECT ON Student from auditor --revoke access after some time

--implementing a transaction with commit and rollback
Begin Transaction
insert into Student values(3,'Souvik','souvik@gmail',20);
insert into Enrollment values(1003,3,101,GETDATE());
COMMIT;

--ROLLBACK
Begin Transaction
insert into Student values(4,'Isita','isita@gmail',17);
insert into Enrollment values(1004,4,102,GETDATE());
ROLLBACK;

-- Which student enrolled in which course
SELECT 
    s.FullName, 
    c.CourseName
FROM 
    Student s
LEFT JOIN 
    Enrollment e ON s.StudentId = e.StudentId
LEFT JOIN 
    Course c ON e.CourseID = c.CourseID;

-- Who is teaching the each cource 

Select i.FullName , c.CourseName from Instructor i
join 
   Course c on i.InstructorID= c.InstructorID;


-- Create Procedure to view Student data by id
create procedure GetStudentInfoById
@studentId int
as
begin
select * from Student where studentid= @studentId;
end;

execute GetStudentInfoById 3;


