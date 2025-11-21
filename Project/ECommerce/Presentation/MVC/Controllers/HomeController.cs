using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using DAL.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.CartModel;
using MVC.Models.ViewModels;
using MVC.Utils;
using System.Diagnostics;
using System.Web;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryServiceManager _categoryService;
        private readonly IProductServiceManager _productServiceManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IOrderServiceManager _orderServiceManager;
        private readonly IOrderDetailServiceManager _orderDetailServiceManager;
        private readonly IConfiguration configuration;
        private readonly IShipperServiceManager _shipperServiceManager;

        public HomeController(
            ILogger<HomeController> logger,
            ICategoryServiceManager categoryService,
            IProductServiceManager productServiceManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IOrderServiceManager orderServiceManager,
            IOrderDetailServiceManager orderDetailServiceManager,
            IConfiguration configuration,
            IShipperServiceManager shipperServiceManager

            )


        {
            _logger = logger;
            _categoryService = categoryService;
            _productServiceManager = productServiceManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _orderServiceManager = orderServiceManager;
            _orderDetailServiceManager = orderDetailServiceManager;
            this.configuration = configuration;
            _shipperServiceManager = shipperServiceManager;

        }

        public IActionResult Index()
        {

            ViewBag.Categories = _categoryService.GetActives();
            var products = _productServiceManager.GetActives().OrderByDescending(x => x.ID).Take(10).ToList();
            return View(products);
        }


        public IActionResult AddToCart(int id)
        {

            Product product = _productServiceManager.FindById(id);

            if (product == null)
            {
                TempData["Error"] = "böyle bir ürün bulunamadı!";
                return RedirectToAction("Index");
            }
            else
            {
                //Session içerisinde bulunan AddItem için Cart nesnesi oluşturuldu.
                Cart cart = new Cart();
                cart.Id = product.ID;
                cart.ProductName = product.ProductName;
                cart.UnitPrice = product.Price;




                CartItem cartItem; //null   
                                   //server'da "sepet_session" isminde bir session oluşturulmuş mu? eğer oluşturulmuş ise GetProductFromJsom<T> metodu kullanıma alınarak cartItem doldurulacak.

                if (SessionHelper.GetProductFromJson<CartItem>(HttpContext.Session, "sepet_session") == null)
                {
                    //ilk kez ürün eklemek istediğinde tetiklenir.
                    cartItem = new CartItem();
                }
                else
                {
                    //session içerisinde sepet_session bulunmakta.
                    cartItem = SessionHelper.GetProductFromJson<CartItem>(HttpContext.Session, "sepet_session");
                }

                cartItem.AddItem(cart);

                //oluşturulan cartItem session'a eklenecek.
                SessionHelper.SetJsonProduct(HttpContext.Session, "sepet_session", cartItem);



                TempData["Success"] = "Ürün sepete eklendi!";

                return RedirectToAction("Index");
            }
        }

        public IActionResult MyCart()
        {
            var cart = SessionHelper.GetProductFromJson<CartItem>(HttpContext.Session, "sepet_session");
            if (cart == null)
            {
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        //Login Action
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            // E-posta ile kullanıcıyı bul
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı!");
                return View(loginVM);
            }

            // Kullanıcı adı ile giriş yap
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (result.Succeeded)
            {
                TempData["success"] = "Giriş başarılı!";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış!");
                return View(loginVM);
            }
        }


        //Register Action
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı kayıt işlemleri

                var existingUser = await _userManager.FindByNameAsync(registerVM.Username);

                var existingEmail = await _userManager.FindByEmailAsync(registerVM.Email);
                if (existingEmail != null)
                {
                    TempData["error"] = "Bu email zaten kayıtlı!";
                    return RedirectToAction("Login");
                }


                if (existingUser == null)
                {

                    IdentityUser identityUser = new IdentityUser()
                    {
                        UserName = registerVM.Username,
                        Email = registerVM.Email,
                    };

                    var result = await _userManager.CreateAsync(identityUser, registerVM.Password);

                    if (result.Succeeded)
                    {

                        //yeni kaydolan kullanıcın rolu "user" olması gerekmektedir.

                        //ilk olarak veritabanında user isminde bir rol var mı kontrol edilecek eğer varsa yeni kaydolan kullanıcının rolu user olacak.

                        var exitsUserRole = await _roleManager.GetRoleNameAsync(new IdentityRole { Name = "user" });

                        if (exitsUserRole != null)
                        {
                            _userManager.AddToRoleAsync(identityUser, "user");
                        }
                        else
                        {
                          var resultRole =  await _roleManager.CreateAsync(new IdentityRole() { Name = "user" });
                            if (resultRole.Succeeded)
                            {
                                _userManager.AddToRoleAsync(identityUser, "user");
                            }

                        }






                        var emailValidationToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);

                        var encodeToken = HttpUtility.UrlEncode(emailValidationToken);

                        string confirmationLink = Url.Action("ConfirmEmail", "Home", new
                        {
                            userId = identityUser.Id,
                            token = encodeToken
                        }, Request.Scheme);


                        string body = $"<h1>Hesabınızı onaylamak için lütfen aşağıdaki linke tıklayınız.</h1>" +
                            $"<a href='{confirmationLink}' target='_blank'>Hesabımı Onayla</a>";


                        EmailSender emailSender = new EmailSender(configuration["EmailSettings:MailAddress"],
                           configuration["EmailSettings:Password"],
                            configuration["EmailSettings:Smtp"],
                          configuration["EmailSettings:Port"]
                            );


                        emailSender.SendEmail(registerVM.Email, "Hesabınızı Onaylayın", body);



                        TempData["success"] = "Kayıt işlemi başarılı! Eposta kutunuzu kontrol edin.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(registerVM);
                    }


                }
                TempData["error"] = "Bu kullanıcı adı zaten kayıtlı!";

                return RedirectToAction("Login");
            }
            return View(registerVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        // Alışverişi tamamla" butonu tıklandığında sepetteli ürünlere ait bir "Order" oluşturulması gerekmetekdir.
        // HomeController.cs içine eklenecek metodlar

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(int shipperId)
        {
            // Kullanıcı giriş yapmış mı kontrol et
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "Sipariş vermek için giriş yapmanız gerekmektedir.";
                return RedirectToAction("Login");
            }

            // Sepeti kontrol et
            var cart = SessionHelper.GetProductFromJson<CartItem>(HttpContext.Session, "sepet_session");
            if (cart == null || cart._myCart.Count == 0)
            {
                TempData["Error"] = "Sepetiniz boş, sipariş oluşturulamadı.";
                return RedirectToAction("Index");
            }

            // Kargo firmasını kontrol et
            var shipper = _shipperServiceManager.FindById(shipperId);
            if (shipper == null)
            {
                TempData["Error"] = "Geçersiz kargo firması seçimi.";
                return RedirectToAction("MyCart");
            }

            try
            {
                // Kullanıcı ID'sini al
                var user = await _userManager.GetUserAsync(User);

                // Order oluştur - ShipperId direkt atanıyor
                var order = new Order
                {
                    UserId = user.Id,
                    OrderDate = DateTime.Now,
                    ShipperId = shipperId // Kullanıcının seçtiği kargo
                };

                // Order'ı veritabanına kaydet
                await _orderServiceManager.CreateAsync(order);

                // En son oluşturulan order'ı al
                var latestOrder = _orderServiceManager.GetAll()
                    .Where(o => o.UserId == user.Id)
                    .OrderByDescending(o => o.CreatedDate)
                    .FirstOrDefault();

                if (latestOrder == null)
                {
                    TempData["Error"] = "Sipariş oluşturulurken hata oluştu.";
                    return RedirectToAction("MyCart");
                }

                // OrderDetail'leri oluştur
                foreach (var cartItem in cart._myCart.Values)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = latestOrder.ID,
                        ProductId = cartItem.Id,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.UnitPrice ?? 0
                    };
                    await _orderDetailServiceManager.CreateAsync(orderDetail);
                }

                // Sepeti temizle
                HttpContext.Session.Remove("sepet_session");

                // Sipariş numarasını TempData'ya kaydet
                TempData["OrderId"] = latestOrder.ID;
                TempData["Success"] = $"Siparişiniz başarıyla oluşturuldu! Sipariş No: #{latestOrder.ID}. Kargo: {shipper.ShipperName}";

                // Pending sayfasına yönlendir
                return RedirectToAction("Pending", new { orderId = latestOrder.ID });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sipariş oluşturulurken bir hata oluştu: " + ex.Message;
                return RedirectToAction("MyCart");
            }
        }


        //Oluşturulan Order OrderDetails tablosuna eklenecek.Kullanıcı yeni bir sayfaya yönlendirilecek. (Home/Pending)

        //Pending sayfasında oluşturulan sipariş numarası kullanıcıya gösterilecek.Sipariş Kargoya verildiğinde bu sayfada kargo gösterilecek.
        public async Task<IActionResult> Pending(int orderId)
        {
            try
            {
                var order = _orderServiceManager.FindById(orderId);

                if (order == null)
                {
                    TempData["Error"] = "Sipariş bulunamadı.";
                    return RedirectToAction("Index");
                }

                var user = await _userManager.GetUserAsync(User);
                if (order.UserId != user?.Id)
                {
                    TempData["Error"] = "Bu siparişe erişim yetkiniz bulunmamaktadır.";
                    return RedirectToAction("Index");
                }

                // Shipper bilgisini yükle
                if (order.ShipperId.HasValue)
                {
                    order.Shipper = _shipperServiceManager.FindById(order.ShipperId.Value);
                }

                ViewBag.OrderId = order.ID;
                ViewBag.OrderDate = order.OrderDate;
                ViewBag.ShipperName = order.Shipper?.ShipperName; // ShipperName yerine Shipper?.ShipperName
                ViewBag.OrderStatus = order.ShipperId == null ? "Hazırlanıyor" : "Kargoya Verildi";

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Sipariş bilgileri alınırken hata oluştu: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Success"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("Index", "Home");
        }
        // HomeController.cs'e bu metodu ekleyin:

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Error"] = "Giriş yapmanız gerekmektedir.";
                return RedirectToAction("Login");
            }

            // Kullanıcının siparişlerini getir
            var orders = _orderServiceManager.GetAll()
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.CreatedDate)
                .ToList();

            // Her order için shipper bilgisini yükle
            foreach (var order in orders)
            {
                if (order.ShipperId.HasValue)
                {
                    order.Shipper = _shipperServiceManager.FindById(order.ShipperId.Value);
                }
            }

            return View(orders);
        }

        //Denied adında bir action mettot oluştur.
        public IActionResult Denied()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _productServiceManager.GetProductsWithCategory().FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                TempData["Error"] = "Böyle bir ürün bulunamadı!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult GetProductWithCategory(int id)
        {
            var products = _productServiceManager.GetProductsWithCategory().Where(x => x.CategoryId == id).ToList();

            ViewBag.Category = _categoryService.FindById(id)?.CategoryName ?? "Kategori Bulunamadı";
            return View(products);
        }


    }







}
