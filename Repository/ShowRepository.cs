using CinemaManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CinemaManagement.Repository
{
    public class ShowRepository : IShowRepository
    {
        private readonly List<Show> shows = CinemaContext.INSTANCE.Shows.ToList();

        public ShowRepository()
        {
            // Initial setup or data fetching could be done here (if required).
        }

        public IEnumerable<Show> GetAllShows()
        {
            return CinemaContext.INSTANCE.Shows.ToList();
        }

        public Show GetShowById(int id)
        {
            return shows.FirstOrDefault(s => s.ShowId == id); // Get show by ID
        }

        public void AddShow(Show show)
        {
            try
            {
                CinemaContext.INSTANCE.Shows.Add(show);
                CinemaContext.INSTANCE.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            
        }

        public void UpdateShow(Show show)
        {
            var existingShow = GetShowById(show.ShowId);
            if (existingShow != null)
            {
                existingShow.RoomId = show.RoomId;
                existingShow.FilmId = show.FilmId;
                existingShow.ShowDate = show.ShowDate;
                existingShow.Price = show.Price;
                existingShow.Status = show.Status;
                existingShow.Slot = show.Slot;
                if (CinemaContext.INSTANCE.Entry(existingShow).State != EntityState.Modified)
                {
                    CinemaContext.INSTANCE.Entry(existingShow).State = EntityState.Modified;
                }
                CinemaContext.INSTANCE.SaveChanges();
            }
        }

        public void DeleteShow(int id)
        {

            CinemaContext.INSTANCE.Shows.Remove(GetShowById(id));
            CinemaContext.INSTANCE.SaveChanges();
        }

        public int GetMaxShowId()
        {
            return shows.Any() ? shows.Max(s => s.ShowId) + 1 : 1; // Get the next ShowId
        }
    }
}
