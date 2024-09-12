using BuildingBlocks.CQRS;
using HotelApplication.Dtos;

namespace HotelApplication.Requests.Commands
{
    public record UpdateHotelCommand(HotelDto Hotel, long Id) : ICommand<UpdateHotelCommandResult>
    {
    }

    public record UpdateHotelCommandResult(HotelDto HotelDto);
}
