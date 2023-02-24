using AutoMapper;
using BookApi.DataAccess;
using BookApi.Dtos;
using BookApi.Models;
using BookApi.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// validation, mapper di ile inject edlip. Post ve putta kullanılmıştır.
        /// Oluşturulan Generic Entity ile Book ve diğer modeller ile repository işlemleri karşılanmıştır.
        /// Activity ise data silinmek istenmediği için datanın aktif olmadığını anlatmak için eklenmiştir.
        /// </summary>
        private readonly IBook<Book> _book;
        private readonly IMapper _mapper;
        public BookController(IBook<Book> book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public List<Book> Get()
        {
            return _book.GetAll().ToList();
        }

        [HttpGet("GetByID")]
        public Book Get([FromQuery] int id)
        {
            Expression<Func<Book, bool>> expression = (c => c.BookID == id && c.Activity == 1);
            return _book.GetByID(expression);
        }

        [HttpGet("GetSearchByName")]
        public List<Book> GetSearch([FromQuery] string Name)
        {
            Expression<Func<Book, bool>> expression = (c => c.BookName.Contains(Name));
            return _book.GetSpecial(expression).ToList();
        }

        [HttpGet("GetOrderByName")]
        public List<Book> GetOrder()
        {
            List<Book> books = Get().OrderBy(c => c.BookName).ToList();
            return books;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostBookDto book)
        {
            PostBookValidation validations = new PostBookValidation();
            validations.ValidateAndThrow(book);

            var book1 = _mapper.Map<Book>(book);
            return StatusCode(_book.Add(book1));
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PutBookDto book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            var book1 = _mapper.Map<Book>(book);

            BookValidation validations = new BookValidation();
            validations.ValidateAndThrow(book1);

            int result = _book.Edit(book1);
            return StatusCode(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Book book = Get(id);
            book.Activity = 0;

            int result = _book.Delete(book);
            return StatusCode(result);
        }

    }
}
