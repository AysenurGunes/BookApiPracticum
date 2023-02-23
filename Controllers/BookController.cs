﻿using AutoMapper;
using BookApi.AutoMapper;
using BookApi.DataAccess;
using BookApi.Dtos;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook<Book> _book;
        private readonly IBook<PostBookDto> _book2;
        private readonly IMapper _mapper;
        public BookController(IBook<Book> book, IBook<PostBookDto> book2, IMapper mapper)
        {
            _book = book;
            _book2= book2;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public List<Book> Get()
        {
            return _book.GetAllBook().ToList();

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
        public void Post([FromBody] PostBookDto book)
        {
            //gonna be validation
           var book1= _mapper.Map<Book>(book);
            _book.Add(book1);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }
            int result = _book.Edit(book);
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
