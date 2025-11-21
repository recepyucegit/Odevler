# NTier Mimari Projesi

## Genel Bakış

Bu proje, .NET 7 ile geliştirilmiş çok katmanlı (NTier) bir uygulamadır. NTier mimarisi, uygulamanın farklı sorumluluklara sahip katmanlara ayrılmasını sağlar. Genellikle Presentation (Sunum), Business (İş) ve Data Access (Veri Erişim) katmanlarından oluşur.

## Katmanlar

### 1. Presentation (Sunum) Katmanı
Kullanıcı arayüzünü ve kullanıcıdan gelen taleplerin alınmasını sağlar. Genellikle ASP.NET Core MVC veya Blazor gibi teknolojilerle geliştirilir.

### 2. Business (İş) Katmanı
İş kurallarının ve uygulama mantığının bulunduğu katmandır. Sunum katmanından gelen talepleri işler ve veri erişim katmanına yönlendirir.

### 3. Data Access (Veri Erişim) Katmanı
Veritabanı işlemlerinin gerçekleştirildiği katmandır. Entity Framework Core gibi ORM araçları ile veri okuma/yazma işlemleri yapılır.



ProjeKökKlasörü/
│
├── DAL/                        # Data Access Layer
│   ├── IRepository.cs          # Veri erişim arayüzü
│   ├── Repository.cs           # Veri erişim sınıfı
│   ├── DbContext.cs            # Veritabanı bağlamı
│   └── Entity/                 # Varlıklar
│       ├── User.cs
│       └── Product.cs
│
├── BLL/                        # Business Logic Layer
│   ├── IUserService.cs         # İş servisi arayüzü
│   ├── UserManager.cs          # İş servisi sınıfı
│   ├── IProductService.cs
│   └── ProductManager.cs
│
├── IOC/                        # Inversion of Control
│   ├── IContainer.cs           # IoC arayüzü
│   ├── Container.cs            # IoC sınıfı
│   └── DependencyResolver.cs   # Bağımlılık çözümleyici
│
└── MVC/                        # Sunum Katmanı (ASP.NET Core MVC)
    ├── Controllers/
    │   ├── HomeController.cs
    │   └── ProductController.cs
    ├── Models/
    │   ├── UserViewModel.cs
    │   └── ProductViewModel.cs
    ├── Views/
    │   ├── Home/
    │   │   └── Index.cshtml
    │   └── Product/
    │       └── List.cshtml
    └── Program.cs              # Uygulama giriş noktası

## Özellikler

- .NET 7 desteği
- Katmanlı mimari (Sunum, İş, Veri Erişim)
- Kolay API entegrasyonu
- Modern ve duyarlı kullanıcı arayüzü

## Kurulum

### Gereksinimler

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Adımlar

1. Depoyu klonlayın:
2. Proje klasörüne geçin:
3. Bağımlılıkları yükleyin:
## Çalıştırma
Tarayıcınızda `https://localhost:5001` adresini açarak uygulamayı görüntüleyebilirsiniz.

## Proje Yapısı
## Katkı

Katkıda bulunmak isterseniz, lütfen issue açın veya pull request gönderin.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır.
