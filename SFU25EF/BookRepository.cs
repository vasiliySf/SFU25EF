using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFU25EF.Entities;

namespace SFU25EF
{
    public class BookRepository
    {       
        // Получить все киниги       
        public List<Book> GetAllBooks()
        {
            using (var db = new AppContext())
            {                
                return db.Books.Include(x => x.Genres).ToList();            }
        }                
        // Получить книгу по ID        
        public Book GetBookByID (int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).Where(c=>c.Id ==id).FirstOrDefault();
            }
        }                
        // Получить книгу по названию                
        public Book GetBookByTitle(string title)
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).Where(c => c.Title == title).FirstOrDefault();
            }
        }                
        // Добавить книгу        
        public void AddNewBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }        
        // Удалить книгу        
        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }        
        // Обновить год написания книги по ID        
        public void UpdateYearByID(int id, int newyear)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(c => c.Id == id);
                book.Year = newyear;
                db.SaveChanges();
            }
        }        
        // Получать список книг определенного жанра и вышедших между определенными годами.        
        public List<Book> GetBooksOfGenreBtwYears(Genre genre, int firstyear, int lastyear)
        {
            using (var db = new AppContext())
            {               
               return db.Books.Include(x => x.Genres).Where(c => c.Year >= firstyear && c.Year <= lastyear && c.Genres.Contains(genre)).ToList();               
            }
        }
        
        // Получать количество книг определенного автора в библиотеке.        
        public int CountBooksOfAuthor(Author author)
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).Where(c => c.Author == author).Count();
            }
        }        
        // Получать количество книг определенного жанра в библиотеке        
        public int CountBooksOfGenere(Genre genre)
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).Where(c => c.Genres.Contains(genre)).Count();
            }
        }
        
        // Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.        
        public bool FlagByNameAndAuthor(string title, Author author)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(c => c.Title.Equals(title)&&c.Author == author).Any();

            }
        }        
        // Получение последней вышедшей книги. Выборка по году выпуска, из них - с максимальным id, т.е. добавленную последней        
        public Book GetLatestBook()
        {
            using (var db = new AppContext())
            {
                var lastyearbooks = db.Books.Where(c => c.Year == db.Books.Max(d => d.Year)).ToList();
                var latestid = lastyearbooks.Where(d => d.Id == lastyearbooks.Max(c => c.Id)).FirstOrDefault();
                return latestid;
            }
        }        
        // Получение списка всех книг, отсортированного в алфавитном порядке по названию        
        public List<Book> GetAllBooksSortedByTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).OrderBy(c => c.Title).ToList();
            }
        }        
        // Получение списка всех книг, отсортированного в порядке убывания года их выхода.        
        public List<Book> GetAllBooksSortedByYearDesc()
        {
            using (var db = new AppContext())
            {
                return db.Books.Include(x => x.Genres).OrderByDescending(c => c.Year).ToList();
            }
        }
    }
}
