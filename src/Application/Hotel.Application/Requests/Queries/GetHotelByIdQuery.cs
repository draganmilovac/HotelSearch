using BuildingBlocks.CQRS;
using HotelApplication.Dtos;

namespace HotelApplication.Requests.Queries
{
    public record GetHotelByIdQuery(long Id) : IQuery<GetHotelByIdQueryResult>
    {
    }

    public record GetHotelByIdQueryResult(HotelDto HotelDto);
}
