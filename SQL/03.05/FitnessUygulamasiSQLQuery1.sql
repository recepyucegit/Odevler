--BodyProgress, exercises, leaderboard, userprofiles, lift progress tablosunu listeleyin
select * from BodyProgress
select * from Exercises 
select * from LeaderBoard
select * from UserProfiles
select * from LiftProgress
--Kullanýcý profili 2 olan kullanýcýyý listeleyin.
select * from UserProfiles where ID=2
--Vücut yaðý %15 ve üzeri olanlarý listeleyin
select * from BodyProgress where BodyFat >15
--Squat aðýrlýðý 80 den küçükleri listeleyin
select Squat from LeaderBoard where Squat <80
--2 numaralý kullanýcýnýn göðüs ölçüsünü listeleyin
select Chestmeasure from Measurements where ID=2
--Dips aðýrlýðý 10 ile 40 arasýnda olanlar önce dahil olsun sonra olmasýn
select Dips from LiftProgress where Dips between 10 and 40
select Dips from LiftProgress where Dips >10 and dips <40