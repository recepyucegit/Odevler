--DDL
create database Streetlifting
go
use Streetlifting
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
--Measurements table
Create table measurements(
ID int primary key identity (1,1) foreign key references UserProfiles(ID),
Neckmeasure int not null,
Chestmeasure int not null,
Bellymeasure int not null,
Quadricepsmasure int not null)
go
-- Lift Progress
create table LiftProgress(
ID int primary key identity (1,1) foreign key references  Userprofiles(ID),
Pullup float not null,
Dips float not null,
Squat float not null)
go
--LeaderBoard 
create table LeaderBoard(
ID int primary key identity (1,1) foreign key references  Userprofiles(ID),
Rate int not null,
Comments nvarchar(255) not null,
Pullup int not null,
Dips int not null,
Chinup int not null,
MuscleUp int not null,
Squat int not null,
Deadlift int not null, 
BenchPress int not null)
go
-- BodyProgress Table
create table BodyProgress(
ID int primary key identity(1,1) foreign key references Measurements(ID),
BodyWeight int not null,
BodyHeight int not null,
BodyFat int not null,
Photo1 nvarchar(255) ,
Photo2 nvarchar(255),
Photo3 nvarchar(255))
go
--Exercises Table 
Create table Exercises(
ID int primary key identity(1,1) foreign key references Users(ID),
CompoundExercise1 nvarchar(255) not null,
CompoundExercise2 nvarchar(255) not null,
CompoundExercise3 nvarchar(255) not null,
CompoundExercise4 nvarchar(255) not null,
CompoundExercise5 nvarchar(255) not null,
IsolationExercise1 nvarchar(255) not null,
IsolationExercise2 nvarchar(255) not null,
IsolationExercise3 nvarchar(255) not null,
IsolationExercise4 nvarchar(255) not null,
IsolationExercise5 nvarchar(255) not null)
go
--Values
--Users Table Values
insert Users(UserName,Email,Password) values  ('zehra','zehra@zehra.com','123')
insert Users(UserName,Email,Password) values ('recep','recep@recep.com','213')
insert Users(UserName,Email,Password) values ('ahmet','ahmet@ahmet.com','512')
insert Users(UserName,Email,Password) values ('mehmet','mehmet@mehmet.com','812')
insert Users(UserName,Email,Password) values ('buse','buse@buse.com','213')
--UserProfiles Values
insert UserProfiles(FirstName,SurName,Gender,Age) values ('Zehra','coksoy','fmale','23')
insert UserProfiles(FirstName,SurName,Gender,Age) values('Recep','Yuce','Male','28')
insert UserProfiles(FirstName,SurName,Gender,Age) values ('Ahmet','Yuce','Male','41')
insert UserProfiles(FirstName,SurName,Gender,Age) values ('Mehmet','Tokgoz','male','27')
insert UserProfiles(FirstName,SurName,Gender,Age) values ('Buse','Yuce','Fmale','21')
--Measurements Values
insert measurements (Neckmeasure,Chestmeasure,Bellymeasure,Quadricepsmasure) values ('21','93','64','85')
insert measurements (Neckmeasure,Chestmeasure,Bellymeasure,Quadricepsmasure) values('39','119','75','95')
insert measurements (Neckmeasure,Chestmeasure,Bellymeasure,Quadricepsmasure) values
('32','100','80','82')
--LiftProgress
insert LiftProgress(Pullup,Dips,Squat) values ('5','10','50')
insert LiftProgress(Pullup,Dips,Squat) values ('20','40','120')
insert LiftProgress(Pullup,Dips,Squat) values ('10','20','80')
insert LiftProgress(Pullup,Dips,Squat) values('5','15','75')
insert LiftProgress(Pullup,Dips,Squat) values('1','5','50')
-- LeaderBoard
insert LeaderBoard(Rate,Comments,Pullup,Dips,Chinup,MuscleUp,Squat,Deadlift,BenchPress) values ('95','HarikaForm','5','10','0','0','80','0','0')
insert LeaderBoard(Rate,Comments,Pullup,Dips,Chinup,MuscleUp,Squat,Deadlift,BenchPress) values ('95','ElindenGeleniYap','20','40','30','5','120','130','105')
insert LeaderBoard(Rate,Comments,Pullup,Dips,Chinup,MuscleUp,Squat,Deadlift,BenchPress) values ('95','UçuyorsunKanka','5','10','10','0','80','0','0')
insert LeaderBoard(Rate,Comments,Pullup,Dips,Chinup,MuscleUp,Squat,Deadlift,BenchPress) values ('95','Ucube misin?','10','20','0','0','50','0','50')
insert LeaderBoard(Rate,Comments,Pullup,Dips,Chinup,MuscleUp,Squat,Deadlift,BenchPress) values ('95','HarikaForm','5','10','0','0','70','0','0')
-- Exercises Values
insert Exercises(CompoundExercise1,CompoundExercise2,CompoundExercise3,CompoundExercise4,CompoundExercise5,IsolationExercise1,IsolationExercise2,IsolationExercise3,IsolationExercise4,IsolationExercise5) values ('Dips','Pullup','Chinup','MuscleUp','Squat','TricepsExtension','ÝnclineBicepsCurl','LateralRaise','RearDeltFly','ÝnclineChestFly')
--BodyProgress Values
insert BodyProgress(BodyWeight,BodyHeight,BodyFat,Photo1,Photo2,Photo3) values ('49','163','21','-','-','-')
insert BodyProgress(BodyWeight,BodyHeight,BodyFat,Photo1,Photo2,Photo3) values ('82','173','17','C:/images/bodyphoto1.jpg','C:/images/bodyphoto2.jpg','-')
insert BodyProgress(BodyWeight,BodyHeight,BodyFat,Photo1,Photo2,Photo3) values ('100','190','15','-','-','-')