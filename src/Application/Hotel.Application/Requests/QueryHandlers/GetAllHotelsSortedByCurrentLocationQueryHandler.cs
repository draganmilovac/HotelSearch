using AutoMapper;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using HotelApplication.Dtos;
using HotelApplication.Requests.Queries;
using HotelData.Abstractions;
using HotelData.Filtering;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.QueryHandlers
{
    public class GetAllHotelsSortedByCurrentLocationQueryHandler : IQueryHandler<GetAllHotelsSortedByCurrentLocationQuery, GetAllHotelsSortedByCurrentLocationQueryResult>
    {
        #region Fields
        private readonly ILocationHotelRepository _locationHotelRepository;
        private readonly ILogger<GetAllHotelsSortedByCurrentLocationQueryHandler> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public GetAllHotelsSortedByCurrentLocationQueryHandler(ILocationHotelRepository locationHotelRepository, ILogger<GetAllHotelsSortedByCurrentLocationQueryHandler> logger, IMapper mapper)
        {
            _locationHotelRepository = locationHotelRepository ?? throw new ArgumentNullException(nameof(locationHotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
        public async Task<GetAllHotelsSortedByCurrentLocationQueryResult> Handle(GetAllHotelsSortedByCurrentLocationQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Prepare list of all hotels");

            var paginationOptions = new PaginationOptions()
            {
                Page = query.Page,
                SizePerPage = query.SizePerPage,
            };
            var hotels = await _locationHotelRepository
                .GetAllHotelsSortedByCurrentLocation(query.Latitude, query.Longitude, paginationOptions);

            if (hotels.Data.Count() == 0)
            {
                _logger.LogError($"List of hotels is empty.");
                throw new NotFoundException("List of hotels is empty.");
            }
            _logger.LogInformation("List of all hotels is prepared");

            return new GetAllHotelsSortedByCurrentLocationQueryResult(
                new FilterResponse<Dtos.SortedHotelsDto>
                {
                    Data = _mapper.Map<List<SortedHotelsDto>>(hotels.Data),
                    TotalCount = hotels.TotalCount
                });
        }
    }
}
