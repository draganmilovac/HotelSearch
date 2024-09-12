using BuildingBlocks.CQRS;
using HotelData.Models;

namespace HotelApplication.Requests.Queries
{
    public record GetHotelsQuery : IQuery<GetHotelQueryResult>
    {
    }

    public record GetHotelQueryResult(IEnumerable<Hotel> Hotels);
}
