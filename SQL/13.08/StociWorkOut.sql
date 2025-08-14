--DDL
create database StoicWorkout
go
use StoicWorkout
go
-- Users  table
create table Users(
ID int primary key identity(1,1),
UserName nvarchar(255) not null,
Email nvarchar(255) not null,
Password int not null)

go
-- UserProfiles table
Create table  UserProfiles(
ID int primary key identity(1,1) foreign key references Users(ID),
FirstName nvarchar(255) not null,
SurName nvarchar(255) not null,
Gender nchar(10) not null,
Age int not null)
go
--Products table
Create table  Products(
ID int primary key identity(1,1),
ProductName nvarchar(255) not null,
UnitPrice money null,
UnitInStock smallint null,
CategoriesID int  foreign key references Categories(ID))
--Categories table
go
Create table Categories(
ID int primary key identity(1,1),
CategoryName nvarchar(255) not null,
Description ntext null,
Picture image null)
go
--




