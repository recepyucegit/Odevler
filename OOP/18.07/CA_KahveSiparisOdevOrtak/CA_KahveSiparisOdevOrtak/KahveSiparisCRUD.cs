using CA_KahveSiparisOdevOrtak.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_KahveSiparisOdevOrtak
{
    internal class KahveSiparisCRUD : KahveData, IKahveSiparis
    {

        
        int secim = -1;
        int siparisHakki = 3;
        int siparisAdet = 0;
        string musteriBilgisi = "";
        string[] siparisler = new string[3];

        public void Hoşgeldiniz()
        {
            Console.WriteLine("Kafemize Hoşgeldiniz");
        }

        public void kullaniciGiris()
        {
            if(siparisHakki > 0)
            {
                string kullanıcıGiris = "admin";
                string kullanıcıGirisSifre = "1234";
                Console.WriteLine("Kullanıcı Adınızı Giriniz:");
                string kullaniciAd = Console.ReadLine();
                Console.WriteLine("Şifrenizi Giriniz:");
                string kullaniciSifre = Console.ReadLine();
                if (kullaniciAd == kullanıcıGiris && kullaniciSifre == kullanıcıGirisSifre)
                {
                    Console.WriteLine("Giriş Başarılı!");
                    Console.WriteLine("Maksimum 3 adet sipariş verebilirsiniz.");
                    while (siparisHakki > 0)
                    {
                        Console.WriteLine("1-Sipariş Oluştur");
                        Console.WriteLine("2-Sipariş Adet Güncelle");
                        Console.WriteLine("3-Çıkış");
                        Console.Write("Seçiminizi yapınız: ");
                        secim = Convert.ToInt32(Console.ReadLine());
                        switch (secim)
                        {
                            case 1:
                                MenuGoster();
                                Console.WriteLine("Kahve seçiniz: ");
                                int kahveSecim = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Sipariş Adetini Giriniz: ");
                                siparisAdet = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Adınızı Giriniz: ");
                                string ad = Console.ReadLine();
                                Console.Write("Soyadınızı Giriniz: ");
                                string soyad = Console.ReadLine();
                                Console.Write("Adresinizi Giriniz: ");
                                string adres = Console.ReadLine();
                                
                                musteriBilgisi = $"Ad: {ad}, Soyad: {soyad}, Adres: {adres}";
                                
                                decimal toplamTutar = siparisAdet * KahveData.KahveListesi[0].KahveFiyat; 
                                
                                siparisler[siparisHakki - 1] = $"{musteriBilgisi} - Sipariş Adedi: {siparisAdet}, Toplam Tutar: {toplamTutar} TL";
                                
                                Console.WriteLine($"Siparişiniz oluşturuldu. Ödemeniz gereken toplam tutar: {toplamTutar} TL");
                                siparisHakki--;
                                break;
                            case 2:
                                
                                break;
                            case 3:
                                Console.WriteLine("Çıkış yapılıyor...");
                                return;
                            default:
                                Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                                break;
                        }
                    }
                    siparisHakki--;
                }
                else
                {
                    Console.WriteLine("Giriş Başarısız! Kalan Sipariş Hakkınız: " + siparisHakki);
                    siparisHakki--;
                    kullaniciGiris();
                }
            }
            else
            {
                Console.WriteLine("Sipariş hakkınız kalmadı.");
            }
        }

        public void MenuGoster()
        {
            foreach (var kahve in KahveData.KahveListesi)
            {
                Console.WriteLine($" {kahve.KahveId} Kahve Adı: {kahve.KahveAd}, Fiyat: {kahve.KahveFiyat} TL");
            }
        }

        public void MenuOlustur(KahveBilgi kahveBilgi)
        {
            KahveData.KahveListesi.Add(kahveBilgi);
        }


    }
}
