using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using CinemaManagement.Repository;

namespace CinemaManagement.Services
{
    public class ShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public IEnumerable<Show> GetAllShows() => _showRepository.GetAllShows();

        public void AddShow(Show show) => _showRepository.AddShow(show);

        public void UpdateShow(Show show) => _showRepository.UpdateShow(show);

        public void DeleteShow(int id) => _showRepository.DeleteShow(id);
    }
}

