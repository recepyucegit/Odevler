using MVC_CodeFirst.Context;
using MVC_CodeFirst.Models.Entities;
using MVC_CodeFirst.Models.Enums;
using MVC_CodeFirst.Models.ViewModels;
using MVC_CodeFirst.Repositories.Abstracts;
using MVC_CodeFirst.Services.Abstracts;

namespace MVC_CodeFirst.Services.Concretes
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MessageStatus CreateMovie(MovieCreateViewModel createViewModel)
        {
            try
            {
                Movie movie = new Movie
                {
                    Title = createViewModel.Title,
                    Description = createViewModel.Description,
                };

                _movieRepository.Create(movie);
                return MessageStatus.Success;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return MessageStatus.Error;
            }
        }

        public List<MovieListViewModel> GetMovies()
        {
            var movieListModel = _movieRepository.GetAll().Select(x => new MovieListViewModel
            {
                ID = x.ID,
                Title = x.Title,
                Description = x.Description,
            }).ToList();

            return movieListModel;
        }
    }
}
