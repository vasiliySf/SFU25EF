using System;
using System.Linq;
using SFU25EF.Entities; 

namespace SFU25EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstrun = new Initialdata();

            Console.WriteLine("Проверяем работу репозитариев");

            var bookrepositary = new BookRepository();
            var userrepositary = new UserRepository();
            var authorrepositary = new AuthorRepositary();
            var genrerepositary = new GenreRepositary();

            Console.WriteLine("1. Получаем все киниги:");
            foreach (var book in bookrepositary.GetAllBooks())
            {
                Console.Write($"ID-{book.Id}, название: {book.Title}, год написания: {book.Year}, " +
                    $"Автор: {authorrepositary.GetAuthorByID(book.AuthorID).SecondName}. Жанры:");
                foreach (var genere in book.Genres)
                Console.Write($"\t{genere.Description}");
                Console.WriteLine();
            }

            Console.WriteLine("2. Получаем кинигу с ID - 1:");
            var book1 = bookrepositary.GetBookByID(1);
            Console.WriteLine($"ID-{book1.Id}, название: {book1.Title}, год написания: {book1.Year}");
            
            var genresall = genrerepositary.GetAllGenres();
            foreach (var g in genresall)
            {
                Console.WriteLine(g.Description);
                foreach (var b in g.Books)
                Console.WriteLine(b.Title);
            }

            Console.WriteLine("3. Добавляем кигу: Тестовая брошюра, 1111 г.выпуска");
            var newbook = new Book { Title = "Тестовая брошюра", Year = 1111, AuthorID = 1 };
            bookrepositary.AddNewBook(newbook);

            Console.WriteLine("4. Меняем год написания на 2000");
            var book2 = bookrepositary.GetBookByTitle("Тестовая брошюра");
            bookrepositary.UpdateYearByID(book2.Id, 2000);

            Console.WriteLine("5. Получаем кинигу с названием Тестовая брошюра:");
            book2 = bookrepositary.GetBookByTitle("Тестовая брошюра");
            Console.WriteLine($"ID-{book2.Id}, название: {book2.Title}, год написания: {book2.Year}");

            Console.WriteLine("6. Удаляем найденную кинигу");
            bookrepositary.DeleteBook(book2);

            Console.WriteLine("7. Колличество книг автора 1 в библиотеке:");
            var author1 = authorrepositary.GetAuthorByID(1);
            Console.WriteLine($"Автор: {author1.SecondName} {author1.FirstName}. Колличество книг: {bookrepositary.CountBooksOfAuthor(author1)}");

            Console.Write("8. Есть ли книга Пушкина с названием Евгений Онегин в библиотеке:");
            Console.WriteLine(bookrepositary.FlagByNameAndAuthor("Евгений Онегин", authorrepositary.GetAuthorByID(1)));

            Console.WriteLine("9. Последняя вышедшая книга:");
            var lastbook = bookrepositary.GetLatestBook();
            Console.WriteLine($"ID-{lastbook.Id}, название: {lastbook.Title}, год написания: {lastbook.Year}");

            Console.WriteLine("10. Получение списка всех книг, отсортированного в алфавитном порядке по названию:");
            foreach (var book in bookrepositary.GetAllBooksSortedByTitle())
            {
                Console.Write($"ID-{book.Id}, название: {book.Title}, год написания: {book.Year}, " +
                    $"Автор: {authorrepositary.GetAuthorByID(book.AuthorID).SecondName}. Жанры:");
                foreach (var genere in book.Genres)
                    Console.Write($"\t{genere.Description}");
                Console.WriteLine();
            }

            Console.WriteLine("11. Получение списка всех книг, отсортированного в порядке убывания года их выхода:");
            foreach (var book in bookrepositary.GetAllBooksSortedByYearDesc())
            {
                Console.Write($"ID-{book.Id}, название: {book.Title}, год написания: {book.Year}, " +
                    $"Автор: {authorrepositary.GetAuthorByID(book.AuthorID).SecondName}. Жанры:");
                foreach (var genere in book.Genres)
                    Console.Write($"\t{genere.Description}");
                Console.WriteLine();
            }

            Console.WriteLine("12. Получение кол-ва книг по жанрам:");
            var genres = genrerepositary.GetAllGenres();
            foreach (var genre in genres)
                Console.WriteLine($"{genre.Description}: {bookrepositary.CountBooksOfGenere(genre)} кн.");

            Console.WriteLine($"13. Книги, вышедшие между 1840 и 1900, жанра {genrerepositary.GetGenreByID(1).Description}:");
            foreach (var book in bookrepositary.GetBooksOfGenreBtwYears(genrerepositary.GetGenreByID(1),1840,1900))
            {
                Console.Write($"ID-{book.Id}, название: {book.Title}, год написания: {book.Year}, " +
                    $"Автор: {authorrepositary.GetAuthorByID(book.AuthorID).SecondName}.");
                Console.WriteLine();
            }

            Console.WriteLine("20. Получение списка всех пользователей:");
            foreach (var user in userrepositary.GetAllUsers())
            {
                Console.WriteLine($"Имя: { user.Name}, кол-во книг на руках: {userrepositary.CountBooksRentedByUser(user)}");
            }

            Console.Write($"21. Есть ли на руках");
            var user21 = userrepositary.GetUserByID(1);
            var book21 = bookrepositary.GetBookByID(1);
            Console.WriteLine($" у пользователя {user21.Name} книга {book21.Title}: {userrepositary.FlagIfBookRentedByUser(user21,book21)}");



            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }

    }
}
