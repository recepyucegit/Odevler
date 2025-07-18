--Tarih fonksiyonlar�
-- En son mesaj at�lal� ka� g�n ge�mi�tir?
select MessageDate   , datediff(DAY,MessageDate, getdate()) as 'Ge�en g�n' from Messages

--Aggregate Fonksiyon
--Ka� mesaj vard�r?
select count(MessageContent) as 'Mesaj say�s�' from Messages
-- Toplam be�eni ka�t�r?
select SUM(Begeni) as'Toplam be�eni'  from Photos

--Group by
--Kullan�c�lar�n yapt��� yorumlar�n say�s�
select ID, COUNT(content) as 'Yap�lan yorum' from Comments group by ID

--Order by
-- Kullan�c�lar�n do�um tarihlerini azdan �oka do�ru s�ralay�n?
select BirthDate, FirstName, LastName  from UserProfiles  order by BirthDate desc

-- Subquery 
-- Yorumlar tablosunda yap�lan yorum ve kangi kullan�c�n�n yapt���n� listeleyin?
select Content,(select FirstName from UserProfiles where UserProfiles.ID=Comments.UserID) as 'Kullan�c� ismi' from Comments



