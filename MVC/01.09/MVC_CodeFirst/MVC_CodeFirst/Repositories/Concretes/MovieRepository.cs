using MVC_CodeFirst.Context;
using MVC_CodeFirst.Models.Entities;
using MVC_CodeFirst.Repositories.Abstracts;

namespace MVC_CodeFirst.Repositories.Concretes
{
    public class MovieRepository : IMovieRepository
    {

        MovieContext _context = new MovieContext();
        public void Create(Movie movie)
        {
            _context.Movies.Add(movie); 
            _context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }
    }
}
