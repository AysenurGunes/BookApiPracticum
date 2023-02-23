using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.DataAccess
{
    public class BookDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
    
}
