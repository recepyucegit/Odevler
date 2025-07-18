--Subquery
-- filimler tablosunda ortalama alt�nda puan alm�� filmleri listeleyin
select * from Movies where Rating< ( select AVG(Rating) from Movies)
-- ortalama film s�resinden k�sa filmler
select Title,RuntimeMinutes from Movies where RuntimeMinutes<( select AVG(RuntimeMinutes) from Movies)

--Metascore 60 dan az  filmler ve y�netmenleri
select Title,(select FullName from Directors where Directors.Id=Movies.Director_Id) as ' Yonetmen isimleri' ,Metascore from Movies where Metascore<60 order by 2 
-- y�netmenler ka� film �ekmi�
select  (select FullName  from Directors d where d.Id=m.Director_Id ),COUNT(Id) '�ekti�i film' from Movies m group by Director_Id


-- inner join
-- film reytingi 80 �st� olan filmler ve y�netmenler
select m.Title,m.Rating,d.FullName from Movies m
inner join Directors d on d.FullName=m.Director_Id
where m.Rating>80
--100 milyon alt�nda kazan� sa�layan filmler ve Y�netmenleri
select m.Title,m.RevenueMillions,d.FullName as'Yonetmen'from Movies m
inner join Directors d on d.Id=m.Director_Id
where m.RevenueMillions<=100
--film t�rleri ve adlar�
select m.Title as'Film adi',g.Name as'film tur' from Movies m
inner join MovieGenres mg on m.Id=mg.Movie_Id
inner join Genres g on g.Id=mg.Genre_Id