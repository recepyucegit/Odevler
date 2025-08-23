using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;

namespace MVC_Intro.Controllers
{
    public class HomeController : Controller
    {
        #region Test istekleri
        //// Index
        //public string  Index()
        //{
        //    return "Anasayfa";

        //    //aslında olması gereken Index isimli bu metoda istek geldiğinde ilgili sayfanın gösterilmesidir.
        //}

        //// About
        //public string About()
        //{
        //    return "Hakkımızda";
        //}

        //// Contact
        //public string Contact()
        //{
        //    return "İletişim";
        //} 
        #endregion

        //İletişim Listesi
        public static List<Iletisim> contactList = new List<Iletisim>();

        //Index Sayfası Aksiyon

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //About Sayfası Aksiyon
        public IActionResult About()
        {
            return View();
        }

        //Contact Sayfası Aksiyon
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        //ilgili sayfadan herhangi bir bilgiyi yakalamak istediğimiz o sayfanın [HttpPost] action'nı oluşturmamız gerekmektedir.

        [HttpPost]
        public IActionResult Contact(string ad, string email, string mesaj)
        {
            Iletisim contact = new Iletisim
            {
                Name = ad,
                Email = email,
                Message = mesaj,
            };

            contactList.Add(contact);


            return View();
        }
    }
}
