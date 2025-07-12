-- Database
Create database FilmTiyatro
go
use FilmTiyatro
go
-- Tables
-- Salonlar
Create table Salonlar(
ID int primary key identity (1,1),
Salonismi char(1) not null,
Kapasite tinyint not null)
go
--Seanslar
Create table Seanslar(
ID int primary key identity(1,1),
SeansZamani time(7) not null)
go
--Haftalar
Create table Haftalar(
ID int primary key identity(1,1),
Hafta char(3) not null,
Ilkgun date not null,
Songun date not null)
go
--Filmler
create table Filmler(
ID int primary key identity(1,1),
Filmismi nvarchar(255) not null,
Aciklama nvarchar(500) not null,
Uzunluk tinyint not null)
go
--Sinema
Create table Sinema(
ID int primary key identity(1,1),
FilmID int foreign key references Filmler(ID),
SalonID int foreign key references Salonlar(ID),
SeansID int foreign key references Seanslar(ID),
Haftalar int foreign key references Haftalar(ID))
go
-- Kategoriler
Create table Kategoriler(
ID int primary key identity(1,1),
KategoriIsmi nvarchar(50) not null)
go
-- Filmler ve kategoriler
Create table FilmlerVeKategoriler(
FilmID int foreign key references Filmler(ID),
KategoriID int foreign key references Kategoriler(ID),
Primary key (FilmID,KategoriID)) 
go
-- Veriler
-- Salonlar
insert Salonlar (Salonismi,Kapasite) values ('A','40')
insert Salonlar (Salonismi,Kapasite) values ('B','58')
insert Salonlar (Salonismi,Kapasite) values ('C','94')
--Seanslar
insert Seanslar(SeansZamani) values ('11:00:00')
insert Seanslar(SeansZamani) values ('12:00:00')
insert Seanslar(SeansZamani) values ('13:30:00')
--Haftalar
insert Haftalar(Hafta,Ilkgun,Songun) values ('W32','2016-08-08','2016-08-14')
insert Haftalar(Hafta,Ilkgun,Songun) values ('W33','2016-08-15','2016-08-21')
insert Haftalar(Hafta,Ilkgun,Songun) values ('W34','2016-08-22','2016-08-28')
--Filmler
insert Filmler(Filmismi,Aciklama,Uzunluk) values ('The Shawshank Redemption','Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.','142')
insert Filmler(Filmismi,Aciklama,Uzunluk) values ('Back to the Future','Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.','114')
--Sinema
insert Sinema(FilmID,SalonID,SeansID,Haftalar) values ('1','1','1','1')
insert Sinema(FilmID,SalonID,SeansID,Haftalar) values ('2','2','1','1')
--Kategoriler
insert Kategoriler(KategoriIsmi) values ('Polisiye')
insert Kategoriler(KategoriIsmi) values ('Drama')
insert Kategoriler(KategoriIsmi) values ('Action')
--FilmlerVeKategoriler
insert FilmlerVeKategoriler(FilmID,KategoriID) values ('1','1')
insert FilmlerVeKategoriler(FilmID,KategoriID) values ('1','2')










