-- Data Base
Create database Insta
go
use Insta
go
-- Users Table 
create table Users(
ID int primary key identity(1,1),
UserName nvarchar(50) not null,
Email nvarchar(50) not null,
Password int not null)
go
-- Messages table
create table Messages(
ID int primary key identity(1,1),
MessageContent nvarchar(255) not null,
MessageDate date not null,
SenderID int foreign key references Users(ID))
alter table messages 
add ReciverID int not null

go
-- UserProfiles Table
create table UserProfiles(
ID int primary key identity (1,1) foreign key references Users(ID),
FirstName nchar(50) not null,
LastName nvarchar(50) not null,
BirthDate date not null,
Gender nchar (10) not null,
Adress nvarchar(255))
go
-- Photos Table
create table Photos(
ID int primary key identity(1,1),
PhotoPath nvarchar(255) not null,
PublishedDate date not null,
Content nchar(50) not null,
Begeni int not null,
 UserID int foreign key references UserProfiles(ID))
go

-- Comments Table
create table Comments(
ID int primary key identity(1,1),
CommentDate date not null,
Content nvarchar(255) not null,
PhotoID int foreign key references Photos(ID),
UserID int not null)

go

-- DML 
-- Users values
insert Users ( UserName,Email,Password) values ('Fatih','fatih.gunalp@gmail.com','123')
insert Users ( UserName,Email,Password) values ('Hakan','hakan@hakan.com','321')
insert Users ( UserName,Email,Password) values ('Omer', 'omer@omer.com','321')
insert Users ( UserName,Email,Password) values ('Recep','recep@recep.com','213')
--Messages  values
insert Messages(MessageContent,MessageDate,SenderID,ReciverID) values ('Eyvallah kardeþim','2025-01-27','2','1')
insert Messages(MessageContent,MessageDate,SenderID,ReciverID) values (':)','2025-04-27','1','2')
--User profiles values
insert UserProfiles(FirstName,LastName,BirthDate,Gender,Adress) values ('Hakan','Akçakaya','1990-01-01','Male','Ýstanbul')
insert UserProfiles(FirstName,LastName,BirthDate,Gender,Adress) values ('Fatih','Günalp','1980-07-02','Male','Ankara')
--Photos values
insert Photos(PhotoPath,PublishedDate,Content,Begeni,UserID) values ('C:/Images/manzara.jpg','2025-04-27','Manzara Fotoðrafý','1','2')
insert Photos(PhotoPath,PublishedDate,Content,Begeni,UserID) values('C:/Imagespersonel.jpg','2025-04-27','Selfie','0','1')
--Comments values
insert Comments(CommentDate,Content,PhotoID,UserID) values ('2025-04-27','Güzel Manzara','1','1')
insert Comments(CommentDate,Content,PhotoID,UserID) values ('2025-04-27','Hoþ','2','3')




