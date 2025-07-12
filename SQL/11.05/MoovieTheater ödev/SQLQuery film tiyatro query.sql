--Subquery
--Ortalama süreden daha uzun olan film
select Filmismi,Uzunluk from Filmler where Uzunluk>(select AVG(uzunluk)from Filmler)



-- inner join
--film adlarý ve hangi kategoriye aitler
select Filmismi,KategoriIsmi from Filmler f
join Kategoriler k on f.ID=k.ID

--Drama türündeki film adý ve oynadýðý salon ile birlikte sýrala
select f.Filmismi,k.KategoriIsmi, s.Salonismi from  Filmler f
join Kategoriler k
on k.ID=f.ID
join Salonlar s
on s.ID=f.ID
where k.KategoriIsmi= 'Drama'
-- Tarih fonsiyonu
-- 2016 yýlýndaki son haftalar
select Songun from Haftalar where YEAR(Songun)=2016
-- Order by 
--Salonlarýn kapasitesini azdan çoka doðru sýralayýn
select Kapasite from Salonlar order by Kapasite 
-- Aggragate fonsiyonu
-- Salonlarýn kapasitesi toplam ne kadardýr?
select sum(Kapasite) as 'Toplam kapasite'  from Salonlar



