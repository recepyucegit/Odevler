--BodyProgress, exercises, leaderboard, userprofiles, lift progress tablosunu listeleyin
select * from BodyProgress
select * from Exercises 
select * from LeaderBoard
select * from UserProfiles
select * from LiftProgress
--Kullan�c� profili 2 olan kullan�c�y� listeleyin.
select * from UserProfiles where ID=2
--V�cut ya�� %15 ve �zeri olanlar� listeleyin
select * from BodyProgress where BodyFat >15
--Squat a��rl��� 80 den k���kleri listeleyin
select Squat from LeaderBoard where Squat <80
--2 numaral� kullan�c�n�n g���s �l��s�n� listeleyin
select Chestmeasure from Measurements where ID=2
--Dips a��rl��� 10 ile 40 aras�nda olanlar �nce dahil olsun sonra olmas�n
select Dips from LiftProgress where Dips between 10 and 40
select Dips from LiftProgress where Dips >10 and dips <40