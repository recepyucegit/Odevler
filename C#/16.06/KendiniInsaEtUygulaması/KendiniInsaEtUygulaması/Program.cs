// Kullanıcıyı karşıla
// Kullanıcı giriş yapsın
// Kullanıcı adı admine, sifre 1234 e eşitse menü gösterilsin
// Kullanıcıyı uygulama hakkında ufak bir bilgilendirme ver
// RPE ve RIR sistemi hakkında bilgi ver 
// İdmanlar için haraketleri belirle
//
void Selamla()
{
    Console.WriteLine("Kendini İnşa Et uygulamasına hoş geldin. ");
}


void KullanıcıGirisi()
{

    try
    {
        Console.WriteLine("Kullanıcı Adı:");
        string kullanıcıAd = Console.ReadLine();
        Console.WriteLine("Sifre: ");
        string kullanıcıSifre = Console.ReadLine();
        // Karar Yapısı
        if (kullanıcıAd == "admin")
        {
            

            if (kullanıcıSifre == "1234")
            {

            }
            void IdmanMenu()
            {
                string[] Idmanlar = { "1- UpperLower", "2- FullBody", "3- PushPullLegs" };
                for (int i = 0; i < Idmanlar.Length; i++)
                {
                    Console.WriteLine(Idmanlar[i]);
                }
                foreach (string t in TekrarSayıları())
                {
                    Console.WriteLine(t);
                }

                Console.WriteLine("İdman modeli seçiniz: " + " ");
                int gelenSecim = int.Parse(Console.ReadLine());
                if (gelenSecim == 1)
                {
                    Console.WriteLine($"Seçilen idman modeli{Idmanlar[gelenSecim - 1]}" + " ");
                    Console.WriteLine("Upper Lower: Bu model haftada 4 gün 2 gün üst vücut 2 gün alt vücut olmak üzere tasarlanmıştır.\n Amaç hem güçlenmek hem kas kazanmak.");
                    foreach (string s in UpLowİdmanlar())
                    {
                        Console.WriteLine(s);
                    }
                    foreach (string t in TekrarSayıları())
                    {
                        Console.WriteLine(t);
                    }
                    foreach (string r in RpeSistemi())
                    {
                        Console.WriteLine(r);
                    }

                }
                else if (gelenSecim == 2)
                {
                    Console.WriteLine($"Seçilen idman modeli{Idmanlar[gelenSecim - 1]}" + " ");
                    Console.WriteLine("FullBody: Bu model haftada 3 gün olarak yapılması tavsiye edilir. \n Ancak vakti olmayanlar için 2 gün veya 1 gün olarak da yapılabilir.");
                    foreach(string f in FullBodyHaraketler())
                        { Console.WriteLine(f); }
                    foreach(string r in RpeSistemi())
                    { Console.WriteLine(r); }
                    foreach (string t in TekrarSayıları())
                    {
                        Console.WriteLine(t);
                    }
                }
                else if (gelenSecim == 3)
                {
                    Console.WriteLine($"Seçilen idman modeli{Idmanlar[gelenSecim - 1]}" + " ");
                    Console.WriteLine("PushPullLegs: Bu model diğer modellere göre daha izole haraketler içerir haftanın 6 günü yapılır.\n Çok iyi programlanmalı aksi halde fazla kas hasarından gelişim sekteye uğrayabilir.");
                }
                



                else
                {
                    Console.WriteLine($"Lütfen 1 ile {Idmanlar.Length} aralığında değer girin");
                }
            }
            IdmanMenu();
        }            
    else
    {
        Console.WriteLine("Kullanıcı adı ya da sifre hatalı");
    }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

string[] RpeSistemi()
{
    string[] Rpe = { "RPE Sistemi: Harakette ne kadar zorlandığını gösterem parametre 10/10 bir tekrar daha yapamayacağın,\n 7/10 cepte 3 tekrar daha çıkaracak gücün olduğunu gösterir" };
    
    return Rpe;
    
}


string[] UpLowİdmanlar()
{
    string[] Haraketler = {"Dips","Pullup","Squat","Deadlift"};
    return Haraketler;
}
string[] TekrarSayıları()
{
    string[] Tekrarlar = { "Dips, Pullup,Squat, Deadlift,BenchPress gibi birden fazla eklemin haraket ettiği bileşik egzersizlerde, güçlenme fazında tekrar sayıları 4-8 Rpe 7-8 olarak yapılacak" };
    return Tekrarlar;
}
// To do!! ** full body haraketleri belirle
string[] FullBodyHaraketler()
{
    string[] Haraketler = { "Squat", "Bench Press", "LatPullDown", "LegCurl" };
    return Haraketler;
}



// Metod Kullanımı
Selamla();
KullanıcıGirisi();
RpeSistemi();
TekrarSayıları();
UpLowİdmanlar();



