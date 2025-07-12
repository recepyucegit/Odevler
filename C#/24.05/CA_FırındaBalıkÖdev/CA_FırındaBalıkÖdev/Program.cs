//Fırında tavuk tarifi 
// Eldeki malzemeler
// 10 diş sarımsak, 100 ml zeytin yağı, 10 gr karabiber, 10 gr kekik, 5 demet taze biberiye, 100 ml soya sosu, 5 Adet balık, 50 gr tuz


// Değişkenler
//Toplam malzemeler
using System.ComponentModel.DataAnnotations;

int topDisSarimsak = 10;
int topZeytinYagi = 100;
int topKarabiber = 10;
int topKekik = 10;
int topTazeBiberiye = 5;
int topSoyasosu = 100;
int topBalık = 5;
int topTuz = 50;







//Kullanıcıdan Verileri al

try
{
    Console.WriteLine("Sarımsak adeti girin: ");
    int disSarimsak = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Zeytin yağı miktarını girin: ");
    int zeytinyagi = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Karabiber miktarını girin: ");
    int karaBiber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Kekik miktarını girin: ");
    int kekik = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Taze biberiye miktarını girin: ");
    int tazeBiberiye = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Soya sosu miktarını girin: ");
    int soyaSosu = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Balık miktarını girin: ");
    int Balık = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Tuz miktarını girin: ");
    int Tuz = Convert.ToInt32(Console.ReadLine());


    //Yapım Aşaması
    String tepsiTip = "30 cm capinda aliminyum firin tepsisi";

    String havanTip = "3cm capinda tahta havan";
    String firinTip = "Elektirikli 180 derece ayalı fırın";
    Console.WriteLine("Fırın açık mı?");
    firinTip = Console.ReadLine().ToLower();
    if (firinTip == "hayır")
    {
        Console.WriteLine("Fırını çalıştır.");
    }


    else
    {
        Console.WriteLine("devam et");
    }
    Console.WriteLine("Havana  sarımsak ekledin ?");
    Console.ReadLine();
    if (disSarimsak>2&&disSarimsak<4)
    {
        Console.WriteLine("devam et");

    }
    else
    {
        Console.WriteLine("2 adet sarımsak ekle");
    }
    Console.WriteLine("Havana tuz ekledin mi?");
    Console.ReadLine();
    if (Tuz >= 5 && Tuz <= 5)
    {
        Console.WriteLine("Devam et");
    }
    else
    {
        Console.WriteLine("5 gr Tuz ekle");
    }
       
    Console.WriteLine(firinTip + "i calistir ardından ");
    Console.ReadLine();
    Console.WriteLine(disSarimsak + " adet sarimsak  " + zeytinyagi + "ml zeytinyağı ");
    Console.ReadLine();
    Console.WriteLine(karaBiber + "Gr karabiber " + kekik + "Gr kekik  " + tazeBiberiye + "Gr tazebiberiye ");
    Console.ReadLine();
    Console.WriteLine(soyaSosu + "ml soyasou " + Balık + "adet balık " + Tuz + "Gr Tuz " + havanTip + "  kullanarak dov ve karistir ardından  ");
    Console.ReadLine();
    Console.WriteLine("Hazirladigin karisimi " + tepsiTip + "icine dok  " + Balık + " balık ekle  " + "balıklar ve sos karisimini harmanla");
    Console.ReadLine();
    Console.WriteLine("Son olarak hazirladigin tepsiyi  " + firinTip + " a ver 30 dakika sonunda yemegin hazir ");
    Console.ReadLine();
    Console.Read();





    //Kalan malzemeler
    Console.WriteLine("KalanMalzemeler!");
    Console.ReadLine();

    int kalanSarimsak = topDisSarimsak - disSarimsak;
    Console.WriteLine("Kalan Sarımsak adedi: " + kalanSarimsak);
    int kalanZeytinYagi = topZeytinYagi - zeytinyagi;
    Console.WriteLine("Kalan Zeytin yagi miktari: " + kalanZeytinYagi);
    int kalanKarabiber = topKarabiber - karaBiber;
    Console.WriteLine("Kalan Karabiber: " + kalanKarabiber);
    int kalanKekik = topKekik - kekik;
    Console.WriteLine("Kalan kekik: " + kalanKekik);
    int kalanTazeBiberiye = topTazeBiberiye - tazeBiberiye;
    Console.WriteLine("Kalan biberiye: " + kalanTazeBiberiye);
    int kalanSoyaSosu = topSoyasosu - soyaSosu;
    Console.WriteLine("Kalan Soya sosu: " + kalanSoyaSosu);
    int kalanBalık = topBalık - Balık;
    Console.WriteLine("Kalan balık: " + kalanBalık);
    int kalanTuz = topTuz - Tuz;
    Console.WriteLine("Kalan tuz: " + kalanTuz);
}
catch (FormatException)
{
    Console.WriteLine("Sayısal bir deger girin.");
}
   


    

   













