﻿using BookApi.DataAccess;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;



namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook<Book> _book;
        public BookController(IBook<Book> book)
        {
            _book= book;
        }
        [HttpGet]
        public List<Book> Get()
        {
            return _book.GetAllBook().ToList();
             
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
