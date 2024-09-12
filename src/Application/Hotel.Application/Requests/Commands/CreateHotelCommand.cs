using BuildingBlocks.CQRS;
using HotelData.Models;


namespace HotelApplication.Requests.Commands
{
    public record CreateHotelCommand(Hotel Hotel) : ICommand<CreateHotelCommandResult>
    {
    }
    public record CreateHotelCommandResult(long Id);
}
