
using BuildingBlocks.CQRS;
using HotelApplication.Dtos;
using HotelData.Filtering;

namespace HotelApplication.Requests.Queries
{
    public record GetAllHotelsSortedByCurrentLocationQuery(double Latitude, double Longitude, int Page, int SizePerPage) : IQuery<GetAllHotelsSortedByCurrentLocationQueryResult>
    {
    }

    public record GetAllHotelsSortedByCurrentLocationQueryResult(FilterResponse<SortedHotelsDto> Hotels);
}
