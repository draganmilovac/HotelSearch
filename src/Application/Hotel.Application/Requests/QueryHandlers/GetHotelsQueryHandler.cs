using AutoMapper;
using BuildingBlocks.CQRS;
using HotelApplication.Dtos;
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
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public GetHotelsQueryHandler(IHotelRepository hotelRepository, ILogger<GetHotelsQueryHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Public methods
        public async Task<GetHotelQueryResult> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotelAsync();
            var hotelDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);
            return new GetHotelQueryResult(hotelDto);
        }
        #endregion
    }
}
