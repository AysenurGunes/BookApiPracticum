using BookApi.Models;
using FluentValidation;

namespace BookApi.Validations
{
    public class PublisherValidation:AbstractValidator<Publisher>
    {
        public PublisherValidation()
        {
            RuleFor(c => c.PublisherID).GreaterThan(0).WithErrorCode(StatusCodes.Status204NoContent.ToString()).WithMessage("Kayıt Bulunamadı");

            RuleFor(c => c.PublisherName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Yayınevi alanı boş geçilemez.");

        }
    }
}
