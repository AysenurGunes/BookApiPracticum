using AutoMapper;
using BookApi.DataAccess;
using BookApi.Dtos;
using BookApi.Models;
using BookApi.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        /// <summary>
        /// validation, mapper di ile inject edlip. Post ve putta kullanılmıştır.
        /// Oluşturulan Generic Entity ile Publisher ve diğer modeller ile repository işlemleri karşılanmıştır.
        /// Activity ise data silinmek istenmediği için datanın aktif olmadığını anlatmak için eklenmiştir.
        /// </summary>
        private readonly IBook<Publisher> _publisher;
        private readonly IMapper _mapper;
        public PublisherController(IBook<Publisher> publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public List<Publisher> Get()
        {
            return _publisher.GetAll().ToList();
        }

        [HttpGet("GetByID")]
        public Publisher Get([FromQuery] int id)
        {
            Expression<Func<Publisher, bool>> expression = (c => c.PublisherID == id && c.Activity == 1);
            return _publisher.GetByID(expression);
        }

        [HttpGet("GetSearchByName")]
        public List<Publisher> GetSearch([FromQuery] string Name)
        {
            Expression<Func<Publisher, bool>> expression = (c => c.PublisherName.Contains(Name));
            return _publisher.GetSpecial(expression).ToList();
        }

        [HttpGet("GetOrderByName")]
        public List<Publisher> GetOrder()
        {
            List<Publisher> publishers = Get().OrderBy(c => c.PublisherName).ToList();
            return publishers;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostPublisherDto publisher)
        {
            PostPublisherValidation validations = new PostPublisherValidation();
            validations.ValidateAndThrow(publisher);

            var publisher1 = _mapper.Map<Publisher>(publisher);
            return StatusCode(_publisher.Add(publisher1));
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PutPublisherDto publisher)
        {
            if (id != publisher.PublisherID)
            {
                return BadRequest();
            }

            var publisher1 = _mapper.Map<Publisher>(publisher);

            PublisherValidation validations = new PublisherValidation();
            validations.ValidateAndThrow(publisher1);

            int result = _publisher.Edit(publisher1);
            return StatusCode(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Publisher publisher = Get(id);
            publisher.Activity = 0;

            int result = _publisher.Delete(publisher);
            return StatusCode(result);
        }
    }
}
