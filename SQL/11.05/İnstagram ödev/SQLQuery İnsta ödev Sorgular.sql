--Tarih fonksiyonlarý
-- En son mesaj atýlalý kaç gün geçmiþtir?
select MessageDate   , datediff(DAY,MessageDate, getdate()) as 'Geçen gün' from Messages

--Aggregate Fonksiyon
--Kaç mesaj vardýr?
select count(MessageContent) as 'Mesaj sayýsý' from Messages
-- Toplam beðeni kaçtýr?
select SUM(Begeni) as'Toplam beðeni'  from Photos

--Group by
--Kullanýcýlarýn yaptýðý yorumlarýn sayýsý
select ID, COUNT(content) as 'Yapýlan yorum' from Comments group by ID

--Order by
-- Kullanýcýlarýn doðum tarihlerini azdan çoka doðru sýralayýn?
select BirthDate, FirstName, LastName  from UserProfiles  order by BirthDate desc

-- Subquery 
-- Yorumlar tablosunda yapýlan yorum ve kangi kullanýcýnýn yaptýðýný listeleyin?
select Content,(select FirstName from UserProfiles where UserProfiles.ID=Comments.UserID) as 'Kullanýcý ismi' from Comments



