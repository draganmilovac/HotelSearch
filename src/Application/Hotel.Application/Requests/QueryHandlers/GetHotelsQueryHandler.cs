using BuildingBlocks.CQRS;
using HotelApplication.Requests.Queries;
using HotelData.Abstractions;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.QueryHandlers
{
    public class GetHotelsQueryHandler : IQueryHandler<GetHotelsQuery, GetHotelQueryResult>
    {
        #region Private fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<GetHotelsQueryHandler> _logger;
        #endregion

        #region Constructors
        public GetHotelsQueryHandler(IHotelRepository hotelRepository, ILogger<GetHotelsQueryHandler> logger)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Public methods
        public async Task<GetHotelQueryResult> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotelAsync();

            return new GetHotelQueryResult(hotels);
        }
        #endregion
    }
}
