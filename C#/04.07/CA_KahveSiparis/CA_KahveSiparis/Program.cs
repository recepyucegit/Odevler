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



using CA_KahveSiparis;

KahveSiparisCRUD kahveSiparisCRUD = new KahveSiparisCRUD();

KahveBilgi k1 = new KahveBilgi();

k1.Id = 1;
k1.KahveIsim = " Filtre Kahve";
k1.KahveFiyat = 150;
kahveSiparisCRUD.CreateKahve(k1);

KahveBilgi k2 = new KahveBilgi();

k2.Id = 2;
k2.KahveIsim = "Latte";
k2.KahveFiyat = 150;
kahveSiparisCRUD.CreateKahve(k2);

Console.WriteLine("Güncelleme Öncesi");
kahveSiparisCRUD.GetAllProducts();

//KahveBilgi guncellenecekKahve = new KahveBilgi();

//guncellenecekKahve.Id = 1;
//guncellenecekKahve.KahveIsim = " Espresso";
//guncellenecekKahve.KahveFiyat = 200;

//kahveSiparisCRUD.UpdateCoffe(guncellenecekKahve);

//Console.WriteLine("Güncelleme Sonrası:");
//kahveSiparisCRUD.GetAllProducts();

//kahveSiparisCRUD.DeleteCoffe(2);
//Console.WriteLine("***2 nolu ıd kaldırıldı. ****");

//kahveSiparisCRUD.GetAllProducts();


    
    











//#region Global Alan
//int secim = -1;
//string[] kahveMenu = { "Filtre", "Latte", "Americano", "Espresso" };
//decimal[] kahveFiyatlari = { 90, 120, 150, 150 };
//decimal toplamTutar = 0;
//int adet = 0;
//string musteriBilgisi = "";
//string[] siparisler = new string[3];
//string tanimliKullaniciAd = "admin";
//string tanimliSifre = "1234";
//string gelenKullaniciAd = "";
//string gelenSifre = "";
//int jeton = 0;

//#endregion

//int z = 0;
//#region İşlem

//#region Kullanıcı Bilgileri
//Console.WriteLine("Kullanıcı ad: ");
//gelenKullaniciAd = Console.ReadLine();
//Console.WriteLine("Şifre: ");
//gelenSifre = Console.ReadLine(); 
//#endregion

//if (gelenKullaniciAd == tanimliKullaniciAd && gelenSifre == tanimliSifre)
//{
  
//    do
//    {

//        for (int i = 0; i < kahveMenu.Length; i++)
//        {
//            string format = $"{i + 1}-{kahveMenu[i]}-{kahveFiyatlari[i]}";
//            Console.WriteLine(format);
//        }

//        try
//        {
//            Console.WriteLine("seçim: ");
//            secim = int.Parse(Console.ReadLine());//10

//            //kullanıcın seçimi kahvelerin index'i dışında ise kullanıcıya mesaj verin.
//            if (secim <= 0 || secim - 1 > kahveMenu.Length)
//            {
//                Console.WriteLine($"lütfen 1 ile {kahveMenu.Length} aralığında bir değer girin");
//            }
//            else
//            {
//                string gelenKahve = kahveMenu[secim - 1];
//                decimal gelenFiyat = kahveFiyatlari[secim - 1];

//                //Adet
//                Console.WriteLine("Adet: ");
//                adet = int.Parse(Console.ReadLine());
//                toplamTutar = adet * gelenFiyat;

//                //Müşteri bilgisi
//                Console.WriteLine("Ad: ");
//                musteriBilgisi += Console.ReadLine() + " ";
//                Console.WriteLine("Soyad: ");
//                musteriBilgisi += Console.ReadLine() + " ";
//                Console.WriteLine("Adres: ");
//                musteriBilgisi += Console.ReadLine() + " ";

//                musteriBilgisi += $"Seçili Kahve: {gelenKahve} Birim Fiyat: {gelenFiyat} Adet: {adet} Toplam Tutar: {toplamTutar}";

//                Console.WriteLine(musteriBilgisi);

//                siparisler[z] = musteriBilgisi;
//                z++;

//            }


//        }
//        catch (Exception ex)
//        {

//            Console.WriteLine(ex.Message);
//        }

//    } while (z < 3);

//    Console.WriteLine("***Alınan Siparişler****");
//    foreach (string siparis in siparisler)
//    {
//        Console.WriteLine(siparis);
//    }
//}
//else
//{
//    Console.WriteLine("kullanıcı bilgileriniz hatalı!!!");
//}




//#endregion

