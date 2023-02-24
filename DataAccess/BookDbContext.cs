using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.DataAccess
{
    public class BookDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BookDbContext()
        {
           
        }
        public BookDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con1 = @"Server=DESKTOP-TN9J4B3\SQLEXPRESS; Database=BookDb;User Id=patika; Password=123patika; TrustServerCertificate=True";
            string con2 = @"Server=localhost; Database=BookDb;User Id=sa; Password=123456; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(con2);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //need microsoft.entityframeworkcore.sqlserver package

            modelBuilder.Entity<Book>().HasKey(c => c.BookID).IsClustered();
            modelBuilder.Entity<Book>().Property(c => c.BookName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Book>().Property(c => c.Activity).HasDefaultValue(1);
            modelBuilder.Entity<Book>().Property(c => c.AuthorName).HasMaxLength(100);

            modelBuilder.Entity<Publisher>().HasKey(c => c.PublisherID).IsClustered();
            modelBuilder.Entity<Publisher>().Property(c => c.PublisherName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Publisher>().Property(c => c.Activity).HasDefaultValue(1);

            modelBuilder.Entity<BookType>().HasKey(c => c.BookTypeID).IsClustered();
            modelBuilder.Entity<BookType>().Property(c => c.TypeName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<BookType>().Property(c => c.Activity).HasDefaultValue(1);


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }

}
