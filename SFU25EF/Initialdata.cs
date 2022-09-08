using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFU25EF.Entities;

namespace SFU25EF
{
    public class Initialdata
    {
        public Initialdata()
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Иванов Петр", Email = "ivanov@sample.ru" };
                var user2 = new User { Name = "Петров Иван", Email = "petrov@sample.ru" };
                var user3 = new User { Name = "Сергеев Сергей", Email = "sergeev@sample.ru" };

                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                var author1 = new Author { FirstName = "Александр", SecondName = "Пушкин" };
                var author2 = new Author { FirstName = "Лев", SecondName = "Толстой" };

                db.Authors.AddRange(author1, author2);
                db.SaveChanges();

                var genre1 = new Genre { Description = "Классика" };
                var genre2 = new Genre { Description = "Поэзия" };
                var genre3 = new Genre { Description = "Приключения" };
                var genre4 = new Genre { Description = "Для детей" };

                db.Genres.AddRange(genre1, genre2, genre3, genre4);

                db.SaveChanges();

                var book1 = new Book { Title = "Война и мир", Year = 1867 };
                var book2 = new Book { Title = "Анна Каренина", Year = 1878 };
                var book3 = new Book { Title = "Евгений Онегин", Year = 1831 };
                var book4 = new Book { Title = "Сказка о царе Салтане", Year = 1831 };

                book1.Author = author2;
                book2.Author = author2;
                book3.Author = author1;
                book4.Author = author1;

                genre4.Books.Add(book4);
                genre1.Books.Add(book1);
                genre1.Books.Add(book2);
                genre1.Books.Add(book3);
                genre2.Books.Add(book3);
                genre2.Books.Add(book4);

                db.Books.AddRange(book1, book2, book3, book4);

                user1.Books.Add(book1);
                user1.Books.Add(book3);

                db.SaveChanges();
            }
        }
    }
}
