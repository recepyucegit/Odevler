//1. Oyuncu için bir ad alın.
//2. Oyuncu için ad alın.

//1. oyuncunun zarını oluşturun ?????
//2. oyuncunun zarını oluşturun ?????

//1. oyuncu zar atar
//2. oyuncu zar atar

//sonuç belirlenir.
//console'a yazılır.


string kurbanBir = "";
string kurbanIKi = "";
int zar1 = 0;
int zar2 = 0;   
Random rnd= new Random();

Console.WriteLine("1.Kurbanın Adı: ");
kurbanBir = Console.ReadLine();

Console.WriteLine("2. Kurbanın Adı: ");
kurbanIKi= Console.ReadLine();

Console.WriteLine(kurbanBir+"Birinci Kurbanın zar atması bekleniyor...");
Console.ReadLine();
zar1 = rnd.Next(1, 7);
Console.WriteLine(kurbanBir + "Attığı zar" + "" + zar1);

Console.WriteLine(kurbanIKi + "İkinci Kurbanın zar atması bekleniyor... ");
Console.ReadLine();     
zar2=rnd.Next(1, 7);
Console.WriteLine(kurbanIKi+"Attığı zar"+""+zar2);

//Kazanan 
if(zar1 == zar2)
{
    Console.WriteLine("Oyun berabere!");
}
else if (zar2 < zar1)
{
    Console.WriteLine(kurbanBir + " kazandı");

}
else if (zar2 > zar1)
{
    Console.WriteLine(kurbanIKi+"kazandı");
}
