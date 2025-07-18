using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_KahveSiparisOdevOrtak.Abstracts
{
    internal  interface IKahveSiparis
    {
        public void Hoşgeldiniz();
        public void MenuOlustur(KahveBilgi kahveBilgi);

        public void MenuGoster();

        public void kullaniciGiris();
    }
}
