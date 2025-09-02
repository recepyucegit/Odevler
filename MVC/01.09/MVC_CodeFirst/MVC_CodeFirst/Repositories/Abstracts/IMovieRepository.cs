using MVC_CodeFirst.Models.Entities;

namespace MVC_CodeFirst.Repositories.Abstracts
{
    public interface IMovieRepository
    {

        //Create
        void Create(Movie movie); 
        List<Movie> GetAll();

    }
}
