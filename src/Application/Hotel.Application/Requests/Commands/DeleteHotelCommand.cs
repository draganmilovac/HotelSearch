using BuildingBlocks.CQRS;

namespace HotelApplication.Requests.Commands
{
    public record DeleteHotelCommand(long Id) : ICommand<DeleteHotelCommandResult>
    {
    }

    public record DeleteHotelCommandResult(bool IsDeleted);
}
