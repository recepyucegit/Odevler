
#region Faz 1
//Kullanıcıdan bir değer alın. Alınan değer
//domates, biber, patlıcan ise "Manav reyonumuz zemin kattadır"
//telefon, tablet, bilgisayar ise "Teknoloji reyonumuz 1. kattadır"
//tshirt, pantolon, gömlek ise "Giyim reyonumuz 2. kattadır"
//bunların haricinde bir değer gelirse "böyle bir reyonumuz bulunmamaktadır"
//uyarısını console'da kullanıcıya gösterin. 
#endregion

//string gelenDeger = "";
//Console.WriteLine("değer girin: ");
//gelenDeger = Console.ReadLine();
//if (gelenDeger == "domates" || gelenDeger == "biber" || gelenDeger == "patlıcan")
//{
//    Console.WriteLine("Manav reyonumuz zemin kattadır.");
//}
//else if (gelenDeger == "telefon" || gelenDeger == "tablet" || gelenDeger == "bilgisauar")
//{
//    Console.WriteLine("Teknoloji reyonumuz 1. kattadır");
//}
//else if (gelenDeger == "tshirt" || gelenDeger == "pantolon" || gelenDeger == "gömlek")
//{
//    Console.WriteLine("Giyim reyonumuz 2. kattadır");
//}
//else
//{
//    Console.WriteLine("böyle bir reyonumuz bulunmamaktadır");
//}

#region Faz 2
//Kulllanıcıya bakiye tanımlayın 1000 TL
//1-Domates 30 TL
//2-biber 25 TL
//3-patlıcan 50 TL
//seçim: 2


//1-telefon 1000 TL
//2-tablet 2000 TL
//3-bilgisayar 10000 TL
//seçim: 3
//bakiyeniz yetersiz!!!

//1-tshirt 100 TL
//2-pantolon 200 TL
//3-gömlek 150 TL
//seçim: 2 
#endregion



decimal bakiye = 1000;
string gelenDeger = "";
Console.WriteLine("değer girin: ");
gelenDeger = Console.ReadLine();
if (gelenDeger == "domates" || gelenDeger == "biber" || gelenDeger == "patlıcan")
{
    Console.WriteLine("Manav reyonumuz zemin kattadır.");
    Console.WriteLine("1-Domates 30TL");
    Console.WriteLine("2-Biber 25TL");
    Console.WriteLine("3-Patlıcan 50TL");
    Console.WriteLine("seçim: ");
    string secim = Console.ReadLine();

    if (secim == "1")
    {
        bakiye = bakiye - 30;
        Console.WriteLine("Domates sepete eklendi. Güncel bakiyeniz: " + bakiye);
    }
    else if (secim == "2")
    {
        bakiye = bakiye - 25;
        Console.WriteLine("biber sepete eklendi. Güncel bakiyeniz: " + bakiye);
    }
    else if (secim == "3")
    {
        bakiye = bakiye - 50;
        Console.WriteLine("Patlıcan sepete eklendi. Güncel bakiyeniz: " + bakiye);
    }
    else
    {
        Console.WriteLine("geçersiz seçim");
    }

}
else if (gelenDeger == "telefon" || gelenDeger == "tablet" || gelenDeger == "bilgisayar")
{
    //todo: işlemler gerçekleştirilecek
    Console.WriteLine("Teknoloji reyonumuz 1. kattadır");
    Console.WriteLine("1-Telefon 1000TL");
    Console.WriteLine("2-Tablet 2000TL");
    Console.WriteLine("3-Bilgisayar 10000TL");
    Console.WriteLine("seçim: ");
    string secim = Console.ReadLine();

    if (secim == "1")
    {


        bakiye = bakiye - 1000;
        Console.WriteLine("telefon sepete eklendi. Güncel bakiyeniz: " + bakiye);


    }
    else if (secim == "2")
    {


        bakiye = bakiye - 2000;
        Console.WriteLine("tablet sepete eklendi. Güncel bakiyeniz: " + bakiye);

    }
    else if (secim == "3")
    {


        bakiye = bakiye - 10000;
        Console.WriteLine("bilgisayar sepete eklendi. Güncel bakiyeniz: " + bakiye);

    }
    else
    {
        Console.WriteLine("geçersiz seçim");
    }

}
else if (gelenDeger == "tshirt" || gelenDeger == "pantolon" || gelenDeger == "gömlek")
{
    //todo: işlemler gerçekleştirilecek
    Console.WriteLine("Giyim reyonumuz 2. kattadır");
    Console.WriteLine("1-Tshirt 100TL");
    Console.WriteLine("2-Pantolon 200TL");
    Console.WriteLine("3-Gömlek 150TL");
    Console.WriteLine("seçim: ");
    string secim = Console.ReadLine();

    if (secim == "1")
    {


        bakiye = bakiye - 100;
        Console.WriteLine("tshirt sepete eklendi. Güncel bakiyeniz: " + bakiye);

    }
    else if (secim == "2")
    {


        bakiye = bakiye - 200;
        Console.WriteLine("pantolon sepete eklendi. Güncel bakiyeniz: " + bakiye);


    }
    else if (secim == "3")
    {


        bakiye = bakiye - 150;
        Console.WriteLine("gomlek sepete eklendi. Güncel bakiyeniz: " + bakiye);

    }
    else
    {
        Console.WriteLine("geçersiz seçim");
    } 
    else
    {
        Console.WriteLine("böyle bir reyonumuz bulunmamaktadır");
    }
}






else if (gelenDeger == "barbut" || gelenDeger == "101" || gelenDeger == "tavla")

{
    Console.WriteLine("1- Barbut ");
    Console.WriteLine("2- 101");
    Console.WriteLine("3- Tavla");
    string secim = Console.ReadLine();


    string Barbut = "Barbut";
    string oyuncuBir = "";
    string oyuncuIki = "";
    int zar1 = 0;
    int zar2 = 0;
    Random rnd = new Random();

    Console.WriteLine("1. oyuncu ad: ");
    oyuncuBir = Console.ReadLine();

    Console.WriteLine("2. oyuncu ad: ");
    oyuncuIki = Console.ReadLine();

    Console.WriteLine(oyuncuBir + " zar atması bekleniyor...");
    Console.ReadLine();
    zar1 = rnd.Next(1, 7);
    Console.WriteLine(oyuncuBir + " attığı zar" + " " + zar1);

    Console.WriteLine(oyuncuIki + " zar atması bekleniyor...");
    Console.ReadLine();
    zar2 = rnd.Next(1, 7);
    Console.WriteLine(oyuncuIki + " attığı zar" + " " + zar2);

    //Kazanma durumu
    if (zar1 == zar2)
    {
        Console.WriteLine("Oyun berabere!");
    }
    else if (zar1 < zar2)
    {
        Console.WriteLine(oyuncuIki + " kazandı!");
    }
    else if (zar1 > zar2)
    {
        Console.WriteLine(oyuncuBir + " kazandı!");

        Console.WriteLine("Oyun salonumuz 3. kattadır");



        if (secim == "1")
        {
            Console.WriteLine("Seçiminiz Barbut, başlatılıyor..." + Barbut);

        }
        else if (secim == "2")

        {
            Console.WriteLine("Seçiminiz 101 , başlatılıyor...");

        }
        else if (secim == "3")
        {
            Console.WriteLine("seçiminiz Tavla, başlatılıyor");

        }
        else
        {
            Console.WriteLine("Geçersiz seçim");

        }
    }

    else
    {
        Console.WriteLine("böyle bir reyonumuz bulunmamaktadır");
    }
}
