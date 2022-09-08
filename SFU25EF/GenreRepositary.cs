using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;


namespace SFU25EF
{
    public class GenreRepositary
    {
        
        // Получить все жанры        
        public List<Genre> GetAllGenres()
        {
            using (var db = new AppContext())
            {
                return db.Genres.ToList();
            }
        }
        
        // Получить жанр по ID        
        public Genre GetGenreByID(int id)
        {
            using (var db = new AppContext())
            {
                return db.Genres.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
