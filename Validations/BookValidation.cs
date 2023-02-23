using BookApi.Models;
using FluentValidation;

namespace BookApi.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(c => c.BookID).GreaterThan(0).WithErrorCode(StatusCodes.Status204NoContent.ToString()).WithMessage("Kayıt Bulunamadı");
            RuleFor(c => c.PublisherID).GreaterThan(0).WithErrorCode(StatusCodes.Status204NoContent.ToString()).WithMessage("Kayıt Bulunamadı");
            RuleFor(c => c.BookTypeID).GreaterThan(0).WithErrorCode(StatusCodes.Status204NoContent.ToString()).WithMessage("Kayıt Bulunamadı");
            RuleFor(c => c.AuthorName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Yazar alanı boş geçilemez.");
            RuleFor(c => c.BookName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Kitap İsmi Boş Geçilemez.");

        }
    }
}
