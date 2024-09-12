using FluentValidation;
using HotelApplication.Requests.Commands;

namespace HotelApplication.Validations
{
    public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Hotel id is required");
            RuleFor(x => x.Hotel.Name).NotEmpty().WithMessage("Hotel name is required");
            RuleFor(x => x.Hotel.Longitude).NotEmpty().WithMessage("Hotel Longitude is required");
            RuleFor(x => x.Hotel.Latitude).NotEmpty().WithMessage("Hotel Latitude is required");
            RuleFor(x => x.Hotel.Price).GreaterThan(0).WithMessage("Price for hotel must be greather than 0.");
        }
    }
}
