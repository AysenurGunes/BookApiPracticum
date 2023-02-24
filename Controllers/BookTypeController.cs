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
    public class BookTypeController : ControllerBase
    {
        private readonly IBook<BookType> _bookType;
        private readonly IMapper _mapper;
        public BookTypeController(IBook<BookType> bookType,IMapper mapper)
        {
            _bookType = bookType;
           _mapper = mapper;
        }
        /// <summary>
        /// validation, mapper di ile inject edlip. Post ve putta kullanılmıştır.
        /// Oluşturulan Generic Entity ile BookType ve diğer modeller ile repository işlemleri karşılanmıştır.
        /// Activity ise data silinmek istenmediği için datanın aktif olmadığını anlatmak için eklenmiştir.
        /// </summary>
        [HttpGet("GetAll")]
        public List<BookType> Get()
        {
            return _bookType.GetAll().ToList();
        }

        [HttpGet("GetByID")]
        public BookType Get([FromQuery] int id)
        {
            Expression<Func<BookType, bool>> expression = (c => c.BookTypeID == id && c.Activity == 1);
            return _bookType.GetByID(expression);
        }

        [HttpGet("GetSearchByName")]
        public List<BookType> GetSearch([FromQuery] string Name)
        {
            Expression<Func<BookType, bool>> expression = (c => c.TypeName.Contains(Name));
            return _bookType.GetSpecial(expression).ToList();
        }

        [HttpGet("GetOrderByName")]
        public List<BookType> GetOrder()
        {
            List<BookType> bookTypes = Get().OrderBy(c => c.TypeName).ToList();
            return bookTypes;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostBookTypeDto bookType)
        {
            PostBookTypeValidation validations = new PostBookTypeValidation();
            validations.ValidateAndThrow(bookType);

            var bookType1 = _mapper.Map<BookType>(bookType);
            return StatusCode(_bookType.Add(bookType1));
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PutBookTypeDto bookType)
        {
            if (id != bookType.BookTypeID)
            {
                return BadRequest();
            }

            var bookType1 = _mapper.Map<BookType>(bookType);

            BookTypeValidation validations = new BookTypeValidation();
            validations.ValidateAndThrow(bookType1);

            int result = _bookType.Edit(bookType1);
            return StatusCode(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            BookType bookType = Get(id);
            bookType.Activity = 0;

            int result = _bookType.Delete(bookType);
            return StatusCode(result);
        }
    }
}
