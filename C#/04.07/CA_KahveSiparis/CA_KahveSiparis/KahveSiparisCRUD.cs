using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_KahveSiparis
{
    internal class KahveSiparisCRUD
    {

        //Create

        public void CreateKahve (KahveBilgi kahveBilgi)
        {
            KahveData.productList.Add (kahveBilgi);
        }

        //READ

      public void KullanıcıGiris()
        {

        }

        public void GetAllProducts()
        {
            foreach (KahveBilgi kahve in KahveData.productList)
            {
                Console.WriteLine(kahve.KahveIsim+" "+ kahve.KahveFiyat);
                
            }
        }
        // UPDATE
        public void UpdateCoffe(KahveBilgi updated)

        {
            foreach (KahveBilgi k in KahveData.productList)
            {
                if(updated.Id== k.Id)
                {
                    k.KahveFiyat = updated.KahveFiyat;
                    k.KahveIsim = updated.KahveIsim;
                    break;
                }
                
                
            }
            

        }
        public void DeleteCoffe(int id)
        {
            foreach(KahveBilgi k in KahveData.productList)
            {
                if(id==k.Id)
                {
                    KahveData.productList.Remove(k);
                    break;

                }
            }
        }
            
    }
}
