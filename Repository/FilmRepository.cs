using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using System.Collections.Generic;
using System.Linq;
using CinemaManagement.Repository;
using Microsoft.EntityFrameworkCore;
public class FilmRepository : IFilmRepository
{
    private readonly List<Film> films = CinemaContext.INSTANCE.Films.ToList();

    // Constructor
    public FilmRepository()
    {

    }

    public IEnumerable<Film> GetAllFilms() => CinemaContext.INSTANCE.Films.ToList();

    public Film GetFilmById(int id) => films.FirstOrDefault(f => f.FilmId == id);

    public void AddFilm(Film film){
        CinemaContext.INSTANCE.Films.Add(film);
        CinemaContext.INSTANCE.SaveChanges();
    }

    public void UpdateFilm(Film film)
    {
        var existingFilm = GetFilmById(film.FilmId);
        if (existingFilm != null)
        {
            existingFilm.Title = film.Title;
            existingFilm.Year = film.Year;
            existingFilm.Genre = film.Genre;
            existingFilm.Country = film.Country;
            if (CinemaContext.INSTANCE.Entry(existingFilm).State != EntityState.Modified)
            {
                CinemaContext.INSTANCE.Entry(existingFilm).State = EntityState.Modified;
            }
            CinemaContext.INSTANCE.SaveChanges();
        }
    }

    public void DeleteFilm(int id)
    {

        CinemaContext.INSTANCE.Films.Remove(GetFilmById(id));
        CinemaContext.INSTANCE.SaveChanges();
    }

    public int GetMaxFilmId()
    {
        return films.Count == 0 ? 1 : films.Max(f => f.FilmId) + 1; // Lấy ID lớn nhất
    }

    //private void LoadStaticFilms()
    //{
    //    films.Add(new Film { FilmID = 1, Title = "Phim 1", Year = 2020, Genre = "Hành Động", Country = "Mỹ" });
    //    films.Add(new Film { FilmID = 2, Title = "Phim 2", Year = 2021, Genre = "Hài Hước", Country = "Anh" });
    //    films.Add(new Film { FilmID = 3, Title = "Phim 3", Year = 2020, Genre = "Hài Hước", Country = "Hàn" });
    //    films.Add(new Film { FilmID = 4, Title = "Phim 4", Year = 2019, Genre = "Hài Hước", Country = "Việt Nam" });
    //    films.Add(new Film { FilmID = 5, Title = "Phim 5", Year = 2018, Genre = "Hài Hước", Country = "Pháp" });
    //    films.Add(new Film { FilmID = 6, Title = "Phim 6", Year = 2017, Genre = "Hài Hước", Country = "Hà Lan" });
    //}
}

