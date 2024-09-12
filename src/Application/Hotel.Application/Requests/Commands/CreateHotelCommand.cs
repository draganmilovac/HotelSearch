using BuildingBlocks.CQRS;
using HotelApplication.Dtos;
using HotelData.Models;


namespace HotelApplication.Requests.Commands
{
    public record CreateHotelCommand(HotelDto HotelDto) : ICommand<CreateHotelCommandResult>
    {
    }
    public record CreateHotelCommandResult(long Id);
}
