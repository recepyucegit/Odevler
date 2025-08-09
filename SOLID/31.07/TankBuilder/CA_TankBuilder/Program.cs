// Oluşturacağımız  nesneye ait bir Model sınıfı belirledik. Bu model sınıfı içinde nesneye ait özellikleri belirledik.
// Bu özellikleri BuilderPattarne uygun olacak şekilde bir interface(IPlaneBuilder) tanımladık.
// Bu interfacenin içinde de nesnelere ait build metotlarını tanımladık.
// Bu tanımladığmız metotları implement eden sınıflar (BF-109) oluşturduk.
// Bu metotların hepsini bir kerede çağırabilmek için bir Director sınıfı oluşturduk.
// Dİrector sınıfının içinde de nesneye ait build metotlarını çağırdık.
// Ek olarak Concrete klasörünün içindeki sınıflardan PlanModel'den sürekli instance almamak için ek olarak Singleton tasarım deseni uyguladık.
// Singeleton Patternde de PlaneModel sınıfına ait static bir concrete yapıcı metodu oluşturduk. Bunu yaparken de encapsulation uyguladık.
// PlaneModelin içinde ToString() metodu override ettik. Bunun sebebi de nesneye ait özellikleri ekrana yazdırabilmek için.