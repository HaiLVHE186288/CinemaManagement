
using CinemaManagement.Models;

namespace CinemaManagement.Repository
{
    public interface IShowRepository
    {
        public IEnumerable<Show> GetAllShows();               // Lấy tất cả lịch chiếu
        public Show GetShowById(int id);                      // Lấy lịch chiếu theo ID
        public void AddShow(Show show);                       // Thêm lịch chiếu mới
        public void UpdateShow(Show show);                    // Cập nhật thông tin lịch chiếu
        public void DeleteShow(int id);                       // Xóa lịch chiếu theo ID
        public int GetMaxShowId();                            // Lấy ID lớn nhất để thêm lịch chiếu mới
    }
}



