using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;

namespace CinemaManagement.Repository
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        Film GetFilmById(int id);
        void AddFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(int id);
        int GetMaxFilmId(); // Đảm bảo phương thức này có trong interface
    }

}

