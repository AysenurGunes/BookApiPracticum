using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.DataAccess
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbcontext = new BookDbContext())
            {
                if (dbcontext.Books.Any())
                {
                    return;
                }
                dbcontext.BookTypes.AddRange(new BookType
                {
                    TypeName = "Science Fiction"

                }, new BookType
                {
                    TypeName = "Horror"

                }, new BookType
                {
                    TypeName = "History"

                });
                dbcontext.Publishers.AddRange(new Publisher
                {
                    PublisherName = "A Publisher"

                }, new Publisher
                {
                    PublisherName = "B Publisher"

                }, new Publisher
                {
                    PublisherName = "C Publisher"

                });

                dbcontext.Books.AddRange(
                    new Book
                    {
                        
                        BookName = "The Dan Vinci's Code",
                        AuthorName = "Dan Brown",
                        BookTypeID = 1,
                        PublisherID = 1,
                        PublishDate = new DateTime(1994, 1, 1)

                    },
                    new Book
                    {
                        BookName = "Angels and Demons",
                        AuthorName = "Dan Brown",
                        BookTypeID = 2,
                        PublisherID = 1,
                        PublishDate = new DateTime(1994, 2, 1)
                    },
                    new Book
                    {
                        BookName = "Fareler ve Insanlar",
                        AuthorName = "John Steinback",
                        BookTypeID = 3,
                        PublisherID = 2,
                        PublishDate = new DateTime(1994, 3, 1)
                    }
                );

                dbcontext.SaveChanges();
            }
        }
    }
}
