using BookApi.Models;
using FluentValidation;

namespace BookApi.Validations
{
    public class BookTypeValidation : AbstractValidator<BookType>
    {
        public BookTypeValidation()
        {
            RuleFor(c => c.BookTypeID).GreaterThan(0).WithErrorCode(StatusCodes.Status204NoContent.ToString()).WithMessage("Kayıt Bulunamadı");
            RuleFor(c => c.TypeName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Tür alanı boş geçilemez.");
            
        }
    }
}
