using FluentValidation;
using HotelApplication.Requests.Commands;

namespace HotelApplication.Validations
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(x => x.HotelDto.Name).NotEmpty().WithMessage("Hotel name is required");
            RuleFor(x => x.HotelDto.Longitude).NotEmpty().WithMessage("Hotel Longitude is required");
            RuleFor(x => x.HotelDto.Latitude).NotEmpty().WithMessage("Hotel Latitude is required");
            RuleFor(x => x.HotelDto.Price).GreaterThan(0).WithMessage("Price for hotel must be greather than 0.");
        }
    }
}
