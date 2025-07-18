--Subquery
--Ortalama s�reden daha uzun olan film
select Filmismi,Uzunluk from Filmler where Uzunluk>(select AVG(uzunluk)from Filmler)



-- inner join
--film adlar� ve hangi kategoriye aitler
select Filmismi,KategoriIsmi from Filmler f
join Kategoriler k on f.ID=k.ID

--Drama t�r�ndeki film ad� ve oynad��� salon ile birlikte s�rala
select f.Filmismi,k.KategoriIsmi, s.Salonismi from  Filmler f
join Kategoriler k
on k.ID=f.ID
join Salonlar s
on s.ID=f.ID
where k.KategoriIsmi= 'Drama'
-- Tarih fonsiyonu
-- 2016 y�l�ndaki son haftalar
select Songun from Haftalar where YEAR(Songun)=2016
-- Order by 
--Salonlar�n kapasitesini azdan �oka do�ru s�ralay�n
select Kapasite from Salonlar order by Kapasite 
-- Aggragate fonsiyonu
-- Salonlar�n kapasitesi toplam ne kadard�r?
select sum(Kapasite) as 'Toplam kapasite'  from Salonlar



