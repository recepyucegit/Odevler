//Main
using Bogus;
using DAL.Entities.Concretes;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        //IRepository<Category> categoryBaseRepository = new BaseRepository<Category>(new DAL.Context.ProjectContext());

        //foreach (var item in categoryBaseRepository.GetAll())
        //{
        //    if (item.Status == DAL.Entities.Enums.DataStatus.Inactive)
        //    {
        //        Console.WriteLine("Aktif Data: " + item.CategoryName);
        //    }

        //    else if (item.Status == DAL.Entities.Enums.DataStatus.Active)
        //    {
        //        Console.WriteLine("İnaktif Data: " + item.CategoryName);
        //    }
        //}

        // var categories = GetFakeCategories();

        Console.WriteLine(GetHostName());
        
    }


    public static List<Category> GetFakeCategories()
    {
        List<Category> categories = new List<Category>();

        var faker = new Faker();

        for (int i = 0; i < 10; i++)
        {

            Category category = new Category
            {
                ID = i + 1,
                CategoryName = faker.Commerce.Categories(1)[0],
                Description = faker.Lorem.Word()

            };

            categories.Add(category);

        }


        return categories;



    }

    public static string GetHostName()
    {
        string ip = "";

        var hostName = Dns.GetHostName();

        var ipAddresses = Dns.GetHostAddresses(hostName);

        foreach (var item in ipAddresses)
        {
            if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ip=item.ToString();
                break;
            }
        }

        return ip;
    }
}