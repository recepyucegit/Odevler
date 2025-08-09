/*
* Abstract Factory Pattern uygulamak için öncelikle nesnelerin interface içindeki eyllem ve özelliklerini tanımladık. 
* Daha sonra bu bellirlediğimiz interfaceleri ortak bir abstract interface (IAbstractCreateCharacter) create metodu içinde topladık.
* Bunun sebebi de concretefactory oluştururken her bir interfaceden miras almak yerine tek bir abstract interface üzerinden ortak özellik ve metotları miras aldık.
* Daha sonrasında concretes adında bir klasör oluşturup bu klasörün içine önceden belirlediğimiz interfaceleri implement ettik.
* Sorasında concretefactory oluşturduk. Bu factory bizim için oluşturduğımuz interfaceleri metotlar aracılığıyla somutlaştırdık.
* Concretefactory metotlar içinde bizim için instance alarak soyut nesneleri somut hale getirdi.
* Daha sonra AbstractFactory oluşturduk. Bu factory, özünde soyut olan interfaceleri concretefatory aracılığyla instacelerini alarak tanımladığımız nesneleri oluşturur. 
* AbstractFactory'nin çalışabilmesi için özü IAbstractCreateCharacter olan bir constructor oluşturduk. Bunu da geriye IAbstractCreateCharacter döndüren bir encapsulation uyguladık.
* Encapsulation'dan sonra da bir generate metodu oluşturduk. Bu generate mtodu bizim için concretefactory'nin içine gitmemizi sağlıyor(_characterFactory). Bu sayede oluşturudğumuz interfacelerin create metotlarına ulaşıp bizim için oluştıurdğumuz nesnelerin içine aktarıyor. 
* Sonrasında abstract'ta belirlediğimiz metotları çağırabiliyoruz.
* Özü IAbstractCreateCharacter olan concreteFActory'den bir instance alıyoruz. Daha sonra bu instance ile abstractCharFactory'ye bir parametre göndermiş oluyoruz. Bu parametreyi var içinde tutacağımız abstractCharFactory'den bir instance alıyoruz. ConcreteFactory'den aldğıımız instance abstaractCharFactory'den aldığımz instancenin parametresine gönderiliyor. Bu sayede generate metorduna erişebiliyoruz.
*/