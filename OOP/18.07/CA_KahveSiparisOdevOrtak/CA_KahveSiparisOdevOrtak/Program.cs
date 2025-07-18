/*
 //Kahve Sipariş Uygulaması
//Filtre 90 TL, Latte 120 TL, Americano 110TL, Espresso 150 TL

//Uygulama çalıştığında sisteme kullanıcı giriş yapabilmeli. Giriş başarılı şekilde gerçekleştirildikten sonra kullanıcnın hesabına maksimum 3 adet sipariş verebilmesi için hak tanımlanmalı.

//Sisteme hoşgeldiniz. Maksimum 3 adet sipariş verebilirsiniz.
//1-Sipariş Oluştur
//2-Sipariş Adet Güncelle
//3-Çıkış.
seçim: 1
**Kahvelerimiz***
1-Filtre 90 TL
2-Latte 120 TL
3-Americano 110 TL
4-Espresso 150 TL
secim: 2
Adet: 2
Sipariş işlemini bilgilerinizi girin:
Ad: Fatih
Soyad: Günalp
Adres: Kadıköy
-------------
Siparişiniz oluşturuldu ödemeniz gereken toplam tutar 240 TL
Kalan sipariş hakkınız 2
--------------------------
Opsiyonel: Alınan siparişlerin özetleri
 */

// Kahveler adında Baseclass  oluşturlacak

//Metotlar oluşturulacak
//CRUD
//KahveDAta adında listede toplayacağımız class oluşturulucak
//IconsoleMenude oluşturduğumuz eğlemler giriş, şipariş işlemleri


using CA_KahveSiparisOdevOrtak;

KahveSiparis kahveSiparis = new KahveSiparis();

KahveSiparisCRUD kahveSiparisCRUD = new KahveSiparisCRUD();
kahveSiparisCRUD.Hoşgeldiniz();
kahveSiparis.KahveMenuOlustur();
kahveSiparisCRUD.kullaniciGiris();
    

