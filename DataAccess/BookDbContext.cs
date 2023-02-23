using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.DataAccess
{
    public class BookDbContext:DbContext
    {
        public BookDbContext()
        {

        }
        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // need configuration di 
            //optionsBuilder.UseSqlServer()
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //need microsoft.entityframeworkcore.sqlserver package

            modelBuilder.Entity<Book>().HasKey(c => c.BookID).IsClustered();
            modelBuilder.Entity<Book>().Property(c=>c.BookName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Book>().Property(c => c.Activity).HasDefaultValue(1);


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
    
}
