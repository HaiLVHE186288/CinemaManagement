using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using CinemaManagement.Repository;

namespace CinemaManagement.Services
{
    public class FilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public IEnumerable<Film> GetAllFilms() => _filmRepository.GetAllFilms();

        public void AddFilm(Film film) => _filmRepository.AddFilm(film);

        public void UpdateFilm(Film film) => _filmRepository.UpdateFilm(film);

        public void DeleteFilm(int id) => _filmRepository.DeleteFilm(id);
    }
}

