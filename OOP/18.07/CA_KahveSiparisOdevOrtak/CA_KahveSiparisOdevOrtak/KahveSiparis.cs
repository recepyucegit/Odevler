using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_KahveSiparisOdevOrtak
{
    internal class KahveSiparis
    {
        KahveSiparisCRUD kahveSiparisCRUD = new KahveSiparisCRUD();
        public void KahveMenuOlustur()
        {
            KahveBilgi kahveBilgi = new KahveBilgi();
            kahveBilgi.KahveId = 1;
            kahveBilgi.KahveAd = "Espresso";
            kahveBilgi.KahveFiyat = 150.00m;
            kahveSiparisCRUD.MenuOlustur(kahveBilgi);
            kahveBilgi = new KahveBilgi();
            kahveBilgi.KahveId = 2;
            kahveBilgi.KahveAd = "Latte";
            kahveBilgi.KahveFiyat = 120.00m;
            kahveSiparisCRUD.MenuOlustur(kahveBilgi);
            kahveBilgi = new KahveBilgi();
            kahveBilgi.KahveId = 3;
            kahveBilgi.KahveAd = "Filtre";
            kahveBilgi.KahveFiyat = 120.00m;
            kahveSiparisCRUD.MenuOlustur(kahveBilgi);
        }
      public void KahveMenuGoster()
        {
            Console.WriteLine("Kahve Menüsü:");
            kahveSiparisCRUD.MenuGoster();
        }
    }
}
