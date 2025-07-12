--Subquery
-- filimler tablosunda ortalama altýnda puan almýþ filmleri listeleyin
select * from Movies where Rating< ( select AVG(Rating) from Movies)
-- ortalama film süresinden kýsa filmler
select Title,RuntimeMinutes from Movies where RuntimeMinutes<( select AVG(RuntimeMinutes) from Movies)

--Metascore 60 dan az  filmler ve yönetmenleri
select Title,(select FullName from Directors where Directors.Id=Movies.Director_Id) as ' Yonetmen isimleri' ,Metascore from Movies where Metascore<60 order by 2 
-- yönetmenler kaç film çekmiþ
select  (select FullName  from Directors d where d.Id=m.Director_Id ),COUNT(Id) 'çektiði film' from Movies m group by Director_Id


-- inner join
-- film reytingi 80 üstü olan filmler ve yönetmenler
select m.Title,m.Rating,d.FullName from Movies m
inner join Directors d on d.FullName=m.Director_Id
where m.Rating>80
--100 milyon altýnda kazanç saðlayan filmler ve Yönetmenleri
select m.Title,m.RevenueMillions,d.FullName as'Yonetmen'from Movies m
inner join Directors d on d.Id=m.Director_Id
where m.RevenueMillions<=100
--film türleri ve adlarý
select m.Title as'Film adi',g.Name as'film tur' from Movies m
inner join MovieGenres mg on m.Id=mg.Movie_Id
inner join Genres g on g.Id=mg.Genre_Id