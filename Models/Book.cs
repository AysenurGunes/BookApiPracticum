using System.Reflection.Metadata.Ecma335;

namespace BookApi.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookTypeID { get; set; }
        public BookType BookType { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public int Activity { get; set; }

    }
}
