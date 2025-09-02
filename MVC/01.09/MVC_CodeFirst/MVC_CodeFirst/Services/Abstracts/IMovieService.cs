using MVC_CodeFirst.Models.Entities;
using MVC_CodeFirst.Models.Enums;
using MVC_CodeFirst.Models.ViewModels;

namespace MVC_CodeFirst.Services.Abstracts
{
    public interface IMovieService
    {
        //Bu servis içerisinde tanımlanması gereken metotlar kullanıcının talep edebileceği metotlar olması gerekmektedir.

        //Kullanıcı Movie Listelemek isteyebilir.
        List<MovieListViewModel> GetMovies();

        //Kullanıcı Movie oluşturmak isteyebilir.
        MessageStatus CreateMovie(MovieCreateViewModel createViewModel);
    }
}
