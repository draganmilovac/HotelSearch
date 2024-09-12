using BuildingBlocks.CQRS;
using HotelApplication.Dtos;


namespace HotelApplication.Requests.Commands
{
    public record CreateHotelCommand(HotelDto HotelDto) : ICommand<CreateHotelCommandResult>
    {
    }
    public record CreateHotelCommandResult(long Id);
}
