using BuildingBlocks.CQRS;
using HotelApplication.Dtos;

namespace HotelApplication.Requests.Queries
{
    public record GetHotelsQuery : IQuery<GetHotelQueryResult>
    {
    }

    public record GetHotelQueryResult(IEnumerable<HotelDto> Hotels);
}
