1- Candidate Interface: 
* Neden yazdık?
-- Adayların ortak özelliklerini (FirstName, LastName) olarak soyutladık.

Hangi SOLID prensiplerine uyuyor?
1- ISP : Sadece aday özelliklerini içeriyor. Gereksiz medotlar yok örneğin Hire(),  Email gibi.
2-LSP: Candidate sınıfı bu interface’i uygulayarak sorunsuzca kullanılabilir. (Yani ICandidate yerine Candidate koyarsan bozulmaz.)

 2. Candidate Sınıfı – Single Responsibility

 Neden yazdık?
* Adayı somut olarak temsil ediyor. Sadece veriyi tutuyor, işlem yapmaz.
Hangi SOLID prensiplerine uyuyor?
1- SRP: Sadece aday verisini tutuyor. İşlem yapmıyor.

3. IEmployee Interface: Interface Segregation

Neden yazdık?
Çalışanları tanımlayan soyut yapı.
Hangi SOLID prensiplerine uyuyor?
ISP: Sadece çalışan Temel bilgilerini içeriyor. Gereksiz şişirme yok.

4. Employee Sınıfı – SRP, LSP
Neden yazdık?
*Adaydan çalışana dönüştürme işlemi yapıyor.
*Email üretimi burada yapılıyor.
Hangi SOLID prensiplerine uyuyor?
1- SRP: 	Çalışanla ilgili her şey burada (email, ücret, departman) ama başka bir sınıfın işine karışmıyor.
2-LSP:IEmployee interface’i uygulandığı için her yerde Employee → IEmployee gibi kullanılabilir.

5. CandidateRepository – SRP, DIP

Neden yazdık?
*Adayları veri kaynağından getiren yapı (şu an sabit listeden ama veritabanına da geçilebilir).
SOLID Uyumu:
Prensip	
SRP	Sadece veriyi getirir. 
DIP	RecruitmentService, bu sınıfa değil, ICandidate’a bağlıdır. Verinin nereden geldiği önemli değildir.

6. DepartmentFactory – Open/Closed
Neden yazdık?
* Her departman için farklı maaş politikası var

SOLID Uyumu:
Prensip	
OCP	Yeni departman eklersen yeni bir case eklersin ama mevcut kodu değiştirmezsin (açık/genişletilebilir, kapalı/değiştirilemez).

7. RecruitmentService – SRP, DIP
Neden yazdık?
* İşe alım sürecini yöneten yapı. Veriyi alır, departmanlara göre işe alır.
SOLID Uyumu:
Prensip	
SRP	Sadece işe alım yapar. Aday getirmez, email oluşturmaz.
DIP	List<ICandidate> gibi soyutlamaya bağlı. Somut Candidate listesine bağımlı değil.

8. Program.cs (Presentation) – SRP
* SRP : Sadece kullanıcıya veriyi gösterir.