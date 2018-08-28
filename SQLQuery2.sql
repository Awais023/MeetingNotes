USE ProjectNotes
GO

CREATE TABLE Project
(
ID int IDENTITY(1,1) primary key ,
Name varchar(50) NOT NULL,
Severity varchar(50) Default 'Low' check(Severity='High' OR Severity='Average' OR Severity='Low') NOT NULL,
)
Insert into Project values ('Smart Investment', 'High')
Insert into Project values ('Text Summarization', 'High')


CREATE TABLE Note
(
ID int IDENTITY(1,1)  primary key ,
ProjectID int  foreign key references Project(ID),
Agenda varchar(50) ,
DateOfNote DateTime ,
Attendee varchar(50) NOT NULL,
DescriptionOfNote varchar(500),
Status varchar(50),
ImagePath varchar(max) 
)
drop table note
CREATE TABLE UserAccount
(
ID int IDENTITY(1,1) Primary Key,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Email varchar(50) NOT NULL Unique,
Username varchar(50),
Password varchar(50),
ConfirmPassword varchar(50),
)

CREATE TABLE UserGroup
(
ID int IDENTITY(1,1) Primary Key,
Name  varchar(50) NOT NULL Unique,
Email varchar(50)
)
CREATE TABLE AddParticipant
(
AdditionNo int IDENTITY(1,1) primary key,
GroupID int  foreign key references UserGroup(ID),
Emails  varchar(50) NOT NULL Unique
)


Select* from Note
Select * from Project
select* from UserGroup
Select* from AddParticipant 
select* from UserAccount

Select emails As Participants from AddParticipant where GroupID=1








Select* from dbo.AspNetRoles
Select* from dbo.AspNetUsers
Select* from dbo.AspNetUserRoles

Alter Table AspNetUsers drop column FullName varchar(50)

delete from  AspNetUserRoles where  UserId='2b537981-9331-4154-ba96-3ef78b595e0f'

