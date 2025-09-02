#Repository Pattern:
bir takım işlemleri doğrudan veritabanı ile haberleştiren bir tasarımdır. Bu tasarım içerisinde Modeller aslında entity'leri temsil eder. Bu entityler ilgili tablo olarak geri dönerler. Özünde CRUD işlemleri bu tasarım içerisinde gerçekleştirilir.

#Service Pattern: 
Repository'e bir takım istekleri ileten tasarım desenidr. Bu desen aslında doğrudan kullanıcı ile iletişim halinde olur. Kullanıcının taleplerini alarak Repository'e iletir. Repository'dne dönen modelleri Client'a gönderir.


#Dependency Injection
Program.cs içerisinde ara katmanda (Middleware) proje dahilinde kullanılacak servisler barındırılır. Daha sonra bu barındıralan servisler ilgili classlar ya da controller'lar içerisinden doğrudan işleme alınırlar. Bu işleme Bağımlılığın dahil edilmesi (Dependency Injection) olarak adlandırırız.

#ViewModel
 Uygulama içerisinde kullanıcıların (Client) taleplerine karşılık gelen ve veritabanında tablo haline gelmiş entity'ler taşıyıcılarını barındırır. Böylelikle kullanıcı veritabanında bulunan entity'lerin bütün özelliklerini değil sadece ihtiyaç duyduğu özellikleri bu taşıyı model üzerinden ulaşır.

#Partial
 sabit olan bir tasarım içerisinde dinamik olarak dahil edilen görüntüleyicleri temsil eder. Yani daha önce oluşturulmuş olunan bir html kodunu farklı farklı sayfalarda kullanıma alır. Böylelikle tekrar tekrar oluşturmak zorunda kalmayız.

 #Area
 MVC patterni sadece ziyaretçilerin kullanacağı bir pattern yerine proje içerisinde farklı farklı kullanıcı gruplarının kullanacağı bir yapı haline dönüştürmek için "Alan" (Area) ihtiyacımız bulunmaktadır. Böylelikle her bir departman kendine ait ayrı bir MVC ile tek proje içerisinde bütün işlemleri gerçekleştirebilirler. Özünde sorumlulukların ayrılması prensibine dayanmaktadır.