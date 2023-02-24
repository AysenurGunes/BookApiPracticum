using BookApi.Dtos;
using BookApi.Models;
using FluentValidation;

namespace BookApi.Validations
{
    public class PostPublisherValidation:AbstractValidator<PostPublisherDto>
    {
        public PostPublisherValidation()
        {
            RuleFor(c => c.PublisherName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Yayınevi alanı boş geçilemez.");

        }
    }
}
