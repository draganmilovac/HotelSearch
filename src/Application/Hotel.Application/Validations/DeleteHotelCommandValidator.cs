using FluentValidation;
using HotelApplication.Requests.Commands;

namespace HotelApplication.Validations
{
    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
    {
        public DeleteHotelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Hotel id is required");

        }
    }
}
