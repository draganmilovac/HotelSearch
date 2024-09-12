using AutoMapper;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using HotelApplication.Dtos;
using HotelApplication.Requests.Queries;
using HotelData.Abstractions;
using Microsoft.Extensions.Logging;

namespace HotelApplication.Requests.QueryHandlers
{
    public class GetHotelByIdQueryHandler : IQueryHandler<GetHotelByIdQuery, GetHotelByIdQueryResult>
    {
        #region Fields
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<GetHotelByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository, ILogger<GetHotelByIdQueryHandler> logger, IMapper mapper)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Public methods
        public async Task<GetHotelByIdQueryResult> Handle(GetHotelByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start searching for hotel with id {query.Id}");
            var hotel = await _hotelRepository.GetHotelAsync(query.Id);

            if (hotel == null)
            {
                _logger.LogError($"Hotel with id: {query.Id} does not exist.");
                throw new NotFoundException($"Hotel with id {query.Id} was not found");
            }

            _logger.LogInformation($"Hotel with {query.Id} is found");

            var hotelDto = _mapper.Map<HotelDto>(hotel);

            return new GetHotelByIdQueryResult(hotelDto);
        }
        #endregion
    }
}
