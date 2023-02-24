using BookApi.Dtos;
using FluentValidation;

namespace BookApi.Validations
{
    public class PostBookTypeValidation:AbstractValidator<PostBookTypeDto>
    {
        public PostBookTypeValidation() 
        {
            RuleFor(c => c.TypeName).NotEmpty().WithErrorCode(StatusCodes.Status406NotAcceptable.ToString()).WithMessage("Tür alanı boş geçilemez.");

        }
    }
}
