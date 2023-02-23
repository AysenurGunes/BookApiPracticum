using BookApi.Models;

namespace BookApi.Dtos
{
    public class GetBookDto
    {
       
            public int BookID { get; set; }
            public string BookName { get; set; }
            public int BookTypeID { get; set; }
            public BookType BookType { get; set; }
            public int PublisherID { get; set; }
            public Publisher Publisher { get; set; }
            public DateTime PublishDate { get; set; }
            public string AuthorName { get; set; }
          

        
    }
}
